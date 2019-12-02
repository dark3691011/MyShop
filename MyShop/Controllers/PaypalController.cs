using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraintreeHttp;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using PayPal.Core;
using PayPal.v1.Payments;
using MyShop.Helpers;
using MyShop.ViewModels;

namespace MyShopK6.Controllers
{
    public class PaypalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<CartItem> Cart
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("Cart");
                if (data == null)
                {
                    data = new List<CartItem>();
                }

                return data;
            }
        }
        public async Task<IActionResult> Checkout()
        {
            //SandboxEnvironment(clientId, clientSerect)
            string clientId = "AYOwjSPbuM8boAckmyHBzPF3fS5jkqsE6-i-fd_2Y66bMFW7t9miYPklGgcNAdXweQa4ijsjCRQnElL1";
            string clientSecret = "EL485ImsKFuaWVHj8YqVRNwzc1-q8xsmFMaDnFyvBTwH5JT4zqyGe7dLT9F4-Q64-ebEaix79UYxnO4H";
            var environment = new SandboxEnvironment(clientId,clientSecret);
            var client = new PayPalHttpClient(environment);

            double UsdToVnd = 23211.67;

            //Đọc thông tin đơn hàng từ Session
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };

            double tongTien = Cart.Sum(p => p.TotalPrice)/UsdToVnd;
            foreach (var item in Cart)
            {
                itemList.Items.Add(new Item()
                {
                    Name = item.Product.ProductName,
                    Currency = "USD",
                    Price = (item.Product.UnitPrice/UsdToVnd).ToString("0.00"),
                    Quantity = item.Amount.ToString(),
                    Sku = "sku",
                    Tax = "0"
                });
            }
            

            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = tongTien.ToString("0.00"),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = tongTien.ToString("0.00")
                            }
                        },
                        ItemList = itemList,
                        Description = "Don hang A" ,
                        InvoiceNumber = DateTime.Now.Ticks.ToString()
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = "http://localhost:44370/paypal/fail",
                    ReturnUrl = "https://localhost:44370/paypal/Execute"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }

                return Redirect(paypalRedirectUrl);

            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                string a = tongTien.ToString();

                return Content(a);
            }
        }
        public async Task<IActionResult> Execute(string paymentId, string PayerId)
        {
            //SandboxEnvironment(clientId, clientSerect)
            string clientId = "AYOwjSPbuM8boAckmyHBzPF3fS5jkqsE6-i-fd_2Y66bMFW7t9miYPklGgcNAdXweQa4ijsjCRQnElL1";
            string clientSecret = "EL485ImsKFuaWVHj8YqVRNwzc1-q8xsmFMaDnFyvBTwH5JT4zqyGe7dLT9F4-Q64-ebEaix79UYxnO4H";
            var environment = new SandboxEnvironment(clientId, clientSecret);
            var client = new PayPalHttpClient(environment);


            PaymentExecuteRequest request = new PaymentExecuteRequest(paymentId);

            request.RequestBody(new PaymentExecution()
            {
                PayerId = PayerId
            });

            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();
                return RedirectToAction("Success");
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                return RedirectToAction("Fail");
            }

        }
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Fail()
        {
            return View();
        }
    }
}