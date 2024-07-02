using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Commons;

public class AssetViewModel : Auditable
{
	public string FileName { get; set; }
	public string FilePath { get; set; }
}