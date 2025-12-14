using RUAP_LV2_API.Models;
using System.Net.Http;
using System.Net.Http.Json;

var client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7007/");

var products = await client.GetFromJsonAsync<List<Product>>("api/products");

foreach (var product in products)
{
    Console.WriteLine($"{product.Id} - {product.Name} ({product.Category}) {product.Price}");
}

var newProduct = new Product
{
    Name = "Monitor",
    Category = "IT",
    Price = 1200
};

var response = await client.PostAsJsonAsync("api/products", newProduct);

if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Product successfully created.");
}
