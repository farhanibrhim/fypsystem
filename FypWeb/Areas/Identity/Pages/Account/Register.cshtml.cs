// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Fyp.DataAccess.Data;
using Fyp.DataAccess.Repository.IRepository;
using Fyp.Models;
using Fyp.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;


namespace FypWeb.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork,
            ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _db = db;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string? Role {  get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList {  get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            [DisplayName("Street Address")]
            public string? StreetAddress { get; set; }

            [Required]
            public string? Nationality { get; set; }

            [Required]
            [DisplayName("IC Number")]
            public string? IcNumber { get; set; }

            [Required]
            public string? Gender { get; set; }

            [Required]
            [DisplayName("Phone Number")]
            public string? PhoneNumber { get; set; }

            //public int? LecturerId { get; set; }
            //[ValidateNever]
            //public IEnumerable<SelectListItem> LecturerList { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {

            if (!_roleManager.RoleExistsAsync(SD.Role_Student).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Student)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Evaluator)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Lecturer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Supervisor)).GetAwaiter().GetResult();
            }

            // Prepare input data for the Razor Page
            Input = new()
            {
                RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
                //,
                //LecturerList = _unitOfWork.Lecturer.GetAll().Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.Id.ToString()
                //})
            };

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.Name = Input.Name;
                user.PhoneNumber = Input.PhoneNumber;
                user.IcNumber = Input.IcNumber;
                user.StreetAddress = Input.StreetAddress;
                user.PhoneNumber = Input.PhoneNumber;
                user.Nationality = Input.Nationality;
                user.Gender = Input.Gender;

                // Create the ApplicationUser in the database first
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!String.IsNullOrEmpty(Input.Role))
                    {
                        switch (Input.Role)
                        {
                            case SD.Role_Lecturer:
                                var lecturer = new Pensyarah
                                {
                                    ApplicationUser = user,
                                    // Add other lecturer-specific properties as needed
                                };

                                // Save lecturer to the database
                                _db.Lecturers.Add(lecturer);
                                await _db.SaveChangesAsync();
                                break;
                            case SD.Role_Student:
                                var student = new Murid
                                {
                                    ApplicationUser = user
                                };

                                // Save student to the database
                                _db.Students.Add(student);
                                await _db.SaveChangesAsync();
                                break;
                            case SD.Role_Evaluator:
                                var evaluator = new Penilai
                                {
                                    // Add other lecturer-specific properties as needed
                                    ApplicationUser = user
                                };

                                // Save lecturer to the database
                                _db.Evaluators.Add(evaluator);
                                await _db.SaveChangesAsync();
                                break;
                            case SD.Role_Supervisor:
                                var supervisor = new Penyelia
                                {
                                    ApplicationUser = user
                                    // Add other lecturer-specific properties as needed
                                };

                                // Save lecturer to the database
                                _db.Supervisors.Add(supervisor);
                                await _db.SaveChangesAsync();
                                break;
                            // Add other cases for additional roles
                            default:

                                await _db.SaveChangesAsync();
                                break;
                        }
                    }

                    if (!String.IsNullOrEmpty(Input.Role))
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_Student);
                    }

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        if (Input.Role == SD.Role_Admin || Input.Role == SD.Role_Lecturer || Input.Role == SD.Role_Supervisor || Input.Role == SD.Role_Evaluator )
                        {
                            // Redirect admins to admin dashboard
                            return RedirectToAction("Index", "User", new { area = "Admin" });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            // Redirect students to student dashboard or homepage
                            return RedirectToAction("Index", "Home", new { area = "Student" });
                        }
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    returnUrl ??= Url.Content("~/");
        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //    if (ModelState.IsValid)
        //    {
        //        var user = CreateUser();

        //        await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
        //        await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
        //        user.Name = Input.Name;
        //        user.PhoneNumber = Input.PhoneNumber;
        //        user.IcNumber = Input.IcNumber;
        //        user.StreetAddress = Input.StreetAddress;
        //        user.PhoneNumber = Input.PhoneNumber;
        //        user.Nationality = Input.Nationality;
        //        user.Gender = Input.Gender;

        //        if (!String.IsNullOrEmpty(Input.Role))
        //        {
        //            switch (Input.Role)
        //            {
        //                case SD.Role_Lecturer:

        //                    var lecturer = new Lecturer
        //                    {
        //                        ApplicationUser = user,
        //                        Name = Input.Name,
        //                        StreetAddress = Input.StreetAddress,
        //                        Nationality = Input.Nationality,
        //                        IcNumber = Input.IcNumber,
        //                        Gender = Input.Gender
        //                        // Add other lecturer-specific properties as needed
        //                    };

        //                    // Save lecturer to the database
        //                    _db.Lecturers.Add(lecturer);
        //                    await _db.SaveChangesAsync();
        //                    break;
        //                case SD.Role_Student:
        //                    var student = new Fyp.Models.Student
        //                    {
        //                        Name = Input.Name,
        //                        StreetAddress = Input.StreetAddress,
        //                        Nationality = Input.Nationality,
        //                        IcNumber = Input.IcNumber,
        //                        Gender = Input.Gender,
        //                        ApplicationUser = user

        //                    };

        //                    // Save lecturer to the database
        //                    _db.Students.Add(student);
        //                    await _db.SaveChangesAsync();

        //                    break;
        //                case SD.Role_Evaluator:
        //                    var evaluator = new Evaluator
        //                    {
        //                        Name = Input.Name,
        //                        StreetAddress = Input.StreetAddress,
        //                        Nationality = Input.Nationality,
        //                        IcNumber = Input.IcNumber,
        //                        Gender = Input.Gender,
        //                        // Add other lecturer-specific properties as needed
        //                        ApplicationUser = user
        //                    };

        //                    // Save lecturer to the database
        //                    _db.Evaluators.Add(evaluator);
        //                    await _db.SaveChangesAsync();
        //                    break;
        //                case SD.Role_Supervisor:
        //                    var supervisor = new Supervisor
        //                    {
        //                        Name = Input.Name,
        //                        StreetAddress = Input.StreetAddress,
        //                        Nationality = Input.Nationality,
        //                        IcNumber = Input.IcNumber,
        //                        Gender = Input.Gender,
        //                        ApplicationUser = user
        //                        // Add other lecturer-specific properties as needed
        //                    };

        //                    // Save lecturer to the database
        //                    _db.Supervisors.Add(supervisor);
        //                    await _db.SaveChangesAsync();
        //                    break;
        //                case SD.Role_Committee:
        //                    var committee = new Committee
        //                    {
        //                        Name = Input.Name,
        //                        StreetAddress = Input.StreetAddress,
        //                        Nationality = Input.Nationality,
        //                        IcNumber = Input.IcNumber,
        //                        Gender = Input.Gender,
        //                        ApplicationUser = user
        //                        // Add other lecturer-specific properties as needed
        //                    };

        //                    // Save lecturer to the database
        //                    _db.Committees.Add(committee);
        //                    await _db.SaveChangesAsync();
        //                    break;
        //                // Add other cases for additional roles
        //                default:
        //                    break;
        //            }
        //        }

        //        var result = await _userManager.CreateAsync(user, Input.Password);

        //        if (result.Succeeded)
        //        {
        //            _logger.LogInformation("User created a new account with password.");

        //            if (!String.IsNullOrEmpty(Input.Role))
        //            {
        //                await _userManager.AddToRoleAsync(user, Input.Role);
        //            }
        //            else
        //            {
        //                await _userManager.AddToRoleAsync(user, SD.Role_Student);
        //            }

        //            var userId = await _userManager.GetUserIdAsync(user);
        //            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //            var callbackUrl = Url.Page(
        //                "/Account/ConfirmEmail",
        //                pageHandler: null,
        //                values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
        //                protocol: Request.Scheme);

        //            await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
        //                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //            if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //            {
        //                return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
        //            }
        //            else
        //            {
        //                if (Input.Role == SD.Role_Admin || Input.Role == SD.Role_Lecturer || Input.Role == SD.Role_Supervisor || Input.Role == SD.Role_Evaluator || Input.Role == SD.Role_Committee)
        //                {
        //                    // Redirect admins to admin dashboard
        //                    return RedirectToAction("Index", "User", new {area = "Admin"});
        //                }
        //                else
        //                {
        //                    // Redirect students to student dashboard or homepage
        //                    return RedirectToAction("Index", "Home", new { area = "Student" });
        //                }
        //            }
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return Page();
        //}


        //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //{
        //    returnUrl ??= Url.Content("~/");
        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //    if (ModelState.IsValid)
        //    {
        //        var user = CreateUser();

        //        await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
        //        await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
        //        user.Name = Input.Name;
        //        user.PhoneNumber = Input.PhoneNumber;
        //        user.IcNumber = Input.IcNumber;
        //        user.StreetAddress = Input.StreetAddress;
        //        user.PhoneNumber = Input.PhoneNumber;
        //        user.Nationality = Input.Nationality;
        //        user.Gender = Input.Gender;

        //        if (Input.Role == SD.Role_Lecturer)
        //        {
        //            user.LecturerId = Input.LecturerId;
        //        }

        //        var result = await _userManager.CreateAsync(user, Input.Password);

        //        if (result.Succeeded)
        //        {
        //            _logger.LogInformation("User created a new account with password.");

        //            if(!String.IsNullOrEmpty(Input.Role))
        //            {
        //                await _userManager.AddToRoleAsync(user, Input.Role);
        //            }
        //            else
        //            {
        //                await _userManager.AddToRoleAsync(user, SD.Role_Student);
        //            }

        //            var userId = await _userManager.GetUserIdAsync(user);
        //            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //            var callbackUrl = Url.Page(
        //                "/Account/ConfirmEmail",
        //                pageHandler: null,
        //                values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
        //                protocol: Request.Scheme);

        //            await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
        //                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //            if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //            {
        //                return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
        //            }
        //            else
        //            {
        //                await _signInManager.SignInAsync(user, isPersistent: false);
        //                return LocalRedirect(returnUrl);
        //            }
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return Page();
        //}

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
