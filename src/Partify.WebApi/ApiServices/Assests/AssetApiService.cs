using AutoMapper;
using Partify.Service.Services.Assets;
using Partify.WebApi.Models.Assets;

namespace Partify.WebApi.ApiServices.Assests
{
    public class AssetApiService(IAssetService assetService, IMapper mapper) : IAssetApiService
    {
        public async ValueTask<bool> DeleteAsync(long id)
        {
            return await assetService.DeleteAsync(id);
        }

        public async ValueTask<AssetViewModel> GetByIdAsync(long id)
        {
            var result = await assetService.GetByIdAsync(id);
            return mapper.Map<AssetViewModel>(result);
        }

        public async ValueTask<AssetViewModel> UploadAsync(IFormFile file, string fileType)
        {
            var createdAsset = await assetService.UploadAsync(file, fileType);
            return mapper.Map<AssetViewModel>(createdAsset);
        }
    }
}
