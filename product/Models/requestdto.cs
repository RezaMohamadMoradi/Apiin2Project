namespace product.Models
{
    public class requestdto
    {
        public string url { get; set; }

        public byte httpmetod { get; set; } //1post 2get 3put

        public object data { get; set; }
    }
}
