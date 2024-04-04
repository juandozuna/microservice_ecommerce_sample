namespace Camco.Services.CouponAPI.Models;

public class ResponseDto<T>
{
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }
}