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
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly ICategoryService _iCategory;
        public CategoryController(AppDbContext contecxt, ICategoryService iCategory)
        {
            _contecxt = contecxt;
            _iCategory = iCategory;
        }


        [HttpGet("get-category")]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var readers = await _iCategory.GetCategory();
                if (null == readers)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = readers });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }
        
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(CategoryRequest request)
        {
            try
            {
                var reader = await _iCategory.CreateCategory(request);
                if (null == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm thể loại thành công thành công", Data = reader });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(CategoryRequest request)
        {
            try
            {
                var reader = await _iCategory.UpdateCategory(request);
                if (null == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật thể loại thành công", Data = reader });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                var reader = await _iCategory.DeleteCategory(id);
                if (false == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá thể loại thành công", Data = reader });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

    }
}
