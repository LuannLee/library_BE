using library_BE.Interfaces;
using library_BE.ViewModels.Requests;
using library_BE.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Author_BookController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly IAuthor_BookService _iab;
        public Author_BookController(AppDbContext contecxt, IAuthor_BookService iab)
        {
            _contecxt = contecxt;
            _iab = iab;
        }

        [HttpGet("get-author_book")]
        public async Task<IActionResult> GetAuthor_Book()
        {
            try
            {
                var author_books = await _iab.GetAuthor_Book();
                if (null == author_books)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = author_books });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-author_book")]
        public async Task<IActionResult> CreateAuthor_Book(Author_BookRequest request)
        {
            try
            {
                var author_book = await _iab.CreateAuthor_Book(request);
                if (null == author_book)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm  thành công thành công", Data = author_book });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-author_book/{authorId}/{bookId}")]
        public async Task<IActionResult> DeleteAuthor_Book(string authorId, string bookId)
        {
            try
            {
                var author_book = await _iab.DeleteAuthor_Book(authorId, bookId);
                if (false == author_book)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá thành công", Data = author_book });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

    }
}
