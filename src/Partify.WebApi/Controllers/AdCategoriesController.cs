using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.AdCategories;
using Partify.WebApi.Models.AdCategories;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers
{
    public class AdCategoriesController(IAdCategoryApiService adCategoryApiService) : BaseController
    {
        [HttpPost("create")]
        public async ValueTask<IActionResult> CreateAsync(AdCategoryCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await adCategoryApiService.CreateAsync(createModel)
            });
        }
        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, AdCategoryUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await adCategoryApiService.UpdateAsync(id, updateModel)
            });
        }
        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await adCategoryApiService.DeleteAsync(id)
            });
        }
        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await adCategoryApiService.GetByIdAsync(id)
            });
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync(
            [FromQuery] PaginationParams @params,
            [FromQuery] Filter filter,
            [FromQuery] string search = null)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await adCategoryApiService.GetAllAsync(@params, filter, search)
            });
        }
    }
}
