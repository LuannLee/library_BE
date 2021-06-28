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
    public class BorrowDetailController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly IBorrowDetailService _iborrowDetail;
        public BorrowDetailController(AppDbContext contecxt, IBorrowDetailService iborrowDetail)
        {
            _contecxt = contecxt;
            _iborrowDetail = iborrowDetail;
        }

        [HttpGet("get-borrowDetail")]
        public async Task<IActionResult> GetBorrowDetail()
        {
            try
            {
                var detail = await _iborrowDetail.GetBorrowDetail();
                if (null == detail)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = detail });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-borrowDetail")]
        public async Task<IActionResult> CreateBorrowDetail(BorrowDetailRequest request)
        {
            try
            {
                var detail = await _iborrowDetail.CreateBorrowDetail(request);
                if (null == detail)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm chi tiết thẻ mượn thành công thành công", Data = detail });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPut("update-borrowDetail")]
        public async Task<IActionResult> UpdateBorrowDetail(BorrowDetailRequest request)
        {
            try
            {
                var detail = await _iborrowDetail.UpdateBorrowDetail(request);
                if (null == detail)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật chi tiết thẻ mượn thành công", Data = detail });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-borrowDetail/{id}")]
        public async Task<IActionResult> DeleteBorrowDetail(string id)
        {
            try
            {
                var detail = await _iborrowDetail.DeleteBorrowDetail(id);
                if (false == detail)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá chi tiết thẻ mượn thành công", Data = detail });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }
    }
}
