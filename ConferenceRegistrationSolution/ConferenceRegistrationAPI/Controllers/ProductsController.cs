using MongoDB.Bson;

namespace ConferenceRegistrationAPI.Controllers;

public class ProductsController : ControllerBase
{

    private readonly IProductsService _productsDomainService;

    public ProductsController(IProductsService productsDomainService)
    {
        _productsDomainService = productsDomainService;
    }

    [HttpGet("products/{id}")]
    public async Task<ActionResult> GetProduct(string id)
    {
        if (ObjectId.TryParse(id, out var _))
        {
            ProductInformationResponse response = await _productsDomainService.GetProductAsync(id);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
        else
        {
            return NotFound(); // BadRequest() 400
        }

    }

    [HttpGet("products")]
    public async Task<ActionResult> GetAllProductsAsync()
    {
        GetProductsReponse reponse = await _productsDomainService.GetAllProductsAsync();
        return Ok(reponse);
    }
}
