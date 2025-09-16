using CustomerLeadImageUpload.Business.Models.DTOs;
using CustomerLeadImageUpload.Business.Services;
using CustomerLeadImageUpload.Business.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerLeadImageUpload.API.Controllers
{
  [Route("api/customers")]
  public class CustomerController : Controller
  {
    private readonly ICustomerService _customerService;
    public CustomerController(
            ICustomerService customerService
            )
    {
      _customerService = customerService;
    }
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetImages()
    {
      var customers = await _customerService.GetCustomerAsync();
      return Ok(CustomerLeadImageUploadResultDTO<List<CustomerDTO>>.Success(customers));
    }
  }
}
