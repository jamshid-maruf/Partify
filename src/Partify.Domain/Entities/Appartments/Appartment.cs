using Partify.Domain.Commons;
using Partify.Domain.Entities.Users;
using Partify.Domain.Enums;

namespace Partify.Domain.Entities.Appartments;

public class Appartment : Auditable
{
	public string Address { get; set; }
	public double Longitude { get; set; }
	public double Latitude { get; set; }
	public string Description { get; set; }
	public long Phone { get; set; }
	public int Floor { get; set; }
	public int RoomCount { get; set; }
	public double Area { get; set; }
	public decimal Price { get; set; }
	public AppartmentTypes Type { get; set; }
	public AppartmentStatuses Status { get; set; }
	public long MerchantId { get; set; }
	public Merchant Merchant { get; set; }

	public ICollection<AppartmentComment> Comments { get; set; }
	public ICollection<AppartmentFacility> Facilities { get; set; }
	public ICollection<AppartmentImage> Images { get; set; }
	public ICollection<AppartmentScore> Scores { get; set; }
}
