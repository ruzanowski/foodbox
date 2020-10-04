// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using Abp.Application.Services.Dto;
// using Abp.Authorization;
// using Abp.Authorization.Users;
// using Abp.MultiTenancy;
// using Abp.Runtime.Security;
// using Abp.UI;
// using AutoMapper;
// using Food.Authorization;
// using Food.Authorization.Users;
// using Food.Core.Authentication.External;
// using Food.Core.Authentication.JwtBearer;
// using Food.Core.Models.TokenAuth;
// using Food.MultiTenancy;
// using Food.Orders;
// using Food.Orders.Dto;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Food.Core.Controllers
// {
//     // [Route("api/[controller]/[action]")]
//     public class OrderController : FoodControllerBase
//     {
//         private readonly LogInManager _logInManager;
//         private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
//         private readonly TokenAuthConfiguration _configuration;
//         private readonly IOrderAppService _orderAppService;
//
//         public OrderController(
//             LogInManager logInManager,
//             AbpLoginResultTypeHelper abpLoginResultTypeHelper,
//             TokenAuthConfiguration configuration,
//             IOrderAppService orderAppService)
//         {
//             _logInManager = logInManager;
//             _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
//             _configuration = configuration;
//             _orderAppService = orderAppService;
//         }
////         [HttpPost]
//         public async Task<OrderDto> Create([FromBody] CreateOrderDto model)
//         {
//             var order = await _orderAppService.CreateAsync(model);
//
//             return order;
//         }
//
//         [HttpGet]
//         public async Task<OrderDto> Get([FromQuery] EntityDto<long> id)
//         {
//             var order = await _orderAppService.GetAsync(id);
//
//             return order;
//         }
//
//         [HttpGet]
//         public async Task<OrderDto> GetAll([FromQuery] EntityDto<long> id)
//         {
//             var order = await _orderAppService.GetAllAsync(id);
//
//             return order;
//         }
//
//     }
// }
