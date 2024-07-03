using Partify.WebApi.Models.Assets;

namespace Partify.WebApi.ApiServices.Assests
{
    public interface IAssetApiService
    {
        ValueTask<AssetViewModel> UploadAsync(IFormFile file, string fileType);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<AssetViewModel> GetByIdAsync(long id);
    }
}
