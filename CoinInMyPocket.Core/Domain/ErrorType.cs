namespace CoinInMyPocket.Core.Domain
{
    public enum ErrorType
    {
        Unknown = 0,
        Error = 1,

        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409
    }
}
