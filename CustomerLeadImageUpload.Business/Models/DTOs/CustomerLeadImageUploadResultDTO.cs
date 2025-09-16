

namespace CustomerLeadImageUpload.Business.Models.DTOs
{
    public class CustomerLeadImageUploadResultDTO<T>
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }

        public static CustomerLeadImageUploadResultDTO<T> Success(T result)
            => new()
            {
                IsSuccess = true,
                Data = result
            };

        public static CustomerLeadImageUploadResultDTO<T> Error(string message, T data)
            => new()
            {
                IsSuccess = false,
                Message = message,
                Data = data
            };
    }

    public class CustomerLeadImageUploadResultDTO
  {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }
        public object? Data { get; private set; }

        public static CustomerLeadImageUploadResultDTO Error(string message)
            => new()
            {
                IsSuccess = false,
                Message = message
            };

        public static CustomerLeadImageUploadResultDTO Success()
            => new()
            {
                IsSuccess = true,
            };

        public static CustomerLeadImageUploadResultDTO Success(object data)
           => new()
           {
               IsSuccess = true,
               Data = data
           };
    }
}
