using library_BE.Implements;
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
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBookService _ibook;
        public BookController(AppDbContext context, IBookService ibook )
        {
            _context = context;
            _ibook = ibook;
        }

        [HttpGet("get-book")]
        public async Task<IActionResult> GetBook()
        {
            try
            {
                var books = await _ibook.GetBook();
                if (null == books)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = books });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBook(BookRequest request)
        {
            try
            {
                var book = await _ibook.CreateBook(request);
                if (null == book)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm sách thành công thành công", Data = book });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPut("update-book")]
        public async Task<IActionResult> UpdateBook(BookRequest request)
        {
            try
            {
                var book = await _ibook.UpdateBook(request);
                if (null == book)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật sách thành công", Data = book });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> Deletebook(string id)
        {
            try
            {
                var book = await _ibook.DeleteBook(id);
                if (false == book)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá sách thành công", Data = book });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

    }
}