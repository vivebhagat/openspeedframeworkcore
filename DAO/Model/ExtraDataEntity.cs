using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedFramework.Common.CoreModels
{
    public abstract class ExtraDataEntity {

        public string LegacyNumber { get; set; }

        [NotMapped]
        public Dictionary<int, string> ExtraData
        {
            get
            {
                return JsonConvert.DeserializeObject<Dictionary<int, string>>(LegacyNumber);
            }
            set { LegacyNumber = JsonConvert.SerializeObject(value);  }
        }
    }
}