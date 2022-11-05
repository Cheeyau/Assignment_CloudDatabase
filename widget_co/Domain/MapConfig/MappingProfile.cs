using AutoMapper;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MapConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewDTO, Review>();
            CreateMap<ProductDTO, Product>();
            CreateMap<UserDTO, User>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
