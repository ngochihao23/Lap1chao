namespace Lab1_TH_NGOCHIHAO.DTOS.Product
{
    public class ProductGetPagingDto
    {
        // đây là reponse 

        public List<Enities.Product> Items { get; set; }
        public int TotalRecord {  get; set; } // đây là tổng sản phẩm mà hệ thống có
    }
}
