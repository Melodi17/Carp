namespace Carp.objects;

using interpreter.visitors;
using scoping;
using typing;
using utils;

public class InternalFunction : CarpFunction
{
    private readonly CarpGrammarParser.FunctionDefinitionContext _block;
    private readonly Dictionary<string, CarpType> _parameters;
    private readonly CarpVisitor _visitor;

    public readonly string ID = Helpers.GenerateID();

    public InternalFunction(CarpType returnType, CarpGrammarParser.FunctionDefinitionContext block, Dictionary<string, CarpType> parameters, CarpVisitor visitor) : base(returnType)
    {
        // this._block = block.Clone<CarpGrammarParser.BlockContext>();
        this._block = block;
        this._parameters = parameters;
        this._visitor = visitor;
    }


    public override CarpString String() => CarpString.Create($"<internal function {this.ID}>");
    public override CarpObject Call(CarpObject? self, CarpObject[] args)
    {
        Scope scope = new(this._block.Scope);
        this._block.Scope = scope;
        this._block.CurrentObject = self;

        // Add parameters to the scope
        for (int i = 0; i < args.Length; i++)
        {
            if (i >= this._parameters.Count)
                throw new ArgumentException($"Too many arguments provided to function {this.ID}");

            string paramName = this._parameters.Keys.ElementAt(i);
            scope.Define(new FieldMember(paramName, this._parameters[paramName], args[i]));
        }

        // Execute the block in the new scope
        CarpObject result = (CarpObject) this._visitor.Visit(this._block.body);
        return result.Coerce(this.ReturnType);
    }
    public override bool Accepts(CarpObject[] args)
    {
        if (args.Length != this._parameters.Count)
            return false;

        for (int i = 0; i < args.Length; i++)
        {
            string? paramName = this._parameters.Keys.ElementAt(i);
            if (!args[i].GetCarpType().Extends(this._parameters[paramName]))
                return false;
        }

        return true;
    }
}