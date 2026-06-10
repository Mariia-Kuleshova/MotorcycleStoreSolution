using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace MotorcycleStore.UI.WinForms.Services;

public class ProductImageApiClient
{
    private readonly HttpClient _httpClient;

    public ProductImageApiClient(IConfiguration configuration)
    {
        var baseUrl = configuration["Api:BaseUrl"] ?? "http://localhost:5100";
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl.TrimEnd('/') + "/"),
            Timeout = TimeSpan.FromMinutes(2),
        };
    }

    public async Task<(bool Success, string Message)> UploadProductImageAsync(int productId, string filePath)
    {
        try
        {
            await using var stream = File.OpenRead(filePath);
            using var content = new MultipartFormDataContent();
            using var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetContentType(filePath));
            content.Add(fileContent, "file", Path.GetFileName(filePath));

            var response = await _httpClient.PostAsync($"api/products/{productId}/image", content);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return (true, "Фото завантажено.");

            return (false, $"Помилка API ({(int)response.StatusCode}): {body}");
        }
        catch (Exception ex)
        {
            return (false, $"Не вдалося підключитися до API ({_httpClient.BaseAddress}). Переконайтеся, що MotorcycleStore.API запущено.\n{ex.Message}");
        }
    }

    private static string GetContentType(string filePath)
    {
        var extension = Path.GetExtension(filePath).ToLowerInvariant();
        return extension switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".webp" => "image/webp",
            _ => "application/octet-stream",
        };
    }
}
