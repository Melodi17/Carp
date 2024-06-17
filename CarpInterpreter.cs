using System.Text;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Carp.interpreter;
using Carp.objects.types;
using Carp.package;
using Carp.package.resolvers;
using Carp.parser;

namespace Carp;

public class CarpInterpreter : CarpGrammarBaseVisitor<object>
{
    private static readonly CarpStatic Marshal = new("marshal");

    static CarpInterpreter()
    {
        Marshal.AddEnum("static");
    }

    public static CarpInterpreter Instance;
    public IPackageResolver PackageResolver;
    public Dictionary<string, CarpObject> Resources;

    public int CurrentLine { get; private set; } = 0;
    public bool Paused { get; set; } = false;
    private bool _step = false;

    private bool Next
    {
        get
        {
            if (!this.Paused) return true;

            if (!this._step) return false;

            this._step = false;
            return true;
        }
    }

    public IScope GlobalScope { get; set; }

    public CarpInterpreter(IPackageResolver packageResolver)
    {
        this.GlobalScope = new Scope();
        this.PackageResolver = packageResolver;
        this.Resources = new();

        DefineVarByName("int", CarpType.Type, CarpInt.Type);
        DefineVarByName("str", CarpType.Type, CarpString.Type);
        DefineVarByName("chr", CarpType.Type, CarpChar.Type);
        DefineVarByName("bool", CarpType.Type, CarpBool.Type);
        DefineVarByName("obj", CarpType.Type, CarpObject.Type);
        DefineVarByName("range", CarpType.Type, CarpRange.Type);
        DefineVarByName("byte_sequence", CarpType.Type, CarpByteSequence.Type);
        DefineVarByName("enum", CarpType.Type, CarpEnum.Type);
        DefineVarByName("type", CarpType.Type, CarpType.Type);
        DefineVarByName("null", CarpNull.Type, CarpNull.Instance);
        DefineVarByName("void", CarpType.Type, CarpVoid.Type);

        DefineVarByName("func", CarpType.Type, CarpFunc.Type);
        DefineVarByName("auto", CarpType.Type, AutoType.Instance);

        DefineVarByName("marshal", CarpStatic.Type, Marshal);

        // io contains print and input
        // fs containts filesystem
        // math has more math
        // color has color stuff, like 'hi %red%etc%reset%'
        // refract has reflection stuff, e.g get type

        // CarpExternalFunc tFunc = new(CarpType.Type, (CarpObject obj)
        //     => obj.GetCarpType());
        //
        // this.GlobalScope.Define(Signature.OfMethod("t", tFunc), CarpFunc.Type, tFunc);

        DefineFuncByName("import", new CarpExternalFunc(CarpVoid.Type, (CarpString name, CarpString ver) =>
        {
            string[] parts = name.Native.Trim('\r').Split(".")
                .Select(x => x.Replace('/', '.'))
                .ToArray();

            string verString = ver.Native;

            Package pkg = this.PackageResolver.GetPackageEx(this, parts, parts, verString);
            pkg.Include(this);
        }));
    }
    
    public void DefineVarByName(string name, CarpType type, CarpObject value)
    {
        this.GlobalScope.Define(Signature.OfVariable(name), type, value);
    }
    
    public void DefineFuncByName(string name, CarpFunc func)
    {
        this.GlobalScope.Define(Signature.OfMethod(name, func), CarpFunc.Type, func);
    }

    public void Step() => this._step = true;

    public object Visit(ScopedParserRuleContext tree, IScope scopeContext)
    {
        tree.ContextScope = scopeContext;
        return this.Visit(tree);
    }

    public void Execute(ScopedParserRuleContext parent, CarpGrammarParser.Generic_blockContext child,
        Dictionary<Signature, CarpObject> scope)
        => this.Execute(parent.ContextScope, child, scope);

    public void Execute(IScope parentScope, CarpGrammarParser.Generic_blockContext child,
        Dictionary<Signature, CarpObject> scope)
    {
        Scope s = new(parentScope);
        foreach (KeyValuePair<Signature, CarpObject> kvp in scope)
            s.Define(kvp.Key, kvp.Value.GetCarpType(), kvp.Value);

        this.Execute(s, child);
    }

    public void Execute(ScopedParserRuleContext parent, ScopedParserRuleContext child) =>
        this.Execute(parent.ContextScope, child);

    public void Execute(IScope parentScope, ScopedParserRuleContext child)
    {
        this.CurrentLine = child.Start.Line;
        if (Flags.Instance.Debug && Program.Debugger.Attached)
        {
            if (Program.Debugger.Breakpoints.Contains(this.CurrentLine))
                this.Paused = true;

            while (!this.Next) Thread.Sleep(50);
        }

        this.Visit(child, parentScope);
    }

    public object PassDown(ScopedParserRuleContext parent) => this.Visit(
        parent.children.First(x => x is ScopedParserRuleContext) as ScopedParserRuleContext, parent.ContextScope);

    public Binary GetBinary(CarpGrammarParser.BinaryContext binary) => (Binary)this.Visit(binary);

    public Comparison GetComparison(CarpGrammarParser.ComparisonContext comparison) =>
        (Comparison)this.Visit(comparison);

