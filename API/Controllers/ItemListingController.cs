using System.Security.Claims;
using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/item-listing")]
    public class ItemListingController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ItemListingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemListingDto>>> GetAllItems()
        {
            // For the sake of time I'm not doing any pagination
            var items = await _unitOfWork.ItemListingRepository.GetAllItemsAsync();

            return Ok(items);
        }

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
    }
}
