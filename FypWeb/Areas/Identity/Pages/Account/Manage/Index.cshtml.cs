// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Fyp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fyp.Utility;

namespace FypWeb.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            //public string Name { get; set; }

            //[DisplayName("Street Address")]
            //public string? StreetAddress { get; set; }

            //public string? Nationality { get; set; }

            //[DisplayName("IC Number")]
            //public string? IcNumber { get; set; }

            //public string? Gender { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Input = new InputModel();

            //var nama =  user.Name;
            //var streetAddress = user.StreetAddress;
            //var nationality = user.Nationality;
            //var icNumber = user.IcNumber;
            //var gender = user.Gender;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                //Name = nama,
                //StreetAddress = streetAddress,
                //Nationality = nationality,
                //IcNumber = icNumber,
                //Gender = gender
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //var applicationUser = user as ApplicationUser; // Casting IdentityUser to ApplicationUser
            //if (applicationUser == null)
            //{
            //    // Handle the case where the user is not an ApplicationUser
            //    return NotFound("User is not an ApplicationUser.");
            //}

            await LoadAsync(user); // Pass the ApplicationUser object to LoadAsync
            return Page();
        }



        //public async Task<IActionResult> OnGetAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    await LoadAsync(user);
        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User) as ApplicationUser;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //var currentname = user.Name;
            //if (Input.Name != currentname)
            //{
            //    user.Name = Input.Name;

            //    var updateResult = await _userManager.UpdateAsync(user);
            //    if (!updateResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to change IC Number.";
            //        return RedirectToPage();
            //    }
            //}

            //var currentAddress = user.StreetAddress; 
            //if (Input.StreetAddress != currentAddress)
            //{
            //    user.StreetAddress = Input.StreetAddress;

            //    var updateResult = await _userManager.UpdateAsync(user);
            //    if (!updateResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to change Street Address.";
            //        return RedirectToPage();
            //    }
            //}

            //var currentNationality = user.Nationality; // Get the current user's nationality

            //if (Input.Nationality != currentNationality) // Check if the input nationality is different
            //{
            //    user.Nationality = Input.Nationality; // Update the user's nationality

            //    var updateResult = await _userManager.UpdateAsync(user);
            //    if (!updateResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to change nationality.";
            //        return RedirectToPage();
            //    }
            //}


            //var currgender = user.Gender;
            //if (Input.Gender != currgender)
            //{
            //    user.Gender = Input.Gender;

            //    var updateResult = await _userManager.UpdateAsync(user);
            //    if (!updateResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to change IC Number.";
            //        return RedirectToPage();
            //    }
            //}

            //var currentic = user.IcNumber;
            //if (Input.IcNumber != currentic)
            //{
            //    user.IcNumber = Input.IcNumber;

            //    var updateResult = await _userManager.UpdateAsync(user);
            //    if (!updateResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to change IC Number.";
            //        return RedirectToPage();
            //    }
            //}


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
