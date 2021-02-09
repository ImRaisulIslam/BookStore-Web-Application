using BookStoreAppPractice.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;

        public AccountRepository(UserManager<ApplicationUserModel> userManager , SignInManager<ApplicationUserModel> signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel)
        {
            var user = new ApplicationUserModel()
            {
                Email = signUpUserModel.Email,
                UserName = signUpUserModel.Email,
                FirstName =signUpUserModel.FirstName,
                LastName = signUpUserModel.LastName
                

            };

            var result = await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSign(SignInModel signInModel)
        {

          var result =  await _signInManager.PasswordSignInAsync(signInModel.EmailAddress, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }
        
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            


        }

    }
}
