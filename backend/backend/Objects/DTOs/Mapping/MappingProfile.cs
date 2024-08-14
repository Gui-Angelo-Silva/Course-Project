using AutoMapper;
using backend.Objects.DTOs.Entities;
using backend.Objects.Models.Entities;

namespace backend.Objects.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entidades de Usuário:
            CreateMap<UserDTO, UserModel>().ReverseMap();
            CreateMap<ReservationDTO, ReservationModel>().ReverseMap();

            // Entidades de Restaurante:
            CreateMap<RestaurantDTO, RestaurantModel>().ReverseMap();
            CreateMap<TableDTO, TableModel>().ReverseMap();
            CreateMap<ThematicDTO, ThematicModel>().ReverseMap();
            CreateMap<ThematicRestaurantDTO, ThematicRestaurantModel>().ReverseMap();
        }
    }
}