using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.OrderCQRS.Queries;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);

        Task<PaginatedList<Order>> GetAllOrders(int offset, int limit);
    }
}
