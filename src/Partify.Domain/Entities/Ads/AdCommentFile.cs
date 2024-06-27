using Partify.Domain.Commons;
using Partify.Domain.Entities.Commons;

namespace Partify.Domain.Entities.Ads;

public class AdCommentFile : Auditable
{
	public long AdCommentId { get; set; }
	public AdComment AdComment { get; set; }
	public long? FileId { get; set; }
	public Asset File { get; set; }
}