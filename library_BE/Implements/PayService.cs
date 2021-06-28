using library_BE.Interfaces;
using library_BE.Models;
using library_BE.ViewModels.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE.Implements
{
    public class PayService : IPayService
    {
        private readonly AppDbContext _context;

        public PayService(AppDbContext context)
        {
            _context = context;

        }
        public async Task<object> CreatePay(PayRequest request)
        {
            var borrow = _context.Borrows.FirstOrDefault(x => x.Id == request.BorrowId && (int)x.Status == 1);
            if (null == borrow)
                return null;

            var pay = new Pay();
            pay.Id = Guid.NewGuid();
            pay.PayDate = DateTime.Now;
            pay.CreatedDate = DateTime.Now;
            pay.Status = Enums.Status.Active;
            pay.BorrowId = borrow.Id;

            var readerId = _context.Readers.FirstOrDefault(x => x.Id == borrow.ReaderId).Id;
            pay.ReaderId = readerId;

            borrow.Status = Enums.StatusBorrow.Payed;
            _context.Borrows.Update(borrow);

            var borrowDetail = _context.BorrowDetails.Where(x => x.BorrowId == borrow.Id).ToList();
            _context.BorrowDetails.RemoveRange(borrowDetail);

            foreach (var item in borrowDetail)
            {
                var book = _context.Books.FirstOrDefault(x => x.Id == item.BookId);
                book.Quantity = book.Quantity + item.Quantity;
            }

            _context.Pays.Add(pay);
            await _context.SaveChangesAsync();

            return pay;
        }

        public async Task<bool> DeletePay(string Id)
        {
            var pay = _context.Pays.FirstOrDefault(x => x.Id.ToString() == Id);
            if (null == pay)
                return false;

            var borrow = _context.Borrows.FirstOrDefault(x => x.Id == pay.BorrowId);
            _context.Borrows.Remove(borrow);

            _context.Pays.Remove(pay);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<object> GetPay()
        {
            var pays = await _context.Pays.ToListAsync();
            var payViewModels = new List<PayRequest>();

            foreach (var item in pays)
            {
                var payViewModel = new PayRequest();
                payViewModel.Id = item.Id;
                payViewModel.ReaderId = item.ReaderId;
                payViewModel.PayDate = item.PayDate;
                payViewModel.CreatedDate = item.CreatedDate;
                payViewModel.UpdatedDate = item.UpdatedDate;
                payViewModel.Status = item.Status;
                payViewModel.BorrowId = item.BorrowId;

                var borrowName = (_context.Borrows.FirstOrDefault(x => x.Id == item.BorrowId)).BorrowName;
                payViewModel.BorrowName = borrowName;

                payViewModels.Add(payViewModel);
            }


            if (null == payViewModels || 0 == payViewModels.Count())
                return null;
            return payViewModels;
        }

        public async Task<object> UpdatePay(PayRequest request)
        {
            var pay = _context.Pays.FirstOrDefault(x => x.Id == request.Id);
            if (null == pay)
                return null;

            var reader = _context.Readers.FirstOrDefault(x => x.Id == request.ReaderId && (int)x.Status == 1);
            if (null == reader)
                return null;

            pay.PayDate = request.PayDate;
            pay.UpdatedDate = DateTime.Now;
            pay.Status = request.Status;
            pay.ReaderId = request.ReaderId;

            _context.Pays.Update(pay);
            await _context.SaveChangesAsync();
            return pay;
        }
    }
}
