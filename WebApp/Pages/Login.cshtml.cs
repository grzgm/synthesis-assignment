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
using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        IClientRepository clientRepository;
        IClientManager clientManager;


        [BindProperty]
        [Required, MinLength(3), MaxLength(20), RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Username must consist only of letters and numbers")]
		public string Username { get; set; }

        [BindProperty]
        [Required, RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Password must consist only of letters and numbers")]
        public string Password { get; set; }
        public string mess { get; private set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
			clientRepository = new ClientRepository();
			clientManager = new ClientManager(clientRepository);
            // here check in database if cerdentials are ok
            if (Username != null && Password != null)
            {
                Client client = null;
                try
                {
                    client = clientManager.ReadClientByUsernamePassword(Username, Password);
                }
                catch (Exception ex)
                {
                    mess = "Wrong credentials.";
                    return Page();
                }
                if (client != null)
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, client.Firstname));
                    claims.Add(new Claim("Lastname", client.Lastname));
                    claims.Add(new Claim("Id", client.Id.ToString()));

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Index");
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
