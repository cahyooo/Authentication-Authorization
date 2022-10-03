﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNET_WebApplication.Repositories.Data;
using SIBKMNET_WebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApplication.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            // ambil data dari database sesuai dengan email dan pass
            //if (ModelState.IsValid)
            //{
                var data = accountRepository.Login(login);
                if (data != null)
                {
                    // inisialisasi nilai pada session
                    HttpContext.Session.SetString("Role", data.Role);
                    return RedirectToAction("Index", "Province");
                }
                return View();
            //}
            return View();
        }


    }
}
