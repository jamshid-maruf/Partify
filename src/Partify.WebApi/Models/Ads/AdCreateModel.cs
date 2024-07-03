using Partify.Domain.Enums;

namespace Partify.WebApi.Models.Ads
{
    public class AdCreateModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public long Phone { get; set; }
        public decimal Price { get; set; }
        public PostType Type { get; set; }
        public PostStatus Status { get; set; }
        public long MerchantId { get; set; }
        public long AdCategoryId { get; set; }
    }
}
