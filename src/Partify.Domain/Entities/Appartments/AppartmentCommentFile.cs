using Partify.Domain.Commons;
using Partify.Domain.Entities.Commons;

namespace Partify.Domain.Entities.Appartments;

public class AppartmentCommentFile : Auditable
{
	public long AppartmentCommentId { get; set; }
	public AppartmentComment AppartmentComment { get; set; }
	public long? FileId { get; set; }
	public Asset File { get; set; }
}