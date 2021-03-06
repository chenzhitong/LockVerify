﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Neo;
using Neo.Wallets;
using System.Numerics;
using Neo.SmartContract;

namespace LockVerify.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(string script)
        {
            if (String.IsNullOrEmpty(script))
                return View();
            if (script.Length != 120)
            {
                ViewBag.Error = "script lenth error!";
                return View();
            }
            if (script.Substring(0, 2) != "21" || script.Substring(68, 2) != "04")
            {
                ViewBag.Error = "script code error!";
                return View();
            }
            if (script.Substring(0, 2) != "21" || script.Substring(68, 2) != "04")
            {
                ViewBag.Error = "script code error!";
                return View();
            }
            if (script.Substring(80, 40) != "a447d01b613011d6ca8cc8092d1700084de8ccd3")
            {
                ViewBag.Error = "script app call error!";
                return View();
            }
            var time = script.Substring(70, 8).HexToBytes().ToArray();

            var timestamp = new BigInteger(time);
            ViewBag.Pubkey = script.Substring(2, 66);
            ViewBag.Time = ((uint)timestamp).ToDateTime();
            ViewBag.ScriptHash = script.HexToBytes().ToScriptHash();
            ViewBag.Address = ViewBag.ScriptHash.ToAddress();
            return View();
        }
    }
}
