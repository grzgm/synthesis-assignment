using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json;
using LogicLayer.Models;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required, MinLength(3), MaxLength(15)]
        public string Username { get; set; }

        [BindProperty]
        [Required, RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{6,10}$", ErrorMessage = "Password mus have minimum 6 characters and maximum 10, at least 1 letter and 1 number")]
        public string Password { get; set; }
        public string mess { get; private set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //clientRepositroty = new ClientRepository();
            //clientMenager = new ClientManager(clientRepositroty);
            // here check in database if cerdentials are ok
            if (Username != null && Password != null)
            {
                Client client = null;
                try
                {
                    //client = clientMenager.LoginClient(Email, Password);
                }
                catch (Exception ex)
                {
                    mess = "Wrong credentials.";
                    return Page();
                }
                if (client != null)
                {
                    List<Claim> claims = new List<Claim>();
                    //claims.Add(new Claim(ClaimTypes.Name, client.Name));
                    //claims.Add(new Claim("Id", client.ID.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, client.Firstname));
                    claims.Add(new Claim("Id", client.Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Welcome");
                }
                else
                {
                    mess = "Wrong credentials.";
                    return Page();
                }
            }
            else
            {
                mess = "Wrong credentials.";
                return Page();
            }
        }
    }
}
