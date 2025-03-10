namespace Lab1_TH_NGOCHIHAO.DTOS.Product
{
    public class ProductRequest
    {  //phân theo danh mục
        public int? CategoryId { get; set; }    // có thể để trống => null
        public int PageIndex { get; set; } //bắt buộc

        public int PageSize { get; set; } //bắt buộc
    }
}
