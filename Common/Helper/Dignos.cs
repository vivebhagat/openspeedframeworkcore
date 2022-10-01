using Common.Exceptions;

namespace Common.Helper
{
    public class Dignos
    {
        public static void CheckException(bool Expression, string Message)
        {
            if (Expression)
            {
                throw new DataProcessingException(Message);
            }
        }
    }
 }