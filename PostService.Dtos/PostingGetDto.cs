using PostService.CommonTypes;

namespace PostService.Dtos
{
    public class PostingGetDto
    {
        public int Id { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public float Weight { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Value { get; set; }
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
