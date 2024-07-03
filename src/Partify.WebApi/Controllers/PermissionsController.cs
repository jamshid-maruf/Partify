using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.Permissions;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.Permissions;

namespace Partify.WebApi.Controllers
{
    public class PermissionsController(IPermissionApiService permissionApiService) : BaseController
    {
        [HttpPost("create")]
        public async ValueTask<IActionResult> CreateAsync(PermissionCreateModel createModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await permissionApiService.CreateAsync(createModel)
            });
        }
        [HttpPut("{id:long}")]
        public async ValueTask<IActionResult> PutAsync(long id, PermissionUpdateModel updateModel)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await permissionApiService.UpdateAsync(id, updateModel)
            });
        }
        [HttpDelete("{id:long}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await permissionApiService.DeleteAsync(id)
            });
        }
        [HttpGet("{id:long}")]
        public async ValueTask<IActionResult> GetAsync(long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await permissionApiService.GetByIdAsync(id)
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
                Data = await permissionApiService.GetAllAsync(@params, filter, search)
            });
        }
    }
}
