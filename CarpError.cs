using Carp.interpreter;
using Carp.objects.types;

namespace Carp;

// TODO: Rewrite errors to use errorinst.Error() and add line numbers
public abstract class CarpError(string message) : Exception(message)
{
    public class CarpObjError : CarpObject
    {
        public static new CarpType Type = NativeType.Of<CarpObjError>("error");
        public override CarpType GetCarpType() => Type;

        public string ErrorType;
        public string Message;

        public CarpObjError(CarpError err)
        {
            this.ErrorType = err.GetType().Name;
            this.Message = err.Message;
        }

        public override CarpString String()
        {
            return new($"error.{this.ErrorType}");
        }
    }

    public CarpError() : this("Error occured in Carp runtime")
    {
    }

    public class PrimitiveIncompatible(string primitive, CarpObject sourceObject) : CarpError(
        $"Primitive '{primitive}' is not compatible with '{sourceObject.GetCarpType()}'");

    public class UnparseableInt(string soCalledInt) : CarpError($"Given int '{soCalledInt}' was unparseable");

    public class AutoInitObjectNotPermitted() : CarpError($"Non-structs cannot be auto-initialized here");

    public class AutoNotPermitted() : CarpError($"Auto is not permitted here");

    public class KeyNotPresent(CarpObject obj) : CarpError($"Key '{obj}' is not present");

    public class RangeNotCompatible(CarpType type) : CarpError($"Cannot compute range on '{type}'");

    public class InvalidType : CarpError
    {
        public InvalidType(CarpType expected, CarpType got) : base($"Invalid type, expected '{expected}', got '{got}'")
        {
        }

        public InvalidType(List<CarpType> expected, CarpType got)
            : base(
                $"Invalid type, expected any of '{string.Join(", ", expected.Select(x => x.ToString()))}', got '{got}'")
        {
        }
    }

    public class InvalidCast(CarpObject obj, CarpType newType) : CarpError(
        $"Invalid cast, tried to convert '{obj}' to '{newType}'");

    public class DivideByZero(CarpInt other) : CarpError($"Attempted to divide {other} by zero");

    public class InvalidAssignmentTarget(CarpGrammarParser.ExpressionContext target) : CarpError(
        $"Invalid assignment target '{target.GetType().GetFormattedName()}'");

    public class InvalidProperty(Signature signature) : CarpError($"Invalid property '{signature}'");

    public class InvalidArgumentCount(int given, int expected) : CarpError(
        $"Invalid argument count, got {given}, expected {expected}");

    public class ReferenceDoesNotExist(string name) : CarpError($"Reference '{name}' does not exist in current scope");

    public class ReferenceAlreadyDefined(string name) : CarpError(
        $"Reference '{name}' is already defined in current scope");

    public class PackageNotFound(string[] name, string version) : CarpError(
        $"Could not find package '{string.Join(",", name)}' with version '{version}'");

    public class InvalidParameterCount(int expected, int got) : CarpError(
        $"Invalid parameter count, expected {expected}, got {got}");

    public class CastNullToStruct(CarpType type) : CarpError($"Attempted to cast null to struct '{type}'");

    public class VoidFromNonVoidFunction() : CarpError("Void was returned from non-voidable function");

    public class UnusedBranch(CarpGrammarParser.ExpressionContext expression) : CarpError(
        $"Unused expression branch, side-effects are not allowed on {expression.GetType().GetFormattedName()}");

    public class IndexOutOfRange(int index) : CarpError($"Index {index} was out of range");

    public class ReferenceAssignedBeforeDefinition(string name) : CarpError(
        $"Reference '{name}' assigned before definition");

    public class UnenclosedFlowControl(CarpFlowControlError err) : CarpError(
        $"Unenclosed flow control '{err.GetType().Name}'");

    public class PreprocessorError(string message) : Exception($"Preprocessor throws {message}");

    public class VagueTypeSpecificationError(CarpObject obj) : CarpError(
        $"Vague typing used, unable to determine automatic type for '{obj}'");

    public class InvalidOperation(string message) : CarpError(message);
}

public abstract class CarpFlowControlError(string message) : Exception(message)
{

    public class CarpObjFlowControlError(CarpFlowControlError err) : CarpObject
    {
        public static new CarpType Type = NativeType.Of<CarpObjFlowControlError>("flowControlError");
        public override CarpType GetCarpType() => Type;

        public string ErrorType = err.GetType().Name;
        public string Message = err.Message;

        public override CarpString String()
        {
            return new($"flowControlError.{this.ErrorType}");
        }
    }

    public CarpFlowControlError() : this("Attempted to use flow control")
    {
    }

    public class Break() : CarpFlowControlError("Break");

    public class Continue() : CarpFlowControlError("Continue");

    public class Return : CarpFlowControlError
    {
        public CarpObject Value;

        public Return(CarpObject value) : base("Return")
        {
            this.Value = value;
        }

        public Return() : base("Return")
        {
            this.Value = CarpVoid.Instance;
        }
    }
}