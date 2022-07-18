﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _client_key;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client_key = "test_DT7EVPYLGNDHXI3QUMU63DAQNYIO45DI";
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Stripe()
        {
            return View();
        }
        public IActionResult Preview(string id)
        {
           ViewBag.PaymentMethod = id;
            return View();
        }

        public IActionResult Checkout(string id)
        {
            ViewBag.PaymentMethod = id;
            ViewBag.ClientKey = _client_key;
            ViewBag.amount = 10;
            ViewBag.currency = "USD";

            return View();
        }

        public IActionResult Redirect()
        {
            ViewBag.ClientKey = _client_key;
            return View();
        }
        public IActionResult Subscription(string id)
        {
            ViewBag.ClientKey = _client_key;
            ViewBag.PaymentMethod = id;
            ViewBag.amount = 10;
            ViewBag.currency = "USD";
            return View();
        }
       
        [HttpGet("Home/Result/{status}")]
        public IActionResult Result(string status, [FromQuery(Name = "reason")] string refusalReason)
        {
            string msg;
            string img;
            switch (status)
            {
                case "pending":
                    msg = "Your order has been received! Payment completion pending.";
                    img = "success";
                    break;
                case "failed":
                    msg = "The payment was refused. Please try a different payment method or card.";
                    img = "failed";
                    break;
                case "error":
                    msg = $"Error! Reason: {refusalReason}";
                    img = "failed";
                    break;
                default:
                    msg = "Your order has been successfully placed.";
                    img = "success";
                    break;
            }
            ViewBag.Status = status;
            ViewBag.Msg = msg;
            ViewBag.Img = img;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }



    }
}
