using Microsoft.AspNetCore.Http;
using Partify.Domain.Entities.Commons;

namespace Partify.Service.Services.Assets;

public interface IAssetService
{
	ValueTask<AssetViewModel> UploadAsync(IFormFile file, string fileType);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<AssetViewModel> GetByIdAsync(long id);
}