﻿using AutoMapper;
using CleanArchitectureBase.Application.Common.Models;
using CleanArchitectureBase.Application.OrderCQRS.Commands.CreateOrder;
using CleanArchitectureBase.Application.OrderCQRS.Queries;
using CleanArchitectureBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Mappings
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderDetailsDto, OrderDetails>();
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
            CreateMap<Order, GetAllOrdersQueryResponse>();
            CreateMap<PaginatedList<Order>, PaginatedList<GetAllOrdersQueryResponse>>();
        }
    }
}
