
using System.Linq;
using AutoMapper;
using Secretary.API.Dtos;
using Secretary.API.Models;

namespace Secretary.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UserForListDto>();

            CreateMap<Usuario, UserForDetailsDto>();

            // CreateMap<Publicador, PublisherForListDto>();


            CreateMap<Publicador, PublisherForListDto>()
            .ForMember(dest => dest.NomeSobrenome, opt =>
                {
                    opt.ResolveUsing(d => d.Nome.Split(' ')[0] + ' ' + d.Nome.Split(' ')[d.Nome.Split(' ').Length - 1]);
                })
            .ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DataNascimento.CalculateAge());
                });


            CreateMap<Congregacao, CongregationForListDto>();
        }
    }
}