    public Logical GetLogical(CarpGrammarParser.LogicalContext logical) => (Logical)this.Visit(logical);
    public Unary GetUnary(CarpGrammarParser.UnaryContext unary) => (Unary)this.Visit(unary);
    public Modifier GetModifier(CarpGrammarParser.ModifierContext modifier) => (Modifier)this.Visit(modifier);

    public Dictionary<string, CarpType> GetTypeNameList(ScopedParserRuleContext context,
        CarpGrammarParser.Type_name_listContext typeNameList) =>
        this.GetTypeNameList(context.ContextScope, typeNameList);

    public Dictionary<string, CarpType> GetTypeNameList(IScope scope,
        CarpGrammarParser.Type_name_listContext typeNameList) =>
        (Dictionary<string, CarpType>)this.Visit(typeNameList, scope);

    // TODO: Use modifier result from name!!
    public (string name, Modifier modifiers) GetName(CarpGrammarParser.NameContext name) =>
        ((string name, Modifier modifiers))this.VisitName(name);

    public (CarpObject[] attrs, CarpGrammarParser.DefinitionContext definitionContext) GetDefinition(
        ScopedParserRuleContext parent, CarpGrammarParser.Definition_with_attrContext def)
        => ((CarpObject[] attrs, CarpGrammarParser.DefinitionContext definitionContext))this.Visit(def,
            parent.ContextScope);

    public (CarpObject[] attrs, CarpGrammarParser.DefinitionContext definitionContext) GetDefinition(IScope scope,
        CarpGrammarParser.Definition_with_attrContext def)
        => ((CarpObject[] attrs, CarpGrammarParser.DefinitionContext definitionContext))this.Visit(def, scope);

    public CarpObject[] GetExpressionList(ScopedParserRuleContext parent,
        CarpGrammarParser.Expression_listContext context) => this.Visit(context, parent.ContextScope) as CarpObject[];

    public CarpObject[] GetExpressionList(ScopedParserRuleContext parent,
        IList<CarpGrammarParser.ExpressionContext> context)
    {
        CarpObject[] exprs = new CarpObject[context.Count];
        for (int i = 0; i < context.Count; i++)
            exprs[i] = this.GetObject(parent, context[i]);

        return exprs;
    }

    public CarpObject GetObject(ScopedParserRuleContext parent, ScopedParserRuleContext child) =>
        this.GetObject(parent.ContextScope, child);

    public CarpObject GetObject(IScope scope, ScopedParserRuleContext child)
    {
        object obj = this.Visit(child, scope);
        if (obj is not CarpObject co)
            throw new InvalidCastException($"Expected CarpObject, got {obj?.GetType()?.GetFormattedName()}");
        return co;
    }

    public T GetObject<T>(ScopedParserRuleContext parent, ScopedParserRuleContext child) where T : CarpObject
    {
        CarpObject obj = this.GetObject(parent, child);
        CarpType type = NativeType.Find<T>();

        return obj.CastEx(type) as T;
    }

    public override object VisitProgram(CarpGrammarParser.ProgramContext context)
    {
        if (context._statements.Count == 1)
        {
            CarpGrammarParser.StatementContext first = context._statements.First();
            if (first != null && first.children.Count == 1)
                if (first.children[0] is CarpGrammarParser.ExpressionStatementContext esc)
                    return this.GetObject(this.GlobalScope, esc.expression());
                else if (first.children[0] is CarpGrammarParser.ExpressionContext ec)
                    return this.GetObject(this.GlobalScope, ec);
        }

        foreach (CarpGrammarParser.StatementContext stmt in context._statements)
            this.Execute(this.GlobalScope, stmt);

        return CarpVoid.Instance;
    }

    public override object VisitBlock(CarpGrammarParser.BlockContext context)
    {
        Scope s = new(context.ContextScope);
        
        object? obj = null;

        foreach (ScopedParserRuleContext sprc in context._statements)
            obj = this.Visit(sprc, s);

        s.Dispose();

        return obj as CarpObject ?? CarpVoid.Instance;
    }

    public override object VisitEnclosedBlock(CarpGrammarParser.EnclosedBlockContext context) => this.PassDown(context);

    public override object VisitLambdaExpressionBlock(CarpGrammarParser.LambdaExpressionBlockContext context)
    {
        Scope s = new(context.ContextScope);

        CarpObject obj = this.GetObject(s, context.expression());

        s.Dispose();

        return obj;
    }

    public override object VisitLambdaBlock(CarpGrammarParser.LambdaBlockContext context)
    {
        Scope s = new(context.ContextScope);

        // foreach (IParseTree pt in context.children)
        //     if (pt is ScopedParserRuleContext sprc)
        //         this.Execute(s, sprc);

        // try
        // {
        //     this.Execute(s, context.statement());
        // }
        // catch (CarpFlowControlError.Return r)
        // {
        //     return r.Value;
        // }
        // finally
        // {
        //     s.Dispose();
        // }
        //
        // return CarpVoid.Instance;
        
        object? obj = this.Visit(context.statement(), s);
        
        s.Dispose();
        
        return obj as CarpObject ?? CarpVoid.Instance;
    }

    public override object VisitDefinitionStatement(CarpGrammarParser.DefinitionStatementContext context)
    {
        CarpGrammarParser.Definition_with_attrContext def = context.definition_with_attr();
        (CarpObject[] attrs, CarpGrammarParser.DefinitionContext definitionContext) parts = GetDefinition(context, def);
        this.Visit(parts.definitionContext, context.ContextScope);
        return null;
    }

