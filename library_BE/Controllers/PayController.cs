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
    public class PayController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly IPayService _iPay;
        public PayController(AppDbContext contecxt, IPayService iPay)
        {
            _contecxt = contecxt;
            _iPay = iPay;
        }

        [HttpGet("get-pay")]
        public async Task<IActionResult> GetPay()
        {
            try
            {
                var pays = await _iPay.GetPay();
                if (null == pays)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = pays });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-pay")]
        public async Task<IActionResult> CreatePay(PayRequest request)
        {
            try
            {
                var pay = await _iPay.CreatePay(request);
                if (null == pay)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm thẻ trả thành công thành công", Data = pay });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPut("update-pay")]
        public async Task<IActionResult> UpdatePay(PayRequest request)
        {
            try
            {
                var pay = await _iPay.UpdatePay(request);
                if (null == pay)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật thẻ trả thành công", Data = pay });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }


        [HttpDelete("delete-pay/{id}")]
        public async Task<IActionResult> DeleteBrrow(string id)
        {
            try
            {
                var pay = await _iPay.DeletePay(id);
                if (false == pay)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá thẻ trả thành công", Data = pay });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

    }
}
