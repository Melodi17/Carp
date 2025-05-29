using Carp.interpreter.visitors;
using Carp.objects.typing;
using Carp.scoping;
using Carp.utils;

namespace Carp.objects;

public class InternalFunction : CarpFunction
{
    private readonly CarpGrammarParser.BlockContext _block;
    private readonly Dictionary<string, CarpType> _parameters;
    private readonly CarpVisitor _visitor;

    public readonly string ID = Helpers.GenerateID();
    
    public InternalFunction(CarpType returnType, CarpGrammarParser.BlockContext block, Dictionary<string, CarpType> parameters, CarpVisitor visitor) : base(returnType)
    {
        this._block = block.Clone<CarpGrammarParser.BlockContext>();
        this._parameters = parameters;
        this._visitor = visitor;
    }


    public override CarpString String() => CarpString.Create($"<internal function {ID}>");
    public override CarpObject Call(CarpObject? self, CarpObject[] args)
    {
        Scope scope = new Scope(this._block.Scope);
        this._block.Scope = scope;
        this._block.CurrentObject = self;

        // Add parameters to the scope
        for (int i = 0; i < args.Length; i++)
        {
            if (i >= this._parameters.Count)
                throw new ArgumentException($"Too many arguments provided to function {this.ID}");
            
            var paramName = this._parameters.Keys.ElementAt(i);
            scope.Define(new FieldMember(paramName, this._parameters[paramName], args[i]));
        }
        
        // Execute the block in the new scope
        CarpObject result = (CarpObject)this._visitor.VisitBlock(this._block._statements);
        return result.Coerce(this.ReturnType);

    }
    public override bool Accepts(CarpObject[] args) => throw new NotImplementedException();
}