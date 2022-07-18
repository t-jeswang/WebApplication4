using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace WebApplication4.Models
{
    public class AmountModel
    {

        /*"currency" : "USD",
       "value" : 1000*/
        public string Currency { get; set; }
        public string Value { get; set; }

    }
}
