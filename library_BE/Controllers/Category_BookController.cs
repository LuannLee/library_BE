using library_BE.Interfaces;
using library_BE.ViewModels.Requests;
using library_BE.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace library_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category_BookController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly ICategory_BookService _icb;
        public Category_BookController(AppDbContext contecxt, ICategory_BookService icb)
        {
            _contecxt = contecxt;
            _icb = icb;
        }

        [HttpGet("get-category_book")]
        public async Task<IActionResult> Getcategory_Book()
        {
            try
            {
                var category_books = await _icb.GetCategory_Book();
                if (null == category_books)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = category_books });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-category_book")]
        public async Task<IActionResult> CreateCategory_Book(Category_BookRequest request)
        {
            try
            {
                var category_book = await _icb.CreateCategory_Book(request);
                if (null == category_book)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm  thành công thành công", Data = category_book });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-author_book/{categoryId}/{bookId}")]
        public async Task<IActionResult> DeleteCategory_Book(string categoryId, string bookId)
        {
            try
            {
                var category_book = await _icb.DeleteCategory_Book(categoryId, bookId);
                if (false == category_book)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá thành công", Data = category_book });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }
    }
}
