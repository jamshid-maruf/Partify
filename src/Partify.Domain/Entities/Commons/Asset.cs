using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Commons;

public class Asset : Auditable
{
	public string FileName { get; set; }
	public string FilePath { get; set; }
}