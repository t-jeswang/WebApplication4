using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace WebApplication4.Models
{
    public class SessionModel
    {
        /*{
   "amount" : {
      "currency" : "USD",
      "value" : 1000
   },
   "channel" : "Web",
   "countryCode" : "US",
   "expiresAt" : "2022-07-16T22:22:18+02:00",
   "id" : "CSEC15493CAFA9CF90",
   "merchantAccount" : "Microsoft519_000001_TEST",
   "reference" : "b042466d-370f-4ccf-9676-167aeb55696a",
   "returnUrl" : "https:\/\/googlepaypoc-demo.azurewebsites.net\/redirect?orderRef=b042466d-370f-4ccf-9676-167aeb55696a",
   "sessionData" : "
    Ab02b4c0!BQABAgBjnaGukSjnu7T3SgdxEI2xMDHAUjNjmWdrpvIifWxu2Bh13e0A1\/W4z5eEUDDfpNHSoYPUX3MJWkdUNB7eJmNrDHxpCNAnA6rgsmL99jFQ84XG6XJO9VHRZC+LRM+czmuJakJvmYNGI6hxDSkjINUz8gla6ZedbO8VQ5A93VVhp79egXW+qXI4IgsQr8VmDyWyaV2rAXcB0NhMgnPByxQwYNHsAaoTpuP3aG3HL04TlzLf+quhUhqhiswvCP4ChjW+AhF1a3pFWP0SfIhiw40EQIYemBMKukMYewRhxMFG5iymQbTpFijcOimslr4peKle+epvUgNqulfRR6AqyJI\/L\/xfnjZU2D3owy3KXT6UXKMAelYUCSZlvVOT0xLtLZovilYdwAMtNBdRSgXWQfpMtCg53n2YA0nAfovf9MBOqpTmLx9NK5ZgpSiNKuRA7mhyNXh93SiKpTNn8HOxAlSvEM6ifXrT62lJx\/lUhqTqlwdTwTdHJIxgvHKOinXmO4\/TtHNXkMhy5KxplFwrkqM5iN2zGJlef2ScKP3GNGvTuKEkoakz1ou62cuVvHZyYEcphvkkefzhI2+Hc+j3Pf7DhURUmcHVxOHup9rZnKjM5mk4qD+KxL0zw8gSaaV1FzdPSbJddHE+byr03ap6Ppc0Dc9GVUkH5DLT7QQOg6nyPBAIAdJgNkBLsnGoX3yNIRzzAEp7ImtleSI6IkFGMEFBQTEwM0NBNTM3RUFFRDg3QzI0REQ1MzkwOUI4MEE3OEE5MjNFMzgyM0Q2OERBQ0M5NEI5RkY4MzA1REMifRLQppzrV9tyW0afT098ODEE6v1fFUYj+x+FPDWobfCth73wZSonGeL\/nlePsbs87srphQ7PlNu7GHwiIQL1QLNkfTvSSLGBAj8spqQ+4L6Z5NCmgNVB5EFbt6I\/QpsbH2Nw\/\/JNmhZZThruSMuPWwq3sZBnE95bV2TTxn3HVaaJrZHYQ+rC+8okEHAlg9uLlDgpN\/asPHOr8p\/JeV5SgOwVmJ6FhzlSaw6AcV9J\/a54enwc\/6uSt8jzFalcS399gdrXBANO3OV5yZtvfclcwFct2Ef\/ee+6N3j40CGJqg80Ch8whlDkob3U9zU28DXNRCGxcXhm1w1BC2pb+aqBYpVSySBmlbLlZcW2ZzHu7+bZYRbZ7+xs40AxFCRFubqxzcPZPs7NiTS6LqS3mTi\/DHPxV8ZsoylvnqQxM8X88rHUV96OqgI92a+38gxHKdkLWvnpgcvCGGan1V0rUl9tbpjGTyRHRzLr50qQH57+9vpcqamEfbe0OxST2eDOGJqG0w7crQNHln0=
        "
}*/

        //  public AmountModel Amount { get; set; }
        // https://localhost:44311/session/CSEC15493CAFA9CF90?channel=Web&countryCode=US&expiresAt=2022-07-16T22:22:18+02:00&merchantAccount=Microsoft519_000001_TEST&reference=b042466d-370f-4ccf-9676-167aeb55696a&sessionData= Ab02b4c0!BQABAgBjnaGukSjnu7T3SgdxEI2xMDHAUjNjmWdrpvIifWxu2Bh13e0A1\/W4z5eEUDDfpNHSoYPUX3MJWkdUNB7eJmNrDHxpCNAnA6rgsmL99jFQ84XG6XJO9VHRZC+LRM+czmuJakJvmYNGI6hxDSkjINUz8gla6ZedbO8VQ5A93VVhp79egXW+qXI4IgsQr8VmDyWyaV2rAXcB0NhMgnPByxQwYNHsAaoTpuP3aG3HL04TlzLf+quhUhqhiswvCP4ChjW+AhF1a3pFWP0SfIhiw40EQIYemBMKukMYewRhxMFG5iymQbTpFijcOimslr4peKle+epvUgNqulfRR6AqyJI\/L\/xfnjZU2D3owy3KXT6UXKMAelYUCSZlvVOT0xLtLZovilYdwAMtNBdRSgXWQfpMtCg53n2YA0nAfovf9MBOqpTmLx9NK5ZgpSiNKuRA7mhyNXh93SiKpTNn8HOxAlSvEM6ifXrT62lJx\/lUhqTqlwdTwTdHJIxgvHKOinXmO4\/TtHNXkMhy5KxplFwrkqM5iN2zGJlef2ScKP3GNGvTuKEkoakz1ou62cuVvHZyYEcphvkkefzhI2+Hc+j3Pf7DhURUmcHVxOHup9rZnKjM5mk4qD+KxL0zw8gSaaV1FzdPSbJddHE+byr03ap6Ppc0Dc9GVUkH5DLT7QQOg6nyPBAIAdJgNkBLsnGoX3yNIRzzAEp7ImtleSI6IkFGMEFBQTEwM0NBNTM3RUFFRDg3QzI0REQ1MzkwOUI4MEE3OEE5MjNFMzgyM0Q2OERBQ0M5NEI5RkY4MzA1REMifRLQppzrV9tyW0afT098ODEE6v1fFUYj+x+FPDWobfCth73wZSonGeL\/nlePsbs87srphQ7PlNu7GHwiIQL1QLNkfTvSSLGBAj8spqQ+4L6Z5NCmgNVB5EFbt6I\/QpsbH2Nw\/\/JNmhZZThruSMuPWwq3sZBnE95bV2TTxn3HVaaJrZHYQ+rC+8okEHAlg9uLlDgpN\/asPHOr8p\/JeV5SgOwVmJ6FhzlSaw6AcV9J\/a54enwc\/6uSt8jzFalcS399gdrXBANO3OV5yZtvfclcwFct2Ef\/ee+6N3j40CGJqg80Ch8whlDkob3U9zU28DXNRCGxcXhm1w1BC2pb+aqBYpVSySBmlbLlZcW2ZzHu7+bZYRbZ7+xs40AxFCRFubqxzcPZPs7NiTS6LqS3mTi\/DHPxV8ZsoylvnqQxM8X88rHUV96OqgI92a+38gxHKdkLWvnpgcvCGGan1V0rUl9tbpjGTyRHRzLr50qQH57+9vpcqamEfbe0OxST2eDOGJqG0w7crQNHln0=
        //CSB809D60ADD000356
        public string Channel  { get; set; }

               public string CountryCode { get; set; }

               public string ExpiresAt { get; set; }

               public string Id { get; set; }

               public string MerchantAccount { get; set; }

               public string Reference { get; set; }

               public string ReturnUrl { get; set; }

               public string SessionData { get; set; }

    }
}
