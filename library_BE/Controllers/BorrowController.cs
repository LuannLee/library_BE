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
    public class BorrowController : ControllerBase
    {
        private readonly AppDbContext _contecxt;
        private readonly IBorrowService _iBorrow;
        public BorrowController(AppDbContext contecxt, IBorrowService iBorrow)
        {
            _contecxt = contecxt;
            _iBorrow = iBorrow;
        }
       

       [HttpGet("get-borrow")]
        public async Task<IActionResult> GetBorrow()
        {
            try
            {
                var borrows = await _iBorrow.GetBorrow();
                if (null == borrows)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = borrows });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpGet("get-borrow-bystatus")]
        public async Task<IActionResult> GetBorrowByStatus()
        {
            try
            {
                var borrows = await _iBorrow.GetBorrowbyStatus();
                if (null == borrows)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = borrows });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpGet("get-count-borrow")]
        public async Task<IActionResult> GetCountBorrow()
        {
            try
            {
                var counts = await _iBorrow.GetCountBorrow();
                if (null == counts)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = counts });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }


        [HttpPost("get-borrowDetail-by-borrow")]
        public async Task<IActionResult> GetBorrowdetailByBorrow(BorrowRequest request)
        {
            try
            {
                var borrowdetails = await _iBorrow.GetBorrowDetailByBorrow(request);
                if (null == borrowdetails)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });

                return Ok(new Response<object> { StatusCode = 200, Message = "Thành công", Data = borrowdetails });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPost("create-borrow")]
        public async Task<IActionResult> CreateBorrow(BorrowRequest request)
        {
            try
            {
                var borrow = await _iBorrow.CreateBorrow(request);
                if (null == borrow)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Thêm thẻ mượn thành công thành công", Data = borrow });
            }
            catch (Exception e)
            {

                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpPut("update-borrow")]
        public async Task<IActionResult> UpdateBorrow(BorrowRequest request)
        {
            try
            {
                var borrow = await _iBorrow.UpdateBorrow(request);
                if (null == borrow)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Cập nhật thẻ mượn thành công", Data = borrow });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }

        [HttpDelete("delete-borrow/{id}")]
        public async Task<IActionResult> DeleteBrrow(string id)
        {
            try
            {
                var borrow = await _iBorrow.DeleteBorrow(id);
                if (false == borrow)
                    return Ok(new Response<object> { StatusCode = 200, Message = "Không tìm thấy dữ liệu", Data = null });
                return Ok(new Response<object> { StatusCode = 200, Message = "Xoá thẻ mượn thành công", Data = borrow });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<object> { StatusCode = 500, Message = "Lỗi", Data = null });
            }
        }
    }
}
