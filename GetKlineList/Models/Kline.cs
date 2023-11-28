using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetKlineList.Models
{

    [PrimaryKey("OpenTime")]
    public class Kliner
    {

        [JsonProperty("t")]
        public long OpenTime { get; set; }

        [JsonProperty("o")]
        public string Open { get; set; }

        [JsonProperty("c")]
        public string Close { get; set; }

        [JsonProperty("v")]
        public string Volume { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

    }
}
