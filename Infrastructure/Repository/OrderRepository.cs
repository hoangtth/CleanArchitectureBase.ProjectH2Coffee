using CleanArchitectureBase.Application.Common.Interfaces;
using CleanArchitectureBase.Domain.Entities;
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
    }
}
