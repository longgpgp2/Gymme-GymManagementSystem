using System;

namespace GMS.Core.Exceptions;

public class ResourceNotFoundException(string message) : Exception(message)
{
}

public class ResourceUniqueException(string message) : Exception(message)
{
}

public class DatabaseBadRequestException(string message) : Exception(message)
{
}

public class TokenInvalidException(string message) : Exception(message)
{
}

public class RequestValidationException(string message) : Exception(message)
{
}
