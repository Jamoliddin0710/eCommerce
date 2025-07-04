namespace eCommerce.Core.DTOs;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }

    public static ApiResponse<T> SuccessResponse(T data)
    {
        return new ApiResponse<T> { Success = true, Data = data };
    }

    public static ApiResponse<T> ErrorResponse(string message)
    {
        return new ApiResponse<T> { Success = false, ErrorMessage = message };
    }
}