    public override object VisitExpressionStatement(CarpGrammarParser.ExpressionStatementContext context)
    {
        //this.Execute(context, context.expression());

        if (context.expression()
            is CarpGrammarParser.AssignmentExpressionContext
            or CarpGrammarParser.CompoundAssignmentExpressionContext
            or CarpGrammarParser.CallExpressionContext
            or CarpGrammarParser.TernaryExpressionContext)
        {
            this.Visit(context.expression(), context.ContextScope);
        }
        else
            throw new CarpError.UnusedBranch(context.expression());

        return null;
    }

    public override object VisitFlowControlStatement(CarpGrammarParser.FlowControlStatementContext context) =>
        this.PassDown(context);

    public override object VisitFlow_control(CarpGrammarParser.Flow_controlContext context) => this.PassDown(context);

    public override object VisitIf_statement(CarpGrammarParser.If_statementContext context)
    {
        CarpBool cond = this.GetObject<CarpBool>(context, context.cond);

        if (cond.Native)
            this.Execute(context, context.body);
        else
        {
            bool metCond = false;
            for (int i = 0; i < context._elif_expressions.Count; i++)
            {
                CarpBool elifCond = this.GetObject<CarpBool>(context, context._elif_expressions[i]);
                if (elifCond.Native)
                {
                    this.Execute(context, context._elif_blocks[i]);
                    metCond = true;
                    break;
                }
            }

            if (!metCond && context.else_block != null)
                this.Execute(context, context.else_block);
        }

        return null;
    }

    public override object VisitWhile_statement(CarpGrammarParser.While_statementContext context)
    {
        while (this.GetObject<CarpBool>(context, context.cond).Native)
        {
            try
            {
                this.Execute(context, context.body);
            }
            catch (CarpFlowControlError.Break)
            {
                break;
            }
            catch (CarpFlowControlError.Continue)
            {
                continue;
            }
        }

        return null;
    }

    public override object VisitIterStatement(CarpGrammarParser.IterStatementContext context)
    {
        CarpObject iter = this.GetObject(context, context.iter);
        CarpIterator iterator = iter.Iterate();

        while (iterator.HasNext().Native)
        {
            try
            {
                iterator.Next();
                this.Execute(context, context.body);
            }
            catch (CarpFlowControlError.Break)
            {
                break;
            }
            catch (CarpFlowControlError.Continue)
            {
                continue;
            }
        }

        return null;
    }

    public override object VisitIterAsStatement(CarpGrammarParser.IterAsStatementContext context)
    {
        CarpObject iter = this.GetObject(context, context.iter);
        CarpIterator iterator = iter.Iterate();

        Dictionary<Signature, CarpObject> subScope = new();

        (string name, _) = this.GetName(context.name());
        CarpType type = this.GetObject<CarpType>(context, context.type());

        while (iterator.HasNext().Native)
        {
            try
            {
                CarpObject cur = iterator.Next();

                if (type != AutoType.Instance && cur.GetCarpType() != type)
                    // TODO: Test this out
                    cur = cur.CastEx(type);

                if (type == AutoType.Instance)
                    type = cur.GetCarpType();

                subScope[Signature.OfVariable(name)] = cur;

                this.Execute(context, context.body, subScope);
            }
            catch (CarpFlowControlError.Break)
            {
                break;
            }
            catch (CarpFlowControlError.Continue)
            {
                continue;
            }
        }

        return null;
    }

    public override object VisitIterAsUnpackedStatement(CarpGrammarParser.IterAsUnpackedStatementContext context)
    {
        throw new NotImplementedException();
    }

    public override object VisitTry_statement(CarpGrammarParser.Try_statementContext context)
    {
        // TODO: Let is acutally not needed! Modify the syntax
        try
        {
            this.Execute(context, context.try_block);
        }
        catch (CarpError error)
        {
            CarpError.CarpObjError errorObj = new(error);

            Dictionary<Signature, CarpObject> scope = new();

            for (int index = 0; index < context._catch_types.Count; index++)
            {
                CarpGrammarParser.TypeContext tc = context._catch_types[index];
                CarpObject obj = this.GetObject(context, tc);
                Signature sig = Signature.OfVariable(context._catch_names[index].GetText());
                if (obj == AutoType.Instance)
                {
                    scope[sig] = errorObj;
                    this.Execute(context, context._catch_blocks[index], scope);
                    return null;
                }

                if (obj is not CarpError.CarpObjError coe || coe.ErrorType != errorObj.ErrorType) continue;

                scope[sig] = errorObj;
                this.Execute(context, context._catch_blocks[index], scope);
                return null;
            }

            throw;
        }
        catch (CarpFlowControlError error)
        {
            CarpFlowControlError.CarpObjFlowControlError errorObj = new(error);

            Dictionary<Signature, CarpObject> scope = new();

            // only catch explicit
            for (int index = 0; index < context._catch_types.Count; index++)
            {
                CarpGrammarParser.TypeContext tc = context._catch_types[index];
                CarpObject obj = this.GetObject(context, tc);

                if (obj is not CarpFlowControlError.CarpObjFlowControlError coe ||
                    coe.ErrorType != errorObj.ErrorType) continue;

                Signature sig = Signature.OfVariable(context._catch_names[index].GetText());
                scope[sig] = errorObj;
                this.Execute(context, context._catch_blocks[index], scope);
                return null;
            }

            throw;
        }

        return null;
    }

