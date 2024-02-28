using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETLClient
{
    public class Universitet
    {
        public List<string> web_pages { get; set; }
        public string country { get; set; }
        public List<string> domains { get; set; }
        public string name { get; set; }
        public string alpha_two_code { get; set; }

        [JsonPropertyName("state-province")]
        public string state_province { get; set; }


        public override string ToString()
        {
            return $"{country} { string.Join( "", domains)} {name} {alpha_two_code} {state_province}  {string.Join( "",web_pages)}";
        }
    }
}
