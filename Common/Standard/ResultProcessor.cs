using System;
using System.Threading.Tasks;

namespace Common.Standard
{
    public class ResultProcessor
    {
        public static ServiceResult<K> Process<K>(Func<K> o)
        {
            K result = default(K);
            result = o();
            return ServiceResult<K>.GetSuccessResult(result);
        }

        public static async Task<K> ProcessAsync<K>(Func<K> o)
        {
            K result = default(K);
            result =  await Task.Run(o);
            return result; // ServiceResult<K>.GetSuccessResult(result);
        }
    }
}
