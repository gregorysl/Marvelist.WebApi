using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Marvelist.API.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Marvelist.Entities;
using Marvelist.Service;

namespace Marvelist.API.Controllers
{
    public class AccountController : ApiController
    {

        private readonly IUserService _userService;

        private readonly UserManager<ApplicationUser> userManager;
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            this.userManager = userManager;

            //Todo: This needs to be moved from here.
            this.userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
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
                    ApplicationUser user = new ApplicationUser();
                    AutoMapper.Mapper.Map(viewModel, user);

                    var identityResult = await userManager.CreateAsync(user, viewModel.Password);

                    if (identityResult.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Member");
                        return Ok();
                    }
                    else
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError(error,error);
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

        [Route("api/Account/{show}/show")]
        [HttpGet]
        [OverrideAuthorization]
        public async Task<IHttpActionResult> Getasd(string show)
        {
            var asd = _userService.GetByEmail("gregorysl@gmail.com");
            return Ok(show);

        }
        #region Private methods
        #region SignInAsync
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            try
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion SignInAsync
        #endregion SignInAsync
    }
}