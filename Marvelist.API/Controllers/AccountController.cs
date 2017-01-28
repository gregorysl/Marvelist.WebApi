using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Marvelist.Entities;
using Marvelist.Entities.ViewModels;

namespace Marvelist.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            _userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        [Route("api/Register/")]
        [HttpPost]
        [OverrideAuthorization]
        public async Task<IHttpActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new ApplicationUser();
                    AutoMapper.Mapper.Map(viewModel, user);

                    var identityResult = await _userManager.CreateAsync(user, viewModel.Password);

                    if (identityResult.Succeeded)
                    {
                        _userManager.AddToRole(user.Id, "Member");
                        return Ok();
                    }
                    else
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError(error, error);
                        }

                        return BadRequest(ModelState);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            try
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity =
                    await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() {IsPersistent = isPersistent}, identity);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}