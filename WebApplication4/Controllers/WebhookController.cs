using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Adyen.Model.Notification;
using Adyen.Util;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication4.Controllers
{
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly string _hmac_key;
        private readonly ILogger<WebhookController> _logger;
        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
            _hmac_key = "E3A106B81A97DCEF43B11A501954D08370CE9B63EAB9C3EB75DD661E591D3984";
        }

        [HttpPost("api/webhooks/notifications")]
        public ActionResult<string> Webhooks([FromBody] NotificationRequest notificationRequest)
        {
            //var hmacValidator = new HmacValidator();

            //_logger.LogInformation($"Webhook received::\n{notificationRequest}\n");
            //NotificationRequestItemContainer container = notificationRequest.NotificationItemContainers[0];

            /*
            foreach (NotificationRequestItemContainer container in notificationRequest.NotificationItemContainers)
            {
                // We recommend to activate HMAC validation in the webhooks for security reasons

                    if (hmacValidator.IsValidHmac(container.NotificationItem, _hmac_key))
                    {
                        _logger.LogInformation($"Received webhook with event::\n" +
                            $"Merchant Reference ::{container.NotificationItem.MerchantReference} \n" +
                            $"PSP Reference ::{container.NotificationItem.PspReference} \n"
                        );

                    }
                    else
                    {
                        _logger.LogError($"Error while validating HMAC Key");

                    }
                    //  return "[accepted]";
             }
            */
            // return "[accepted]";
            
            return $"Webhook received::\n{notificationRequest.ToString()}\n";
        }

    }
}