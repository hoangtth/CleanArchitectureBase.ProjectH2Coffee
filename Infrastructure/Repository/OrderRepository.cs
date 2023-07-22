using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Domain.Entities;
using CleanArchitectureBase.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;
        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<Order>> GetAllOrders(int offset, int limit)
        {
            var users = _context.Orders;
            return new PaginatedList<Order>
            {
                Total = await users.CountAsync(),
                Items = await users.Skip(offset).Take(limit).ToListAsync()
            };
        }

        public async Task<int> GetTotalOrderInMonth()
        {
            var firstDayOfMonth = ConvertDateTime.GetFirstDayOfMonth(DateTime.Now);
            var lastDayOfMonth = ConvertDateTime.GetLastDayOfMonth(DateTime.Now);

            var total = await _context.Orders.Where(x => x.CreatedDate >= firstDayOfMonth && x.CreatedDate <= lastDayOfMonth).CountAsync();
            return total;
        }

        public async Task<decimal> GetTotalPriceInMonth()
        {
            var firstDayOfMonth = ConvertDateTime.GetFirstDayOfMonth(DateTime.Now);
            var lastDayOfMonth = ConvertDateTime.GetLastDayOfMonth(DateTime.Now);
            var rs = await _context.Orders.Where(x => x.CreatedDate >= 
            firstDayOfMonth && x.CreatedDate <= lastDayOfMonth).ToListAsync();

            decimal totalPrice = 0;
            foreach(var item in rs)
            {
                totalPrice += item.TotalCost;
            }

            return totalPrice;
        }
    }
}
