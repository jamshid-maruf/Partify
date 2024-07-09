using Partify.WebApi.Models.Ads;
using Partify.WebApi.Models.Facilities;

namespace Partify.WebApi.Models.AdFacilities;

public class AdFacilityViewModel
{
    public long Id { get; set; }
    public AdViewModel Ad { get; set; }
    public FacilityViewModel Facility { get; set; }
}