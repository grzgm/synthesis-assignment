using DataAccessLayer;
using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApp.Pages
{
	public class RegisterModel : PageModel
	{
		IClientRepository clientRepository;
		IClientManager clientManager;


		[BindProperty]
		public Client Client { get; set; }
        [BindProperty]
        public bool BonusCard { get; set; }
        public string mess { get; private set; }
		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost()
		{
            // here check in database if cerdentials are ok
            if (ModelState.IsValid)
            {
                clientRepository = new ClientRepository();
                clientManager = new ClientManager(clientRepository);
                try
                {
                    if(BonusCard)
                    {
                        Client.BonusCard = new BonusCard(Client.Id, 15);
                    }
                    if(!clientManager.CreateClient(Client))
                    {
                        mess = "This User already exists.";
                        return Page();
                    }
                    else
					{
						Client = clientManager.ReadClientByUsernamePassword(Client.Username, Client.Password);
					}

                    List<Claim> claims = new List<Claim>();
					claims.Add(new Claim("Id", Client.Id.ToString()));
					claims.Add(new Claim(ClaimTypes.Name, Client.Firstname));
					claims.Add(new Claim("Lastname", Client.Lastname));
					claims.Add(new Claim("Email", Client.Email));
					claims.Add(new Claim("Username", Client.Username));

					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return RedirectToPage("/Index");
                }
                catch (Exception ex)
                {
                    mess = ex.Message;
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
