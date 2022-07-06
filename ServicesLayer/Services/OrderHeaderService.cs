using BusinessLayer.DTOs;
using DomainLayer.Models.Auth;
using InfrastructureLayer.RespositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessLayer.IServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using DomainLayer.Models.orders;
using BusinessLayer.Heplers;
using AutoMapper;

namespace BusinessLayer.Services
{
    public class OrderHeaderService : IOrderService
    {
        #region Property
        private IRepository<OrderHeader> _repoOrderHeader;
        private IRepository<OrderDetails> _repoOrderDet;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public OrderHeaderService(IRepository<OrderHeader> repoOrderHeader, IRepository<OrderDetails> repoOrderDet, IMapper mapper)
        {
            _repoOrderHeader = repoOrderHeader;
            _repoOrderDet = repoOrderDet;
            _mapper = mapper;
        }
        #endregion

        public async Task<DataSourceResult<GetOrderDTO>> GetOrders(CustomListParam customListParam)
        {
            var query = _repoOrderHeader.GetAll()
                .Select(x=> new GetOrderDTO
                {
                    CustomerName=x.CustomerName,
                    DateOrder=x.OrderDate,
                    Id=x.Id,
                    Address=x.Address,
                    PhoneNo=x.PhoneNo
                });
            if (!string.IsNullOrEmpty(customListParam.Search))
            {
                query = query.Where(d =>
                       d.CustomerName.ToLower().Contains(customListParam.Search.ToLower()) 
                       ||  d.Id.ToString().Contains(customListParam.Search) 
                       || d.DateOrder.ToString().Contains(customListParam.Search)
                       || d.PhoneNo.ToLower().Contains(customListParam.Search.ToLower())
                       || d.Address.ToLower().Contains(customListParam.Search.ToLower())
                       );
            }
            
            var result= await PagedList<GetOrderDTO>.CreateAsync(query, customListParam.PageNumber, customListParam.PageSize);
            return new DataSourceResult<GetOrderDTO>()
            {
                Data = result,
                Total = result.TotalCount
            };
        }

        public  async Task AddOrder(AddOrderDTO dto, string userName)
        {
            var model = _mapper.Map<OrderHeader>(dto);
            GenericModelBase<OrderHeader>.SetAddDefualts(model, userName);
            
            if (model.OrderDetails == null)
            {
                throw new Exception("please insert order detials");
            }
            foreach (var item in model.OrderDetails)
            {
                GenericModelBase<OrderDetails>.SetAddDefualts(item, userName);
            }
            _repoOrderHeader.Insert(model);
            lock (model)
            {
                _repoOrderHeader.SaveChanges();
            }
        }
    }
}
