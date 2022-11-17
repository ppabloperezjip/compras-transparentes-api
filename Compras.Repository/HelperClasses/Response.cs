namespace Compras.Repository.HelperClasses;

public enum Result
{
    OK,
    ERROR,
    BAD_REQUEST,
    NOT_FOUND,
    INVALID_PASSWORD,
    EXCEPTION,
    BLOCKED_USER,
    ALREADY_ASSIGNED,
    NOT_ASSIGNED,
    DISABLED_AND_UNASSIGNED,
    NOT_REGISTERED,
    ALREADY_EXISTS,
    ERROR_GETTING_DATA,
    SERVICE_EXCEPTION,
    NETWORK_UNAVAILABLE,
    LIMIT_ORDER_EXCEEDED,
    DEVICE_NOT_AUTHORIZED,
    INVALID_ASSISTANCE,
    STATUS_CHANGED,
    USER_NOT_FOUND
}
public class Response
{
    public Result Result { get; set; }
    public string Data { get; set; }
}