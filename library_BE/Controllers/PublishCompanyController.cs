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
    public class PublishCompanyController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly IPublishCompanyService _icompany;
        public PublishCompanyController(AppDbContext contecxt, IPublishCompanyService icompany)
        {
            _contecxt = contecxt;
            _icompany = icompany;
        }

        [HttpGet("get-company")]
        public async Task<IActionResult> GetPublishCompany()
        {
            try
            {
                var companies = await _icompany.GetPublishCompany();
                if (null == companies)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = companies });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-company")]
        public async Task<IActionResult> CreatePublishCompany(PublishCompanyRequest request)
        {
            try
            {
                var reader = await _icompany.CreatePublishCompany(request);
                if (null == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm nhà xuất bản công thành công", Data = reader });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPut("update-company")]
        public async Task<IActionResult> UpdatePublishCompany(PublishCompanyRequest request)
        {
            try
            {
                var reader = await _icompany.UpdatePublishCompany(request);
                if (null == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật nhà xuất bản thành công", Data = reader });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-company/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                var reader = await _icompany.DeletePublishCompany(id);
                if (false == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá nhà xuất bản thành công", Data = reader });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

    }
}
