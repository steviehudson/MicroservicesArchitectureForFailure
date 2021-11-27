using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetOrderDetails/{orderId}")]
        public async Task<ActionResult<Order>> 
            GetOrderDetails(int orderId)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            var response = await client.GetAsync("api/product/getproducts");
            var products = await response.Content.ReadAsStringAsync();

            return new Order() { Id = orderId, Products = products };   
        }
    }
}
