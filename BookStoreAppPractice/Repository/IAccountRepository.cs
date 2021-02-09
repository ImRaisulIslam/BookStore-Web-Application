using BookStoreAppPractice.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel);

          Task<SignInResult> PasswordSign(SignInModel signInModel);

        Task SignOutAsync();
    }
}