namespace Carp.exceptions;

public class ParserException(string message, Exception? ex = null)
    : Exception(message, ex);