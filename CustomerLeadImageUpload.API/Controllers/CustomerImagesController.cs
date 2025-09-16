using CustomerLeadImageUpload.Business.Models.DTOs;
using CustomerLeadImageUpload.Business.Models.DTOs.PageSort;
using CustomerLeadImageUpload.Business.Models.RMs;
using CustomerLeadImageUpload.Business.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerLeadImageUpload.API.Controllers
{
  [Route("api/customerimages")]
  public class CustomerImagesController : Controller
  {
    private readonly ICustomerImageService _customerImageService;
    public CustomerImagesController(
            ICustomerImageService customerImageService
            )
    {
      _customerImageService = customerImageService;
    }
    [HttpPost("upload")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Upload([FromForm] UploadCustomerImagesRM model)
    {
      try
      {
        var images = await _customerImageService.UploadImagesAsync(model);
        return Ok(CustomerLeadImageUploadResultDTO<List<CustomerImageDTO>>.Success(images));
      }
      catch (ArgumentException ex) 
      {
        return BadRequest(CustomerLeadImageUploadResultDTO.Error(ex.Message));
      }
      catch (Exception ex)
      {
        return StatusCode(500, CustomerLeadImageUploadResultDTO.Error("Internal server error"));
      }
    }

    [HttpGet("{customerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetImages(int customerId)
    {
      var images = await _customerImageService.GetImagesByCustomerIdAsync(customerId);
      return Ok(CustomerLeadImageUploadResultDTO<List<CustomerImageDTO>>.Success(images));
    }

    [HttpDelete("{imageId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int imageId)
    {
      await _customerImageService.DeleteImageAsync(imageId);
      return Ok(CustomerLeadImageUploadResultDTO.Success());
    }
  }
}