    public override object VisitReturn_statement(CarpGrammarParser.Return_statementContext context)
    {
        if (context.value != null)
            throw new CarpFlowControlError.Return(this.GetObject(context, context.value));
        else
            throw new CarpFlowControlError.Return();
    }

    public override object VisitBreak_statement(CarpGrammarParser.Break_statementContext context)
    {
        throw new CarpFlowControlError.Break();
    }

    public override object VisitContinue_statement(CarpGrammarParser.Continue_statementContext context)
    {
        throw new CarpFlowControlError.Continue();
    }

    public override object VisitYield_statement(CarpGrammarParser.Yield_statementContext context)
    {
        throw new NotImplementedException();
    }

    public override object VisitAttribute(CarpGrammarParser.AttributeContext context)
    {
        CarpObject obj = this.GetObject(context, context.obj);

        return obj;
    }

    public override object VisitInitializedVariableDefinition(
        CarpGrammarParser.InitializedVariableDefinitionContext context)
    {
        (string name, Modifier modifiers) = this.GetName(context.name());
        CarpType type = this.GetObject<CarpType>(context, context.type());
        CarpObject value = this.GetObject(context, context.value);

        if (type == AutoType.Instance)
            type = value.GetCarpType();

        if (!value.GetCarpType().Extends(type))
            value = value.CastEx(type);

        context.ContextScope.Define(Signature.OfVariable(name), type, value);

        return null;
    }

    public override object VisitVariableDefinition(CarpGrammarParser.VariableDefinitionContext context)
    {
        (string name, Modifier modifiers) = this.GetName(context.name());
        CarpType type = this.GetObject<CarpType>(context, context.type());

        if (type == AutoType.Instance)
            throw new CarpError.AutoNotPermitted();

        if (!type.IsStruct && !Flags.Instance.DefaultNonStructs)
            throw new CarpError.AutoInitObjectNotPermitted();

        context.ContextScope.Define(Signature.OfVariable(name), type, type.DefaultValue);

        return null;
    }

    public override object VisitFunctionDefinition(CarpGrammarParser.FunctionDefinitionContext context)
    {
        (string name, Modifier modifiers) = this.GetName(context.name());
        Dictionary<string, CarpType> args = this.GetTypeNameList(context, context.values);
        CarpType returnType = this.GetObject<CarpType>(context, context.rtype);
        CarpGrammarParser.Generic_blockContext body = context.body;
        body.ContextScope = context.ContextScope;

        // we are going to violate the rules here to prevent having to make MAJOR changes to the code to support non-carp objects to C# objects

        CarpInternalFunc func = new(returnType, context.ContextScope, args, body);

        context.ContextScope.Define(Signature.OfMethod(name, func), func.GetCarpType(), func);

        return null;
    }

    public override object VisitEmptyFunctionDefinition(CarpGrammarParser.EmptyFunctionDefinitionContext context)
    {
        (string name, Modifier modifiers) = this.GetName(context.name());

        Dictionary<string, CarpType> args = this.GetTypeNameList(context, context.values);
        CarpType returnType = this.GetObject<CarpType>(context, context.rtype);

        // Type funcType = typeof(CarpInternalFunc<>);
        // Type[] typeArgs = new[] { returnType.GetType() };
        // Type constructed = funcType.MakeGenericType(typeArgs);
        //
        // return Activator.CreateInstance(constructed, new object[] { args });

        // return new EmptyFunc(returnType);

        EmptyFunc func = new(returnType, args.Values.ToArray());

        context.ContextScope.Define(Signature.OfMethod(name, func), func.GetCarpType(), func);

        return null;
    }

    public override object VisitClassDefinition(CarpGrammarParser.ClassDefinitionContext context)
    {
        // TODO: Remember about attrs!

        (string name, Modifier modifiers) = this.GetName(context.name());

        this.MakeObject(name, modifiers, context.ContextScope, context._definitions.ToList(), false);

        return null;
    }

    public override object VisitStructDefinition(CarpGrammarParser.StructDefinitionContext context)
    {
        (string name, Modifier modifiers) = this.GetName(context.name());

        this.MakeObject(name, modifiers, context.ContextScope, context._definitions.ToList(), true);

        return null;
    }

    private void MakeObject(string name, Modifier modifiers, IScope scope,
        List<CarpGrammarParser.Definition_with_attrContext> definitions, bool isStruct)
    {
        // Split static and dynamic
        List<CarpGrammarParser.Definition_with_attrContext> staticDefinitions = new();
        List<CarpGrammarParser.Definition_with_attrContext> nonStaticDefinitions = new();

        CarpEnum staticEnum = Marshal.Enum("static");

        foreach (CarpGrammarParser.Definition_with_attrContext def in definitions)
        {
            (CarpObject[] attrs, CarpGrammarParser.DefinitionContext definitionContext) =
                this.GetDefinition(scope, def);

            (attrs.Any(x => x.Equals(staticEnum))
                ? staticDefinitions
                : nonStaticDefinitions).Add(def);
        }

        CarpClass clazz = new(new(name), isStruct, scope, staticDefinitions, nonStaticDefinitions);
        scope.Define(Signature.OfVariable(name), clazz.GetCarpType(), clazz);
    }

