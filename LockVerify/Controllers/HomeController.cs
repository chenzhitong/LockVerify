using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LockVerify.Models;
using Neo;
using Neo.Wallets;
using Neo.Core;
using System.Numerics;

namespace LockVerify.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Verify(string script)
        {
            if(String.IsNullOrEmpty(script))
                return View("Index");
            if (script.Length != 120)
            {
                ViewBag.Error = "script lenth error!";
                return View("Index");
            }
            if (script.Substring(0, 2) != "21" || script.Substring(68, 2) != "04")
            {
                ViewBag.Error = "script code error!";
                return View("Index");
            }
            if (script.Substring(0, 2) != "21" || script.Substring(68, 2) != "04")
            {
                ViewBag.Error = "script code error!";
                return View("Index");
            }
            if (script.Substring(80, 40) != "a447d01b613011d6ca8cc8092d1700084de8ccd3")
            {
                ViewBag.Error = "script app call error!";
                return View("Index");
            }
            var time = script.Substring(70, 8).HexToBytes().ToArray();

            var timestamp = new BigInteger(time);
            ViewBag.Pubkey = script.Substring(2, 66);
            ViewBag.Time = ((uint)timestamp).ToDateTime();
            ViewBag.ScriptHash = script.HexToBytes().ToScriptHash();
            ViewBag.Address = Wallet.ToAddress(ViewBag.ScriptHash);
            return View("Index");
        }
    }
}
