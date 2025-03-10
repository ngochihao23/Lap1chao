using Lab1_TH_NGOCHIHAO.DTOS.Product;
using Lab1_TH_NGOCHIHAO.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Lab1_TH_NGOCHIHAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
              new Product { Id = 1, Name = "Áo sơ mi", Price = 100000, Sizes = new string[] { "S", "M", "L" }, CategoryId = 1 },
    new Product { Id = 2, Name = "Áo thun", Price = 100000, Sizes = new string[] { "S", "M", "L" }, CategoryId = 1 },
    new Product { Id = 3, Name = "Quần jean 1", Price = 200000, Sizes = new string[] { "28", "29", "30" }, CategoryId = 2 },
    new Product { Id = 4, Name = "Quần kaki 1", Price = 150000, Sizes = new string[] { "28", "29", "30" }, CategoryId = 2 },
    new Product { Id = 5, Name = "Quần jean 2", Price = 200000, Sizes = new string[] { "28", "29", "30" }, CategoryId = 2 },
    new Product { Id = 6, Name = "Quần kaki 2", Price = 150000, Sizes = new string[] { "28", "29", "30" }, CategoryId = 2 },
    new Product { Id = 7, Name = "Giày thể thao", Price = 300000, Sizes = new string[] { "38", "39", "40" }, CategoryId = 3 },
    new Product { Id = 8, Name = "Giày lười", Price = 200000, Sizes = new string[] { "29", "38", "39", "40" }, CategoryId = 3 },
    new Product { Id = 9, Name = "Giày cao gót", Price = 500000, Sizes = new string[] { "29", "38", "39", "40" }, CategoryId = 3 },
    new Product { Id = 10, Name = "Giày thể thao", Price = 300000, Sizes = new string[] { "38", "39", "40" }, CategoryId = 3 },
    new Product { Id = 11, Name = "Balo", Price = 300000, Sizes = new string[] { "free-size" }, CategoryId = 4 },
    new Product { Id = 12, Name = "Túi xách", Price = 300000, Sizes = new string[] { "free-size" }, CategoryId = 4 },
    new Product { Id = 13, Name = "Balo", Price = 300000, Sizes = new string[] { "free-size" }, CategoryId = 4 },
    new Product { Id = 14, Name = "Túi xách", Price = 800000, Sizes = new string[] { "free-size" }, CategoryId = 4 },
    new Product { Id = 15, Name = "Balo lỏm", Price = 800000, Sizes = new string[] { "free-size" }, CategoryId = 4 },
    new Product { Id = 16, Name = "Túi xách da bò", Price = 300000, Sizes = new string[] { "free-size" }, CategoryId = 4 },
    new Product { Id = 17, Name = "Balo da cá", Price = 700000, Sizes = new string[] { "free-size" }, CategoryId = 4 },
    new Product { Id = 18, Name = "Túi xách Gucci", Price = 900000, Sizes = new string[] { "free-size" }, CategoryId = 4 }
        };

        private List<Category> _categories = new List<Category>
{
         new Category{ Id = 1, Name= "Áo" },
         new Category{ Id = 2, Name = "Quần" },
         new Category{ Id = 3, Name = "Giày" },
        new Category{ Id = 3, Name = "Phụ kiện" },
        };




        // LẤY DANH SÁCH TẤT CẢ SẢN PHẨM
        [HttpGet("create")]
        public IActionResult GetAll() {
            return Ok(products);
        }
        //API : CHỈ LẤY SẢN PHẨM CÓ Id=id 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) //null
            {
                return NotFound(" Không tìm thấy sản phẩm ");
            }
            return Ok(product);
        }




        [HttpPost]
        public IActionResult Create(Product request) {
            var productExist = products.FirstOrDefault(p => p.Id == request.Id);
            if (productExist == null)
            {
                return BadRequest(" sản phẩm không có thông báo");
            };
            request.Id = products.Max(p => p.Id) + 1;
            products.Add(request);
            return Ok(" thêm thành công");

        }
        [HttpPut("update")]
        public IActionResult Update(Product request)
        {
            var productExist = products.FirstOrDefault(p => p.Id == request.Id);
            if (productExist == null) // <=> tìm không thấy sản phẩm
            {
                return NotFound("Không tìm thấy sản phẩm mong muốn");
            }
            // SẢN PHẨM TÌM THẤY 
            //MAPPER : LẤY DỮ LIỆU CỦA DỐI TƯỢNG GÁN CHO ĐỐITƯỢNG MONG MUỐN :GIÁ TRI CỦA REQUEST => PRODUCTEXITST 
            productExist.Name = request.Name;
            productExist.Price = request.Price;
            productExist.Sizes = request.Sizes;
            productExist.CategoryId = request.CategoryId;
            return Ok("Đã cập nhật sản phẩm thành công");

        }
        [HttpDelete("delete")]
        //Route("Delete")
        public IActionResult Delete(int id)
        {
            var productExist = products.FirstOrDefault(p => p.Id == id);
            if (productExist == null) // <=> tìm không thấy sản phẩm
            {
                return NotFound("Không tìm thấy sản phẩm mong muốn");
            }
            //tim thấy ==> tiến hành xóa sản phẩm 
            products.Remove(productExist);
            return Ok($" Đã xóa sản phẩm có id= {id}, tên sản phẩm: {productExist.Name} thành công");
        }


        //API cơ bản C  R U  B = Create - Read -- Update -- Delete 
        // APi cơ bản : phân trang, lấy danh thu, số liệu phân tích, Api upload ảnh 


        // API TÌM KIẾM PHÂN TRANG 
        // API TÌM KIẾM KIẾM BẰNG KEYWORD 
        //NHẬP TÌM KIẾM : ÁO THUN 1 => ĐƠN GIẢN CONSTAINS > (==) 
        // CÔNG KIEME TRA TÊN SANT PHẨM CÓ CHƯA KEYWORD. ///=> 
        // PHỨC TẠP : SỬ DỤNG MÁY HỌC AI, ,L, ÁO THUN 1// KHI KIỂM TRA CONTAINS HOẶC KTRA == ÁO THUN <> "ÁO THUN " 
        [HttpGet("search/{search}")]
        public IActionResult Search(string search)
        {
            try // cố gắng thực thi cho bằng được hành được hành động bên trong
            {
                // áo ÁO Aó
                // vừa tìm kiếm theo tên , vừa tìm kiếm theo giá sản phẩm
                //tìm kiếm theo giá: chúng ta cần so sánh chính xác : 1000=> 100000, 1000000 => true 
                // nên sử dụng == so sánh cứng ,chính xác
                var keyword = search.ToUpper();
                var result = products.Where(p => p.Name.ToUpper().Contains(keyword) || p.Price.ToString() == keyword).ToList();
                // [ product, product ] 
                //[] // danh sách rỗng : count = 0
                if (result.Count() == 0)
                {
                    return NotFound(" không tìm thây sản phẩm");
                }
                return Ok(result);
            }
            catch (Exception e) // cố gắng bất lực
            {
                return BadRequest(new { e.Message });
            }


        }

        //phân trang 
        // client ==> request = BE ( Sever, service)
        //PageIndex :số trang hiện tại
        //PageSize: số record tối đa cho trang 
        // Response => danh sách record [ rc1, rc2] => List<Product>
        // , TotalRecord : số lượng record thỏa điều kiện 
        // thư mục Dto ( Data transfer object ) :
        // Product : > List<Product> +TotalRecord => Dto định nghĩa obj 
        //  2 DTO: => 1 CÁI DTO ĐỂ NHẬN REQUEST VÀ 1 CÁI DTO ĐỂ TRẢ VỀ RESPONSE 
        // Đối với phương thức GET => KO CÓ Entirt Body ; không nhận payload, body, mà chỉ nhận query 
        [HttpPost("paging")]


        [HttpGet("paging")]
        public IActionResult GetPaging([FromBody] ProductRequest request)
        {

            //Lọc sản phẩm tbeo : <predicate> : category, price, name, search
            // nhập thêm categoryId => Lọc sản phẩm theo danh mục : ko bắt buộc 
            if (request.CategoryId.HasValue)//xem có dữ liệu hay không
            {
                products = products.Where(p => p.CategoryId == request.CategoryId).ToList();
            }
            //request: pageIndex + Pagesize
            var result = products.Skip((request.PageIndex - 1) * request.PageSize) // bỏ qua n phần tử // dang ở trang 1 bỏ qua 0 phần tử
                                                                                   // trang 2 Index=(2-1)*size= số phần tử đã xuất hiện ở trang 1 
                .Take(request.PageSize).ToList();                              // lấy n phần tử tương ứng

            var dataResponse = new ProductGetPagingDto
            {
                Items = result,
                TotalRecord = products.Count(),

            };
            return Ok(dataResponse);

            //Phân trang : 6 sản phẩm trên 1 trang

        }  //controllers, DTO , ENTITY, VIẾT CRUID API






        //tìm sản phẩm bằng id
        [HttpGet("id")] 
        public IActionResult Search([FromQuery]int search)
        {
            try // cố gắng thực thi cho bằng được hành được hành động bên trong
            {
                // áo ÁO Aó
                // vừa tìm kiếm theo tên , vừa tìm kiếm theo giá sản phẩm
                //tìm kiếm theo giá: chúng ta cần so sánh chính xác : 1000=> 100000, 1000000 => true 
                // nên sử dụng == so sánh cứng ,chính xác
                var keyword = search.ToString();
                var result = products.Where(p => p.Id.ToString() == keyword).ToList();
                // [ product, product ] 
                //[] // danh sách rỗng : count = 0
                if (result.Count() == 0)
                {
                    return NotFound(" không tìm thây sản phẩm");
                }
                return Ok(result);
            }
            catch (Exception e) // cố gắng bất lực
            {
                return BadRequest(new { e.Message });
            }


        }



        //o	Trả về danh sách sản phẩm thuộc danh mục categoryId.
        [HttpGet("Category/{CategoryId}")]
        public IActionResult Catagory([FromRoute] int CategoryId)
        {
           
            
               var result = products.Where(p => p.CategoryId == CategoryId).ToList();

            return Ok(result);

        } 
        // yêu cầu không phân biệt hoa thường ----------------------------------
        [HttpGet("searchname")]
        public IActionResult SearchName([FromQuery] string Name)
        {
            var keyword = Name.ToUpper();
            var result = products.Where(p => p.Name.ToUpper().Contains(keyword)).ToList();
            return Ok(result);
        }

        // o	Thống kê số lượng sản phẩm theo danh mục.
        [HttpGet("thongke")] 
        public IActionResult CategoryCount() 
        {
            var groupby = products.GroupBy(p => p.CategoryId).ToList();

            //KEY - LIST
             
            var result = groupby.Select(C => new
            {
                CategoryId = C.Key,
                Count = C.Count()

            }
            );

            return Ok(result);
        }














    }

}
