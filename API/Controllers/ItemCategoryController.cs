using System.Security.Claims;
using API.Data;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/categories")]
    public class ItemCategoryController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCategoryDto>>> GetCategories()
        {
            var categories = await _unitOfWork.ItemCategoryRepository.GetAllCategories();

            return Ok(categories);
        }
    }
}
