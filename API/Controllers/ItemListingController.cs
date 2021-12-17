using System.Security.Claims;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/item-listing")]
    public class ItemListingController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemListingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemListingDto>>> GetItemsFromCategory([FromQuery] string category = null)
        {
            if (String.IsNullOrEmpty(category)) return NotFound();

            // For the sake of time I'm not doing any pagination
            var items = await _unitOfWork.ItemListingRepository.GetAllItemsAsync(category);

            return Ok(items);
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult<ItemListingDto>> GetItemFromId(int itemId = -1)
        {
            if (itemId < 1) return NotFound();

            var item = await _unitOfWork.ItemListingRepository.GetItemFromIdAsync(itemId);

            return item;
        }

        [Authorize]
        [HttpPost("add-new-item")]
        public async Task<ActionResult<ItemListingDto>> AddItemListing([FromForm] AddItemListingDto dto)
        {
            try
            {
                var user = await _unitOfWork.GetUserByIdAsync(User.GetUserId());
                var result = await _unitOfWork.ItemListingRepository.AddNewItemAsync(dto, user.Id);
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{itemId}")]
        public async Task<ActionResult> DeleteItem(int itemId = -1)
        {
            try
            {
                if (itemId < 1) return BadRequest();

                var user = await _unitOfWork.GetUserByIdAsync(User.GetUserId());
                var result = await _unitOfWork.ItemListingRepository.ArchiveItemAsync(itemId, user.Id);

                if (result) return Ok();
            }
            catch (Exception ex)
            {

            }

            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
}
