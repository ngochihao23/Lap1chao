namespace Lab1_TH_NGOCHIHAO.Enities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; } 

        public int CategoryId { get; set; } 

    }
}
