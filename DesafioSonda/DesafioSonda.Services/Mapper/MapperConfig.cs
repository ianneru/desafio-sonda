using AutoMapper;
using DesafioSonda.Domain.Entities;
using DesafioSonda.Application.DTOs;

namespace DesafioSonda.Application.Mapper
{
    public static class MapperConfig
    {
        public static IMapper CreateConfig
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClientesDTO, Clientes>();
                });

                var mapper = config.CreateMapper();

                return mapper;
            }
        }
    }
}
