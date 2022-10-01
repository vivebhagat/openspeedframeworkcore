using System.Threading.Tasks;

namespace Common.Standard
{
    public class ServiceResult<T>
    {
        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }

        public T Result { get; set; }

        public string SuccessMessage { get; set; }

        public static ServiceResult<T> GetSuccessResult(T value, string Message="")
        {
            ServiceResult<T> result =  new ServiceResult<T> {
                IsError = false,
                Result = value,
                SuccessMessage = Message
            };
            return result;
        }


        public static ServiceResult<T> GetErrorResult(string Message = "")
        {
            return new ServiceResult<T>
            {
                IsError = true,
                ErrorMessage = Message
            };
        }
    }
}
