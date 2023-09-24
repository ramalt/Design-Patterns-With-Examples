using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBaseProject.Models;
using MVCStrategyPattern.Models;
using MVCStrategyPattern.Repository;

namespace MVCStrategyPattern.Controllers;

// [Route("[controller]")]
[Authorize]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly UserManager<AppUser> _userManager;
    public ProductController(IProductRepository productRepository, UserManager<AppUser> userManager)
    {
        _productRepository = productRepository;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var userProducts = await _productRepository.GetAllByUserIdAsync(user.Id);
        return View(userProducts);
    }

    // [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // [HttpGet]
    public async Task<IActionResult> Detail(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
            return NotFound();

        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
            return NotFound();


        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return NotFound();


        return View(product);
    }

    //-----------------------

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock,UserId,CreatedAt")] Product product)
    {
        if (product != null)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            product.UserId = user.Id;
            product.CreatedAt = DateTime.Now;
            await _productRepository.CreateAsync(product);

            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, Product product)
    {
        if (id != product.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                await _productRepository.UpdateAsync(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var product = await _productRepository.GetByIdAsync(id);


        await _productRepository.DeleteAsync(product);
        return RedirectToAction(nameof(Index));
    }


    private bool ProductExists(string id)
    {
        return _productRepository.GetByIdAsync(id) != null;
    }




}

