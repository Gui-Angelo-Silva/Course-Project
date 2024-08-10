﻿using AutoMapper;
using SGED.Objects.DTOs.Entities;
using SGED.Objects.Models.Entities;

namespace SGED.Objects.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entidades de Usuários:
            CreateMap<UserDTO, UserModel>().ReverseMap();
            CreateMap<ReservationDTO, ReservationModel>().ReverseMap();

            // Entidades de Restaurante:
            CreateMap<RestaurantDTO, RestaurantModel>().ReverseMap();
            CreateMap<TableDTO, TableModel>().ReverseMap();
        }
    }
}