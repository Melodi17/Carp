using Carp.objects.types;

namespace Carp;

public abstract class CarpError : Exception
{
    public abstract string DisplayName { get; }
    public class CarpObjError : CarpObject
    {
        public static new CarpType Type = NativeType.Of<CarpObjError>("error");
        public override CarpType GetCarpType() => Type;

        public string ErrorType;
        public string Message;
        
        public CarpObjError(CarpError err)
        {
            this.ErrorType = err.DisplayName;
            this.Message = err.Message;
        }
        public override CarpString String()
        {
            return new($"error.{this.ErrorType}");
        }
    }
    public CarpError() : base("Error occured in Carp runtime") { }
    public CarpError(string message) : base(message) { }
    
    public class PrimitiveIncompatible : CarpError
    {
        public override string DisplayName => "PrimitiveIncompatible";
        public PrimitiveIncompatible(string primitive, CarpObject sourceObject) : base($"Primitive '{primitive}' is not compatible with '{sourceObject.GetCarpType()}'") { }
    }

    public class UnparseableInt : CarpError
    {
        public override string DisplayName => "UnparseableInt";
        public UnparseableInt(string soCalledInt) : base($"Given int '{soCalledInt}' was unparseable")
        {
            
        }
    }
    
    public class AutoInitObjectNotPermitted : CarpError
    {
        public override string DisplayName => "AutoInitObjectNotPermitted";

        public AutoInitObjectNotPermitted() : base($"Non-structs cannot be auto-initialized here")
        {
            
        }
    }

    public class AutoNotPermitted : CarpError
    {
        public override string DisplayName => "AutoNotPermitted";

        public AutoNotPermitted() : base($"Auto is not permitted here")
        {
            
        }
    }
    
    public class KeyNotPresent : CarpError
    {
        public override string DisplayName => "KeyNotPresent";

        public KeyNotPresent(CarpObject obj) : base($"Key '{obj}' is not present")
        {
            
        }
    }

    public class RangeNotCompatible : CarpError
    {
        public override string DisplayName => "RangeNotCompatible";

        public RangeNotCompatible(CarpType type) : base($"Cannot compute range on '{type}'")
        {
            
        }
    }

    public class InvalidType : CarpError
    {
        public override string DisplayName => "InvalidType";

        public InvalidType(CarpType expected, CarpType got) : base($"Invalid type, expected '{expected}', got '{got}'")
        {
            
        }
        
        public InvalidType(List<CarpType> expected, CarpType got)
            : base($"Invalid type, expected any of '{string.Join(", ", expected.Select(x=>x.ToString()))}', got '{got}'")
        {
            
        }
    }
    
    public class InvalidCast : CarpError
    {
        public override string DisplayName => "InvalidCast";

        public InvalidCast(CarpType got) : base($"Invalid cast, got '{got}'")
        {
            
        }
    }

    public class DivideByZero : CarpError
    {
        public override string DisplayName => "DivideByZero";

        public DivideByZero(CarpInt other) : base($"Attempted to divide {other} by zero")
        {
            
        }
    }
    
    public class InvalidAssignmentTarget : CarpError
    {
        public override string DisplayName => "InvalidAssignmentTarget";

        public InvalidAssignmentTarget(CarpGrammarParser.ExpressionContext target) : base($"Invalid assignment target '{target.GetType().GetFormattedName()}'")
        {
            
        }
    }
    
    public class InvalidProperty : CarpError
    {
        public override string DisplayName => "InvalidProperty";

        public InvalidProperty(string name) : base($"Invalid property '{name}'")
        {
            
        }
    }

    public class InvalidArgumentCount : CarpError
    {
        public override string DisplayName => "InvalidArgumentCount";

        public InvalidArgumentCount(int given, int expected) : base($"Invalid argument count, got {given}, expected {expected}")
        {
            
        }
    }
    
    public class ReferenceDoesNotExist : CarpError
    {
        public override string DisplayName => "ReferenceDoesNotExist";

