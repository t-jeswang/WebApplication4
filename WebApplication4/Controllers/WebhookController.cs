using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Adyen.Model.Notification;
using Adyen.Util;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebApplication4.Models;

namespace adyen_dotnet_online_payments.Controllers
{
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly string _hmac_key;
        private readonly ILogger<WebhookController> _logger;
        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
            _hmac_key = "295AC9F38A7F6BAA9560C27E878C047B3CBB86FCD97E72FCCEF4D09DCD9C7D4C";
        }

        [HttpPost("api/webhooks/notifications")]
        public ActionResult<string> Webhooks([FromBody] NotificationRequest notificationRequest)
        {
          
            var hmacValidator = new HmacValidator();

            _logger.LogInformation($"Webhook received::\n{notificationRequest}\n");
            
            foreach (NotificationRequestItemContainer container in notificationRequest.NotificationItemContainers)
            {
                // We recommend to activate HMAC validation in the webhooks for security reasons
                try
                {
                if (hmacValidator.IsValidHmac(container.NotificationItem, _hmac_key))
                {
                _logger.LogInformation($"Received webhook with event::\n" +
                    $"Merchant Reference ::{container.NotificationItem.MerchantReference} \n" +
                    $"PSP Reference ::{container.NotificationItem.PspReference} \n" +
                    $"status::{container.NotificationItem.EventCode}"
                );

                    }
                    else
                    {
                        _logger.LogError($"Received webhook with event::\n" +
                   $"Merchant Reference ::{container.NotificationItem.MerchantReference} \n" +
                   $"PSP Reference ::{container.NotificationItem.PspReference} \n" +
                   $"status::{container.NotificationItem.EventCode}"
                );
                        _logger.LogError($"HMAC key sent:{container.NotificationItem.AdditionalData["hmacSignature"]}");
                        _logger.LogError($"Error while validating HMAC Key");

                    }
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error while calculating HMAC signature::\n{e}\n");
                    throw;
                }
            }
            
            return "[accepted]";
            
            //return $"{ notificationRequest.NotificationItemContainers[0].NotificationItem.Success}";




        }

    }

}