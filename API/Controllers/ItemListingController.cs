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
        public ItemListingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("add-new-item")]
        public async Task<ActionResult<ItemListingDto>> AddItemListing(AddItemListingDto newItem)
        {
            var itemListing = _mapper.Map<ItemListing>(newItem);

            return new ItemListingDto { };
        }
    }
}
