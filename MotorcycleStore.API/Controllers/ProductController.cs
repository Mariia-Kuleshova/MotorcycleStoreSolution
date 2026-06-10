using Microsoft.AspNetCore.Mvc;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Common;
using MotorcycleStore.Domain.Models;

namespace MotorcycleStore.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".webp"];
    private const long MaxFileSizeBytes = 5 * 1024 * 1024;

    private readonly IProductService _productService;
    private readonly IWebHostEnvironment _environment;

    public ProductController(IProductService productService, IWebHostEnvironment environment)
    {
        _productService = productService;
        _environment = environment;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product is null)
            return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Додає фото до колекції (multipart/form-data, поле "file"). URL зберігаються в ImageUrl через ';'.
    /// </summary>
    [HttpPost("{id:int}/image")]
    [RequestSizeLimit(MaxFileSizeBytes)]
    public async Task<ActionResult<Product>> UploadImage(int id, IFormFile? file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не передано.");

        if (file.Length > MaxFileSizeBytes)
            return BadRequest("Файл завеликий (макс. 5 МБ).");

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(extension))
            return BadRequest("Дозволені формати: jpg, jpeg, png, webp.");

        var product = await _productService.GetByIdAsync(id);
        if (product is null)
            return NotFound();

        var imagesDirectory = Path.Combine(_environment.WebRootPath, "images", "products");
        Directory.CreateDirectory(imagesDirectory);

        var fileName = $"{id}_{Guid.NewGuid():N}{extension}";
        var filePath = Path.Combine(imagesDirectory, fileName);
        var publicUrl = $"/images/products/{fileName}";

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        product.ImageUrl = ProductImageUrls.Append(product.ImageUrl, publicUrl);
        var quantity = product.Inventory?.Quantity ?? 0;
        await _productService.UpdateAsync(product, quantity);

        var updated = await _productService.GetByIdAsync(id);
        return Ok(updated);
    }
}
