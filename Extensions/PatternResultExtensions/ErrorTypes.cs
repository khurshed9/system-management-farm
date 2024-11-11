namespace SystemManagementFactory.Extensions.PatternResultExtensions;

public enum ErrorTypes
{
    None = 1,
    NotFound,
    AlreadyExist,
    InternalServerError,
    Conflict,
    BadRequest,
}