    public override object VisitDefinition_with_attr(CarpGrammarParser.Definition_with_attrContext context)
    {
        return (context._attrs.Select(x => this.GetObject(context.ContextScope, x)).ToArray(),
            context.def);
    }

    public override object VisitMapExpression(CarpGrammarParser.MapExpressionContext context)
        => this.PassDown(context);

    public override object VisitLambdaExpression(CarpGrammarParser.LambdaExpressionContext context)
    {
        Dictionary<string, CarpType> args = this.GetTypeNameList(context, context.values);
        CarpGrammarParser.Generic_blockContext body = context.body;
        body.ContextScope = context.ContextScope;

        CarpInternalFunc func = new(AutoType.Instance, context.ContextScope, args, body);

        return func;
    }

    public override object VisitConstantExpression(CarpGrammarParser.ConstantExpressionContext context) =>
        this.PassDown(context);

    public override object VisitArrayExpression(CarpGrammarParser.ArrayExpressionContext context) =>
        this.PassDown(context);

    public override object VisitAssignmentExpression(CarpGrammarParser.AssignmentExpressionContext context)
    {
        CarpGrammarParser.ExpressionContext assignmentTarget = context.left;
        CarpObject value = this.GetObject(context, context.right);

        if (assignmentTarget is CarpGrammarParser.VariableExpressionContext vec)
        {
            (string name, _) = this.GetName(vec.name());

            context.ContextScope.Set(Signature.OfVariable(name), value);
            return value;
        }
        else if (assignmentTarget is CarpGrammarParser.IndexExpressionContext iec)
        {
            CarpObject[] args = this.GetExpressionList(context, iec.parameters);
            CarpObject obj = this.GetObject(context, iec.obj);
            obj.SetIndex(args, value);
            return value;
        }
        else if (assignmentTarget is CarpGrammarParser.PropertyExpressionContext pec)
        {
            (string name, Modifier modifiers) = this.GetName(pec.value);
            CarpObject obj = this.GetObject(context, pec.obj);
            obj.SetProperty(Signature.OfVariable(name), value);
            return value;
        }
        else
            throw new CarpError.InvalidAssignmentTarget(assignmentTarget);
    }

