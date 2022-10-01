using System.Collections.Generic;

namespace Common.Filter
{
    public class FilterResult<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int Count { get; set; }
    }
  
}