        public ReferenceDoesNotExist(string name) : base($"Reference '{name}' does not exist in current scope")
        {
            
        }
    }
    
    public class ReferenceAlreadyDefined : CarpError
    {
        public override string DisplayName => "ReferenceAlreadyDefined";

        public ReferenceAlreadyDefined(string name) : base($"Reference '{name}' is already defined in current scope")
        {
            
        }
    }
    
    public class PackageNotFound : CarpError
    {
        public override string DisplayName => "PackageNotFound";

        public PackageNotFound(string name, string version) : base($"Could not find package '{name}' with version '{version}'")
        {
            
        }
    }

    public class InvalidParameterCount : CarpError
    {
        public override string DisplayName => "InvalidParameterCount";

        public InvalidParameterCount(int expected, int got) : base($"Invalid parameter count, expected {expected}, got {got}")
        {
            
        }
    }
    
    public class CastNullToStruct : CarpError
    {
        public override string DisplayName => "CastNullToStruct";

        public CastNullToStruct(CarpType type) : base($"Attempted to cast null to struct '{type}'")
        {
            
        }
    }

    public class VoidFromNonVoidFunction : CarpError
    {
        public override string DisplayName => "VoidFromNonVoidFunction";

        public VoidFromNonVoidFunction() : base("Void was returned from non-voidable function")
        {
            
        }
    }
    public class UnusedBranch : CarpError
    {
        public override string DisplayName => "UnusedBranch";

        public UnusedBranch(CarpGrammarParser.ExpressionContext expression) : base($"Unused expression branch, side-effects are not allowed on {expression.GetType().GetFormattedName()}")
        {
            
        }
    }
    public class IndexOutOfRange : CarpError
    {
        public override string DisplayName => "IndexOutOfRange";

        public IndexOutOfRange(int index) : base($"Index {index} was out of range")
        {
            
        }
    }
    public class ReferenceAssignedBeforeDefinition : CarpError
    {
        public override string DisplayName => "ReferenceAssignedBeforeDefinition";
        public ReferenceAssignedBeforeDefinition(string name) : base($"Reference '{name}' assigned before definition")
        {
            
        }
    }
    public class UnenclosedFlowControl : CarpError
    {
        public override string DisplayName => "UnenclosedFlowControl";
        public UnenclosedFlowControl(CarpFlowControlError err) : base($"Unenclosed flow control '{err.DisplayName}'")
        {
            
        }
    }
    public class PreprocessorError : Exception
    {
        public PreprocessorError(string message) : base($"Preprocessor throws {message}")
        {
            
        }
    }
}

public abstract class CarpFlowControlError : Exception
{
    public abstract string DisplayName { get; }
    public class CarpObjFlowControlError : CarpObject
    {
        public static new CarpType Type = NativeType.Of<CarpObjFlowControlError>("flowControlError");
        public override CarpType GetCarpType() => Type;

        public string ErrorType;
        public string Message;
        
        public CarpObjFlowControlError(CarpFlowControlError err)
        {
            this.ErrorType = err.DisplayName;
            this.Message = err.Message;
        }
        public override CarpString String()
        {
            return new($"flowControlError.{this.ErrorType}");
        }
    }
    public CarpFlowControlError() : base("Attempted to use flow control") { }
    public CarpFlowControlError(string message) : base(message) { }
    
    public class Break : CarpFlowControlError
    {
        public override string DisplayName => "Break";
        public Break() : base("Break") { }
    }
    
    public class Continue : CarpFlowControlError
    {
        public override string DisplayName => "Continue";
        public Continue() : base("Continue") { }
    }

    public class Return : CarpFlowControlError
    {
        public override string DisplayName => "Return";
        public CarpObject Value;
        public Return(CarpObject value) : base("Return") { this.Value = value; }
        public Return() : base("Return") { this.Value = CarpVoid.Instance; }
    }
}