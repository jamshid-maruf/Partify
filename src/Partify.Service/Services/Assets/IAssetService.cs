using Microsoft.AspNetCore.Http;
using Partify.Domain.Entities.Commons;

namespace Partify.Service.Services.Assets;

public interface IAssetService
{
	ValueTask<Asset> UploadAsync(IFormFile file, string fileType);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<Asset> GetByIdAsync(long id);
}