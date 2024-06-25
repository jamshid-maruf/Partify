using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Facilities;

public class Facility : Auditable
{
	public string Name { get; set; }
	public string Icon { get; set; }
}