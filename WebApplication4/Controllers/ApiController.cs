using System;
using System.Threading;
using Adyen;
using Adyen.Model.Checkout;
using Adyen.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication4.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly Checkout _checkout;
        private readonly string _merchant_account;
        private readonly ILogger<ApiController> _logger;
        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
            var client = new Client("AQEnhmfuXNWTK0Qc+iSdm2cqqPeUTp8YXMpA6r4K0do+R+AIcN9JO7uMEMFdWw2+5HzctViMSCJMYAc=-U5i1IxiMBCMIe5ePGx4YhXR/bmZ2DpZsj7769NUKSYw=-+64Ier)A#{@Ta9,m", Adyen.Model.Enum.Environment.Test); // Test Environment;
            _checkout = new Checkout(client);
            _merchant_account = "Microsoft519_000001_TEST";
            var paymentMethodsRequest = new Adyen.Model.Checkout.PaymentMethodsRequest(merchantAccount: _merchant_account);
            var paymentMethodsResponse = _checkout.PaymentMethods(paymentMethodsRequest);
        }

        [HttpPost("api/sessions")]
        public ActionResult<string> Sessions()
        {
            
            var sessionsRequest = new CreateCheckoutSessionRequest();
            sessionsRequest.merchantAccount = _merchant_account; 
            sessionsRequest.channel = (CreateCheckoutSessionRequest.ChannelEnum?)PaymentRequest.ChannelEnum.Web;

            var amount = new Amount("USD", 10*100); 
            sessionsRequest.amount = amount;
            sessionsRequest.countryCode = "US";
            var orderRef = System.Guid.NewGuid();
            sessionsRequest.reference = orderRef.ToString(); 

            sessionsRequest.returnUrl = $"https://googlepaypoc-demo.azurewebsites.net/redirect?orderRef={orderRef}";
           /*
            sessionsRequest.storePaymentMethod = true;
            sessionsRequest.shopperInteraction = CreateCheckoutSessionRequest.ShopperInteractionEnum.Ecommerce;
            sessionsRequest.recurringProcessingModel = CreateCheckoutSessionRequest.RecurringProcessingModelEnum.Subscription;
           */
            var res = _checkout.Sessions(sessionsRequest);
            _logger.LogInformation($"Response for Payment API::\n{res}\n");
            return res.ToJson();
          
           
        }
        /*
        [HttpPost("api/subscription")]
        public ActionResult<string> Subscription_create()
        {

            var sessionsRequest = new PaymentRequest();
            sessionsRequest.MerchantAccount = _merchant_account;
           // sessionsRequest.channel = (CreateCheckoutSessionRequest.ChannelEnum?)PaymentRequest.ChannelEnum.Web;

            var amount = new Amount("USD", 0 * 100);
            sessionsRequest.Amount = amount;
           // sessionsRequest.countryCode = "US";
            var orderRef = System.Guid.NewGuid();
            sessionsRequest.Reference = orderRef.ToString();

            sessionsRequest.ReturnUrl = $"https://dotnet-googlepay.azurewebsites.net/Home/Redirect?orderRef={orderRef}";
            sessionsRequest.StorePaymentMethod = true;
            sessionsRequest.ShopperInteraction = PaymentRequest.ShopperInteractionEnum.Ecommerce;
            sessionsRequest.RecurringProcessingModel = PaymentRequest.RecurringProcessingModelEnum.Subscription;

            var res = _checkout.Payments(sessionsRequest);
            _logger.LogInformation($"Response for Payment API::\n{res}\n");
            return res.ToJson();


        }
        [HttpPost("api/sub/payment")]
        public ActionResult<string> Sub_payment()
        {
            var sessionsRequest = new PaymentRequest();
            sessionsRequest.merchantAccount = _merchant_account;
            sessionsRequest.channel = (CreateCheckoutSessionRequest.ChannelEnum?)PaymentRequest.ChannelEnum.Web;

            var amount = new Amount("USD", 9 * 100);
            sessionsRequest.amount = amount;
            sessionsRequest.countryCode = "US";
            var orderRef = System.Guid.NewGuid();
            sessionsRequest.reference = orderRef.ToString();

            sessionsRequest.returnUrl = $"https://dotnet-googlepay.azurewebsites.net/Home/Redirect?orderRef={orderRef}";
            sessionsRequest.storePaymentMethod = true;
            sessionsRequest.shopperInteraction = CreateCheckoutSessionRequest.ShopperInteractionEnum.Ecommerce;
            sessionsRequest.recurringProcessingModel = CreateCheckoutSessionRequest.RecurringProcessingModelEnum.Subscription;

            var res = _checkout.Sessions(sessionsRequest);
            _logger.LogInformation($"Response for Payment API::\n{res}\n");
            return res.ToJson();


        }*/
    }
}