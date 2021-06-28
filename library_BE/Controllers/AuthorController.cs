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
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly IAuthorService _iAuthor;
        public AuthorController(AppDbContext contecxt, IAuthorService iAuthor)
        {
            _contecxt = contecxt;
            _iAuthor = iAuthor;
        }

        [HttpGet("get-author")]
        public async Task<IActionResult> GetAuthor()
        {
            try
            {
                var authors = await _iAuthor.GetAuthor();
                if (null == authors)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = authors });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-author")]
        public async Task<IActionResult> CreateAuthor(AuthorRequest request)
        {
            try
            {
                var author = await _iAuthor.CreateAuthor(request);
                if (null == author)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm tác giả thành công thành công", Data = author });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPut("update-author")]
        public async Task<IActionResult> UpdateAuthor(AuthorRequest request)
        {
            try
            {
                var author = await _iAuthor.UpdateAuthor(request);
                if (null == author)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật tác giả thành công", Data = author });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }
        
        [HttpDelete("delete-author/{id}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            try
            {
                var author = await _iAuthor.DeleteAuthor(id);
                if (false == author)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá tác giả thành công", Data = author });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }
    }
}
