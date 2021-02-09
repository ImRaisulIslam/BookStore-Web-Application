using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAppPractice.Models;
using BookStoreAppPractice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAppPractice.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }


        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel signUpUserModel)
        
        {
            if (ModelState.IsValid)
            {
            var result =   await _accountRepository.CreateUserAsync(signUpUserModel);

                if( !result.Succeeded)
                {
                    foreach (var erroMassege in result.Errors)
                    {
                        ModelState.AddModelError("", erroMassege.Description);
                    }

                    return View();
                }
                //code
                ModelState.Clear();
            }
            return View();
        }
        [Route("signin")]
        public IActionResult SignIn()
        {
            return View();
        }


        [Route("signin")]

        [HttpPost]
        public async Task<IActionResult>  SignIn(SignInModel signInModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSign(signInModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invaid Crediantials");
            }
            return View();
        }

        [Route("signout")]
        public async Task<IActionResult>  SignOut()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}