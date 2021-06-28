using library_BE.Interfaces;
using library_BE.Models;
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
    public class ReaderController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly IReaderService IReader;
        public ReaderController(AppDbContext contecxt, IReaderService iReader)
        {
            _contecxt = contecxt;
            IReader = iReader;
        }

        [HttpGet("get-reader")]
        public async Task<IActionResult> GetReader()
        {
            try
            {
                var readers = await IReader.GetReader();
                if (null == readers)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = readers });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-reader")]
        public async Task<IActionResult> CreateReader(ReaderRequest request)
        {
            try
            {
                var reader = await IReader.CreateReader(request);
                if (null == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
               return Ok(new Response<object> { StatusCode = 200, Message = "Thêm độc giả thành công", Data = reader });
            }
            catch (Exception e) 
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
                }
        }

        [HttpPut("update-reader")]
        public async Task<IActionResult> UpdateReader(ReaderRequest request)
        {
            try
            {
                var reader = await IReader.UpdateReader(request);
                if (null == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật độc giả thành công", Data = reader });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-reader/{id}")]
        public async Task<IActionResult> DeleteReader(string id)
        {
            try
            {
                var reader = await IReader.DeleteReader(id);
                if (false == reader)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá độc giả thành công", Data = reader });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

    }
}
