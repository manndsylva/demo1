using BookStore.API.Models;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Repositories
{
    public interface IAccountRepo
    {   
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);

        Task<string> LoginAsync(SignInModel signInModel);
        Task<string> FindUserByEmailAsync(string? email);
    }
    
}