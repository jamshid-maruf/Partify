using Partify.Domain.Commons;
using Partify.Domain.Entities.Users;

namespace Partify.Domain.Entities.Appartments;

public class FavoriteAppartment : Auditable
{
	public long UserId { get; set; }
	public User User { get; set; }
	public long AppartmentId { get; set; }
	public Appartment Appartment { get; set; }
}