
namespace EcommerceApp.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var apiUrl = categoryUrl == null ? "api/product" : $"api/product/{categoryUrl}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>(apiUrl);

            Products = result?.Data ?? Products;

            ProductsChanged.Invoke();

        }
    }
}
