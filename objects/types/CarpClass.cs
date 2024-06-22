using Carp.interpreter;

namespace Carp.objects.types;

public class CarpClass : CarpType
{
    private readonly CarpInterpreter _interpreter;
    private List<CarpGrammarParser.Definition_with_attrContext> _staticDefinitions;
    private List<CarpGrammarParser.Definition_with_attrContext> _nonStaticDefinitions;
    private Scope _scope;
    public CarpClass(CarpInterpreter interpreter, CarpString name, bool isStruct, IScope scope, List<CarpGrammarParser.Definition_with_attrContext> staticDefinitions, List<CarpGrammarParser.Definition_with_attrContext> nonStaticDefinitions) : base(CarpObject.Type, name, isStruct)
    {
        this._scope = new Scope(scope);
        this._interpreter = interpreter;
        this._staticDefinitions = staticDefinitions;
        this._nonStaticDefinitions = nonStaticDefinitions;
        
        // Create static definitions
        foreach (CarpGrammarParser.Definition_with_attrContext def in staticDefinitions)
            this._interpreter.Execute(this._scope, this._interpreter.GetDefinition(scope, def).definitionContext);
    }

    public override CarpObject Instantiate(CarpObject[] args, bool isImplicit = false)
    {
        // Create instance
        Scope scope = new(this._scope);
        CarpObject obj = new CarpDynamic(this._interpreter, this, scope);
        
        // Create non-static definitions
        foreach (CarpGrammarParser.Definition_with_attrContext def in this._nonStaticDefinitions)
            this._interpreter.Execute(scope, this._interpreter.GetDefinition(this._scope, def).definitionContext);
        
        // Call constructor
        Signature sig = Signature.InitMethod.WithSpecific(CarpVoid.Type, args.Select(x => x.GetCarpType()).ToArray());
        if (scope.Has(sig))
        {
            CarpObject init = scope.Get(sig);
            if (init is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, init.GetCarpType());
            
            func.Call(args);
        }

        return obj;
    }

    public override CarpObject Property(Signature signature)
    {
        if (Equals(signature, Signature.NewCall))
            return new CarpExternalFunc(CarpObject.Type, (CarpObject[] args) => this.Instantiate(args), ignoreArgTypes: true);
        
        return this._scope.Has(signature) 
            ? this._scope.Get(signature)
            : base.Property(signature);
    }
    
    public override CarpObject SetProperty(Signature signature, CarpObject value)
    {
        this._scope.Set(signature, value);
        return value;
    }
}