    public override object VisitComparisonExpression(CarpGrammarParser.ComparisonExpressionContext context)
    {
        CarpObject left = this.GetObject(context, context.left);
        Comparison op = this.GetComparison(context.op);
        CarpObject right = this.GetObject(context, context.right);

        return op switch
        {
            Comparison.Match => left.Match(right),
            Comparison.NotMatch => left.Match(right).Not(),
            Comparison.GreaterThan => left.Greater(right),
            Comparison.LessThan => left.Less(right),
            Comparison.GreaterThanEquals => CarpBool.Of(left.Greater(right).Native || left.Match(right).Native),
            Comparison.LessThanEquals => CarpBool.Of(left.Less(right).Native || left.Match(right).Native),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public override object VisitLogicalExpression(CarpGrammarParser.LogicalExpressionContext context)
    {
        // CarpBool left = this.GetObject<CarpBool>(context, context.left);
        CarpObject left = this.GetObject<CarpObject>(context, context.left);
        Logical op = this.GetLogical(context.op);

        // CarpBool GetRight() => this.GetObject<CarpBool>(context, context.right);
        CarpObject GetRight() => this.GetObject<CarpObject>(context, context.right);

        bool Truthy(CarpObject obj)
        {
            return obj switch
            {
                CarpBool b => b.Native,
                CarpNull => false,
                _ => true
            };
        }
        
        return op switch
        {
            Logical.And => Truthy(left) ? GetRight() : left,
            Logical.Or => Truthy(left) ? left : GetRight(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override object VisitVariableExpression(CarpGrammarParser.VariableExpressionContext context)
    {
        (string name, _) = this.GetName(context.name());
        return context.ContextScope.Get(Signature.OfVariable(name));
    }

    public override object VisitBinaryExpression(CarpGrammarParser.BinaryExpressionContext context)
    {
        CarpObject left = this.GetObject(context, context.left);
        Binary op = this.GetBinary(context.op);
        CarpObject right = this.GetObject(context, context.right);

        return op switch
        {
            Binary.Add => left.Add(right),
            Binary.Subtract => left.Subtract(right),
            Binary.Multiply => left.Multiply(right),
            Binary.Divide => left.Divide(right),
            Binary.Pow => left.Pow(right),
            Binary.Modulus => left.Modulus(right),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public override object VisitCastExpression(CarpGrammarParser.CastExpressionContext context)
    {
        CarpObject obj = this.GetObject(context, context.obj);
        CarpType type = this.GetObject<CarpType>(context, context.type());

        return obj.CastEx(type, isImplicit: false);
    }

    public override object VisitCompareTypeExpression(CarpGrammarParser.CompareTypeExpressionContext context)
    {
        CarpObject obj = this.GetObject(context, context.obj);
        CarpType type = this.GetObject<CarpType>(context, context.type());

        return CarpBool.Of(obj.GetCarpType().Extends(type));
    }

    public override object VisitParenthesizedExpression(CarpGrammarParser.ParenthesizedExpressionContext context)
    {
        CarpGrammarParser.ExpressionContext expr = context.obj;
        return this.Visit(expr, context.ContextScope);
    }

    public override object VisitCallExpression(CarpGrammarParser.CallExpressionContext context)
    {
        CarpObject callee = this.GetObject(context, context.obj);

        CarpObject[] args = this.GetExpressionList(context, context.parameters);

        CarpObject obj = callee.Call(args);
        return obj;
    }

    public override object VisitInfixExpression(CarpGrammarParser.InfixExpressionContext context)
    {
        throw new NotImplementedException();
    }

    public override object VisitWindExpression(CarpGrammarParser.WindExpressionContext context)
    {
        CarpObject inner = this.GetObject(context, context.inner);

        return new CarpWinded(inner);
    }

    public override object VisitFilterExpression(CarpGrammarParser.FilterExpressionContext context)
    {
        //CarpObject inner = this.GetObject(context, context.inner);

        //return new CarpFiltered(inner);

        throw new NotImplementedException();
    }

    public override object VisitCompoundAssignmentExpression(
        CarpGrammarParser.CompoundAssignmentExpressionContext context)
    {
        CarpGrammarParser.AssignmentExpressionContext assignment = new(context);
        CarpGrammarParser.BinaryExpressionContext binary = new(context);
        CarpGrammarParser.BinaryContext binaryOp = new();
        binaryOp.children = new List<IParseTree> { context.op };
        // Operator gets automatically converted for us!

        assignment.left = context.left;
        assignment.right = binary;
        binary.left = context.left;
        binary.right = context.right;
        binary.op = binaryOp;

        assignment.ContextScope = context.ContextScope;
        binary.ContextScope = context.ContextScope;
        binaryOp.ContextScope = context.ContextScope;

        return this.VisitAssignmentExpression(assignment);
    }

    public override object VisitRangeExpression(CarpGrammarParser.RangeExpressionContext context)
    {
        CarpObject left = this.GetObject(context, context.left);
        CarpObject right = this.GetObject(context, context.right);

        // raise if not same
        if (left.GetType() != right.GetType())
            throw new CarpError.InvalidType(left.GetCarpType(), right.GetCarpType());

        // make generic range type
        // Type rangeType = typeof(CarpRange<>);
        // Type[] typeArgs = { left.GetType() };
        // Type constructed = rangeType.MakeGenericType(typeArgs);
        //
        // return Activator.CreateInstance(constructed, new object[] { left, right });

        return CarpRange.Type.With(left.GetCarpType())
            .Instantiate(new[] { left, right });
    }

    public override object VisitEndRangeExpression(CarpGrammarParser.EndRangeExpressionContext context)
    {
        CarpObject left = new CarpInt(0);
        CarpObject right = this.GetObject(context, context.right);

        // raise if not same
        if (left.GetCarpType() != right.GetCarpType())
            throw new CarpError.InvalidType(left.GetCarpType(), right.GetCarpType());

        // make generic range type
        // Type rangeType = typeof(CarpRange);
        // Type[] typeArgs = { left.GetType() };
        // Type constructed = rangeType.MakeGenericType(typeArgs);
        //
        // return Activator.CreateInstance(constructed, new object[] { left, right });

        return CarpRange.Type.With(left.GetCarpType())
            .Instantiate(new[] { left, right });
    }

    public override object VisitIndexExpression(CarpGrammarParser.IndexExpressionContext context)
    {
        CarpObject callee = this.GetObject(context, context.obj);
        CarpObject[] args = this.GetExpressionList(context, context.parameters);

        CarpObject obj = callee.Index(args);
        return obj;
    }

    public override object VisitUnaryExpression(CarpGrammarParser.UnaryExpressionContext context)
    {
        CarpObject obj = this.GetObject(context, context.left);
        Unary op = this.GetUnary(context.op);

        return op switch
        {
            Unary.Negate => obj.Negate(),
            Unary.Not => obj is CarpBool b
                ? b.Not()
                : throw new CarpError.InvalidType(CarpBool.Type, obj.GetCarpType()),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override object VisitTernaryExpression(CarpGrammarParser.TernaryExpressionContext context)
    {
        CarpBool cond = this.GetObject<CarpBool>(context, context.condition);

        // short circuit

        return this.GetObject<CarpObject>(context, cond.Native
            ? context.left
            : context.right);
    }

    public override object VisitPropertyExpression(CarpGrammarParser.PropertyExpressionContext context)
    {
        CarpObject obj = this.GetObject(context, context.obj);
        (string name, Modifier modifiers) = this.GetName(context.value);

        return obj.Property(Signature.OfVariable(name));
    }

    public override object VisitPostfixExpression(CarpGrammarParser.PostfixExpressionContext context)
    {
        return new NotImplementedException();
    }

    public override object VisitExpression_list(CarpGrammarParser.Expression_listContext context)
    {
        CarpObject[] exprs = new CarpObject[context._expressions.Count];
        for (int i = 0; i < context._expressions.Count; i++)
            exprs[i] = this.GetObject(context, context._expressions[i]);

        return exprs;
    }

    public override object VisitAddCompound(CarpGrammarParser.AddCompoundContext context) => Compound.Add;

    public override object VisitSubtractCompound(CarpGrammarParser.SubtractCompoundContext context) =>
        Compound.Subtract;

    public override object VisitMultiplyCompound(CarpGrammarParser.MultiplyCompoundContext context) =>
        Compound.Multiply;

    public override object VisitDivideCompound(CarpGrammarParser.DivideCompoundContext context) => Compound.Divide;

    public override object VisitPowerCompound(CarpGrammarParser.PowerCompoundContext context) => Compound.Pow;
    public override object VisitModulusCompound(CarpGrammarParser.ModulusCompoundContext context) => Compound.Modulus;

    public override object VisitIntConstant(CarpGrammarParser.IntConstantContext context)
    {
        string num = context.INT().GetText();
        if (!double.TryParse(num, out double d))
            throw new CarpError.UnparseableInt(num);

        return new CarpInt(d);
    }

    public override object VisitCharConstant(CarpGrammarParser.CharConstantContext context)
    {
        char value = context.CHAR().GetText().Last();
        return new CarpChar(value);
    }

    public override object VisitStringConstant(CarpGrammarParser.StringConstantContext context)
    {
        string value = context.STRING().GetText();
        // crop surrounding quotes
        value = value[1..^1];

        // StringBuilder sb = new();
        // bool escaped = false;
        // foreach (char c in value)
        // {
        //     if (c == '\\')
        //     {
        //         escaped = true;
        //         continue;
        //     }
        //
        //     if (escaped)
        //     {
        //         switch (c)
        //         {
        //             case 'n':
        //                 sb.Append('\n');
        //                 break;
        //             case 't':
        //                 sb.Append('\t');
        //                 break;
        //             case 'r':
        //                 sb.Append('\r');
        //                 break;
        //             case '\\':
        //                 sb.Append('\\');
        //                 break;
        //             case '\'':
        //                 sb.Append('\'');
        //                 break;
        //             case '0':
        //                 sb.Append('\0');
        //                 break;
        //             default:
        //                 throw new CarpError.PreprocessorError($"Unknown escape sequence \\{c}");
        //         }
        //
        //         escaped = false;
        //     }
        //     else
        //         sb.Append(c);
        // }

        return new CarpString(Regex.Unescape(value));
    }

    public override object VisitTrueConstant(CarpGrammarParser.TrueConstantContext context) => CarpBool.True;

    public override object VisitFalseConstant(CarpGrammarParser.FalseConstantContext context) => CarpBool.False;

    public override object VisitNullConstant(CarpGrammarParser.NullConstantContext context) => CarpNull.Instance;

    public override object VisitNegateUnary(CarpGrammarParser.NegateUnaryContext context) => Unary.Negate;

    public override object VisitNotUnary(CarpGrammarParser.NotUnaryContext context) => Unary.Not;

    public override object VisitAndLogical(CarpGrammarParser.AndLogicalContext context) => Logical.And;

    public override object VisitOrLogical(CarpGrammarParser.OrLogicalContext context) => Logical.Or;

    public override object VisitMatchComparison(CarpGrammarParser.MatchComparisonContext context) => Comparison.Match;

    public override object VisitNotMatchComparison(CarpGrammarParser.NotMatchComparisonContext context) =>
        Comparison.NotMatch;

    public override object VisitGreaterThanComparison(CarpGrammarParser.GreaterThanComparisonContext context) =>
        Comparison.GreaterThan;

    public override object VisitLessThanComparison(CarpGrammarParser.LessThanComparisonContext context) =>
        Comparison.LessThan;

    public override object VisitGreaterThanEqualsComparison(
        CarpGrammarParser.GreaterThanEqualsComparisonContext context) => Comparison.GreaterThanEquals;

    public override object VisitLessThanEqualsComparison(CarpGrammarParser.LessThanEqualsComparisonContext context) =>
        Comparison.LessThanEquals;

    public override object VisitAddBinary(CarpGrammarParser.AddBinaryContext context) => Binary.Add;

    public override object VisitSubtractBinary(CarpGrammarParser.SubtractBinaryContext context) => Binary.Subtract;

    public override object VisitMultiplicationBinary(CarpGrammarParser.MultiplicationBinaryContext context) =>
        Binary.Multiply;

    public override object VisitDivideBinary(CarpGrammarParser.DivideBinaryContext context) => Binary.Divide;

    public override object VisitPowerBinary(CarpGrammarParser.PowerBinaryContext context) => Binary.Pow;
    public override object VisitModulusBinary(CarpGrammarParser.ModulusBinaryContext context) => Binary.Modulus;

    public override object VisitArray(CarpGrammarParser.ArrayContext context)
    {
        CarpObject[] arr = this.GetExpressionList(context, context.expression_list());
        // if they are all the same type, return a CarpCollection<similartype>
        // otherwise, return a CarpCollection

        // if (arr.Length == 0)
        //     return new CarpCollection<CarpObject>();
        //
        // Type type = arr[0].GetType();
        // bool allSame = arr.All(obj => obj.GetType() == type);
        //
        // if (allSame)
        // {
        //     Type collectionType = typeof(CarpCollection<>);
        //     Type[] typeArgs = { type };
        //     Type constructed = collectionType.MakeGenericType(typeArgs);
        //
        //     return Activator.CreateInstance(constructed, new object[] { arr });
        // }
        // else
        //     return new CarpCollection<CarpObject>(arr.ToList());

        if (arr.Length == 0)
            return new CarpCollection(CarpObject.Type);

        CarpType type = CarpType.HighestCommonType(arr.Select(x => x.GetCarpType()).ToArray());

        return new CarpCollection(type, arr);
    }

    public override object VisitMap(CarpGrammarParser.MapContext context)
    {
        CarpObject[] keys = this.GetExpressionList(context, context._keys);
        CarpObject[] values = this.GetExpressionList(context, context._values);

        if (keys.Length != values.Length)
            throw new CarpError.InvalidParameterCount(keys.Length, values.Length);

        // if (keys.Length == 0)
        //     return new CarpMap<CarpObject, CarpObject>();
        //
        // // induvidually typecheck keys and values
        // Type keyType = keys[0].GetType();
        // bool keysAllSame = keys.All(obj => obj.GetType() == keyType);
        //
        // Type valueType = values[0].GetType();
        // bool valuesAllSame = values.All(obj => obj.GetType() == valueType);
        //
        // Type mapKeyType = keysAllSame ? keyType : typeof(CarpObject);
        // Type mapValueType = valuesAllSame ? valueType : typeof(CarpObject);
        //
        // Type mapType = typeof(CarpMap);
        // Type[] typeArgs = { mapKeyType, mapValueType };
        // Type constructed = mapType.MakeGenericType(typeArgs);
        //
        // return Activator.CreateInstance(constructed, new object[] { keys, values });

        if (keys.Length == 0)
            return new CarpMap(CarpObject.Type, CarpObject.Type);

        CarpType keyType = CarpType.HighestCommonType(keys.Select(x => x.GetCarpType()).ToArray());
        CarpType valueType = CarpType.HighestCommonType(values.Select(x => x.GetCarpType()).ToArray());

        return new CarpMap(keyType, valueType, keys, values);
    }

    public override object VisitPrivateModifier(CarpGrammarParser.PrivateModifierContext context) => Modifier.Private;

    public override object VisitNamedType(CarpGrammarParser.NamedTypeContext context)
    {
        // get it from scope
        string name = context.ID().GetText();
        CarpObject obj = context.ContextScope.Get(Signature.OfVariable(name));
        if (obj is not CarpType type)
            throw new CarpError.InvalidType(CarpType.Type, obj.GetCarpType());

        return type;
    }

    public override object VisitPropertyType(CarpGrammarParser.PropertyTypeContext context)
    {
        // basically (main).(part).(part)
        string name = context.main.Text;
        CarpObject obj = context.ContextScope.Get(Signature.OfVariable(name));

        foreach (IToken? part in context._parts)
        {
            if (obj is not CarpObject co)
                throw new CarpError.InvalidType(CarpObject.Type, obj.GetCarpType());

            name = part.Text;
            obj = co.Property(Signature.OfVariable(name));
        }

        if (obj is not CarpType type)
            throw new CarpError.InvalidType(CarpType.Type, obj.GetCarpType());

        return type;
    }

    public override object VisitAutoType(CarpGrammarParser.AutoTypeContext context) => AutoType.Instance;

    public override object VisitMapType(CarpGrammarParser.MapTypeContext context)
    {
        CarpType keyType = this.GetObject<CarpType>(context, context.key);
        CarpType valueType = this.GetObject<CarpType>(context, context.value);

        // Assemble type with generics

        // Type type = typeof(CarpMap);
        // Type[] typeArgs = { keyType.Native, valueType.Native };
        // Type constructed = type.MakeGenericType(typeArgs);
        //
        // return constructed.GetCarpType();

        return CarpMap.Type.With(keyType, valueType);
    }

    public override object VisitGenericType(CarpGrammarParser.GenericTypeContext context)
    {
        CarpType baseType = this.GetObject<CarpType>(context, context.main);
        CarpType[] subTypes = context._subs.Select(x => this.GetObject<CarpType>(context, x)).ToArray();

        return baseType.With(subTypes);
    }

    public override object VisitListType(CarpGrammarParser.ListTypeContext context)
    {
        CarpType elementType = this.GetObject<CarpType>(context, context.element);

        // Assemble type with generics

        // Type type = typeof(CarpCollection<>);
        // Type[] typeArgs = { elementType.Native };
        // Type constructed = type.MakeGenericType(typeArgs);
        //
        // return constructed.GetCarpType();

        return CarpCollection.Type.With(elementType);
    }

    public override object VisitType_name_list(CarpGrammarParser.Type_name_listContext context)
    {
        Dictionary<string, CarpType> types = new();
        for (int i = 0; i < context._names.Count; i++)
        {
            (string name, Modifier _) = this.GetName(context._names[i]);
            CarpType type = this.GetObject<CarpType>(context, context._types[i]);

            types[name] = type;
        }

        return types;
    }

    public override object VisitName(CarpGrammarParser.NameContext context)
    {
        string text = context.GetText();
        Modifier flags = context._modifiers
            .Select(ctx => this.GetModifier(ctx))
            .Aggregate<Modifier, Modifier>(default, (current, mod) => current | mod);

        return (text, flags);
    }
}