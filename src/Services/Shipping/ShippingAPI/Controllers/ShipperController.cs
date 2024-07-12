using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShippingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        public ShipperController(IShipperService _shipperService)
        {
            this._shipperService = _shipperService;
        }
        
        // GET api/shipper
        [HttpGet]
        [Route("")]
        // [Authorize]
        public async Task<IActionResult> GetAllShipper()
        {
            var shippers = await _shipperService.GetAllShippers(); 
            if (!shippers.Any())
            {
                return NotFound(new { error = "No shippers found, please try later"});
            }
            return Ok(shippers);
        }
        
        // GET api/shipper/{id}
        [HttpGet]
        [Route("{id:int}", Name = "GetShipperDetails")]
        // [Authorize]
        public async Task<IActionResult> GetShipperDetails(int id)
        {
            var shipper = await _shipperService.GetShipperByIdAsync(id); 
            if (shipper == null)
            {
                return NotFound(new { errorMessage = "No shipper found for this id" });
            }

            return Ok(shipper);
        }
        
        // GET api/shipper/region/{id}
        [HttpGet]
        [Route("region/{region}")]
        // [Authorize]
        public async Task<IActionResult> GetShipperByRegion(string region)
        {
            var shippers = await _shipperService.GetShipperByRegion(region);
            if (shippers == null)
            {
                return NotFound(new { errorMessage = "No shipper found for this id" });
            }
            return Ok(shippers);
        }
        
        // POST api/shipper
        [HttpPost]
        [Route("")]
        // [Authorize]
        public async Task<IActionResult> CreateShipper(ShipperRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }
            
            var shipper = await _shipperService.AddShipperAsync(model);
            return CreatedAtAction
                ("GetShipperDetails", new { controller = "Shipper", id = shipper }, "Shipper Created");
        }
        
        // PUT api/shipper/id
        [HttpPut]
        [Route("{id:int}")]
        // [Authorize]
        public async Task<IActionResult> UpdateShipper(int id, ShipperRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }

            var response = new { Message = "Shipper is updated" };
            if (await _shipperService.UpdateShipperAsync(id, model) > 0)
            {
                return Ok(response);
            }
            return NoContent();
        }
        
        // DELETE api/shipper/{id}
        [HttpDelete]
        [Route("{id:int}")]
        // [Authorize]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            var shipper = await _shipperService.GetShipperByIdAsync(id);
            if (shipper == null)
            {
                return NotFound(new { errorMessage = "No shipper found for this id" });
            }
            
            var response = new { Message = "Shipper is deleted" };
            if (await _shipperService.DeleteShipperAsync(id) > 0)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}
