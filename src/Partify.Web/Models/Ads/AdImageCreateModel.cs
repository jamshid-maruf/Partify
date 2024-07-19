namespace Partify.Web.Models.Ads;

public class AdImageCreateModel
{
    public long AdId { get; set; }
    public IFormFile Image { get; set; }
}
