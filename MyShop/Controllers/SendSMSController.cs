﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EC.SecurityService.Common;
using EC.SecurityService.Services;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Services;
using Newtonsoft.Json;

namespace MyShop.Controllers
{
    public class SendSMSController : Controller
    {
        private readonly IAuthy _authy;
        private readonly ISmsService _smsService;
        public readonly MyDbContext _context;
        public SendSMSController(IAuthy authy, MyDbContext context, ISmsService smsService)
        {
            _authy = authy;
            _context = context;
            _smsService = smsService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> RegisterUser(string phone)
        {
            UserModel userModel = new UserModel
            {
                Email = "agilehcmue@gmail.com",
                CountryCode = "+84",
                PhoneNumber = phone
            };

            var authyId = await _authy.RegisterUserAsync(userModel).ConfigureAwait(false);

            if (string.IsNullOrEmpty(authyId))
            {
                return Json(new { success = false });
            }
            else
            {
                //update authyId in database
                Customer customer = _context.customers.SingleOrDefault(p => p.PhoneNumber == phone);

                if (customer != null)
                {
                    customer.AuthyId = authyId;
                    _context.SaveChanges();
                }

                return Json(new { success = true, authyId = authyId });
            }
        }

        public async Task<IActionResult> Send(string phone)
        {
            //Phone ==> read DB to indicate AuthyId
            Customer customer = _context.customers.SingleOrDefault(kh => kh.PhoneNumber == phone);

            if (customer != null && !string.IsNullOrEmpty(customer.AuthyId))
            {
                var sendSMSResponse = await _authy.SendSmsAsync(customer.AuthyId).ConfigureAwait(false);

                if (sendSMSResponse.StatusCode == HttpStatusCode.OK)
                {
                    var smsVerificationSucceedObject = JsonConvert.DeserializeObject<AccessCodeVerifyResult>(await sendSMSResponse.Content.ReadAsStringAsync());
                    if (smsVerificationSucceedObject.Success)
                    {
                        //Send SMS success
                        return Content($"Gửi token thành công tới {phone}");
                    }
                    else
                    {
                        //Fail
                        return Content($"Có lỗi gửi tin nhắn tới {phone}");
                    }
                }
            }

            return Content($"Không có khách hàng nào có điện thoại: {phone}");
        }

        public async Task<IActionResult> VerifyToken(string phone, string token)
        {
            Customer khachHang = _context.customers.SingleOrDefault(kh => kh.PhoneNumber == phone);

            if (khachHang != null && !string.IsNullOrEmpty(khachHang.AuthyId))
            {
                var validationResult = await _authy.VerifyTokenAsync(khachHang.AuthyId, token).ConfigureAwait(false);

                if (validationResult.Succeeded)
                {
                    khachHang.PhoneNumberConfirmed = true;
                    _context.SaveChanges();

                    return Json(new
                    {
                        Success = true,
                        Message = $"Your mobile phone {phone} verify successfully."
                    });
                }
            }
            return Content($"Không có khách hàng nào có điện thoại: {phone}");
        }

        public async Task<IActionResult> SendSms(string phone, string content)
        {
            SmsMessage model = new SmsMessage
            {
                NameTo = "Hien",
                NumberFrom = "+84854774690",
                NumberTo = "+84989366990",
                Body = "This is SMS from EC HCMUE",
                Greeting = "HCMUEr",
                Signature = "HIENLTH"
            };

            var result = await _smsService.Send(model);

            return Json(result);
        }
    }
}