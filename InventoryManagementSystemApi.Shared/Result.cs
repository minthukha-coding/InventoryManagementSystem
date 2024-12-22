namespace InventoryManagementSystemApi.Shared;

public class Result<T>
{
    public bool Success { get; set; }
    public bool Error => !Success;

    public string Message { get; set; }

    public T Data { get; set; }

    public static Result<T> DuplicateValidateResult(string message)
    {
        return new Result<T> { Success = false, Message = message };
    }

    public static Result<T> NoDataFoundResult(string message)
    {
        return new Result<T> { Success = false, Message = message };
    }

    public static Result<T> SuccessResult(T data, string message = "Operation successful.")
    {
        return new Result<T> { Success = true, Data = data, Message = message };
    }

    public static Result<T> SuccessResult(string message = "Operation successful.")
    {
        return new Result<T> { Success = true, Message = message };
    }

    public static Result<T> FailureResult(string message)
    {
        return new Result<T> { Success = false, Message = message };
    }

    public static Result<T> FailureResult(Exception ex)
    {
        return new Result<T> { Success = false, Message = ex.ToString() };
    }

    public static Result<T> ExecuteResult(int result)
    {
        return result > 0 ? SuccessResult() : FailureResult("Operation Failed");
    }

    public static Result<T> BadRequestResult(string message)
    {
        return new Result<T> { Success = false, Message = $"BadRequest : {message}" };
    }
}