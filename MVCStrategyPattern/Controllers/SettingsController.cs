using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBaseProject.Models;
using MVCStrategyPattern.Models;

namespace MVCStrategyPattern.Controllers;

[Route("[controller]")]
[Authorize]
public class SettingsController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> ignInManager)
    {
        _userManager = userManager;
        _signInManager = ignInManager;
    }


    public IActionResult Index()
    {
        Settings settings = new();
        var userClaims = User.Claims.Where(c => c.Type == Settings.claimDatabaseType).FirstOrDefault();

        if (userClaims != null)
        {
            settings.DatabaseType = (EDatabaseType)int.Parse(User.Claims.First(c => c.Type == Settings.claimDatabaseType).Value);
        }
        else
        {
            settings.DatabaseType = settings.DefaultDatabaseType;
        }
        return View(settings);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeDatabase(int databaseType)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var newClaim = new Claim(Settings.claimDatabaseType, databaseType.ToString());

        var userClaims = await _userManager.GetClaimsAsync(user);

        var userDatabaseTypeClaim = userClaims.FirstOrDefault(c => c.Type == Settings.claimDatabaseType);

        if (userDatabaseTypeClaim != null)
        {
            await _userManager.ReplaceClaimAsync(user, userDatabaseTypeClaim, newClaim);
        }
        else
        {
            await _userManager.AddClaimAsync(user, newClaim);
        }

        await _signInManager.SignOutAsync();
        userClaims = await _userManager.GetClaimsAsync(user);
        await _signInManager.SignInWithClaimsAsync(user, true, userClaims);

        return RedirectToAction(nameof(Index));
    }



}
