using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMediaSat.Models
{
    public class TrendList
    {
        [JsonProperty("trends")]
        public List<TrendsModel> Trends { get; set; }
    }
}