
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

            CreateMap<Publicador, PublisherSimplifiedDto>()
            .ForMember(dest => dest.PrimeiroNome, opt =>
                {
                    opt.ResolveUsing(d => d.Nome.Split(' ')[0]);
                })
            .ForMember(dest => dest.NomeSobrenome, opt =>
                {
                    opt.ResolveUsing(d => d.Nome.Split(' ')[0] + ' ' + d.Nome.Split(' ')[d.Nome.Split(' ').Length - 1]);
                });

            CreateMap<Publicador, PublisherForListDto>()
            .ForMember(dest => dest.PrimeiroNome, opt =>
                {
                    opt.ResolveUsing(d => d.Nome.Split(' ')[0]);
                })
            .ForMember(dest => dest.NomeSobrenome, opt =>
                {
                    opt.ResolveUsing(d => d.Nome.Split(' ')[0] + ' ' + d.Nome.Split(' ')[d.Nome.Split(' ').Length - 1]);
                })
            .ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DataNascimento.CalculateAge());
                });

            CreateMap<Publicador, PublisherForDetailsDto>()
            .ForMember(dest => dest.PrimeiroNome, opt =>
                {
                    opt.ResolveUsing(d => d.Nome.Split(' ')[0]);
                })
            .ForMember(dest => dest.NomeSobrenome, opt =>
                {
                    opt.ResolveUsing(d => d.Nome.Split(' ')[0] + ' ' + d.Nome.Split(' ')[d.Nome.Split(' ').Length - 1]);
                })
            .ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DataNascimento.CalculateAge());
                });

            CreateMap<Congregacao, CongregationForListDto>();

            CreateMap<Dianteira, LeadForListDto>();

            CreateMap<Dianteira, LeadSimplifiedDto>();

            CreateMap<Grupo, GroupSimplifiedDto>();

            CreateMap<Pioneiro, PioneerSimplifiedDto>();

            CreateMap<Congregacao, CongregationSimplifiedDto>();

            CreateMap<ServicoCampo, FieldServiceForListDto>();

            CreateMap<Pioneiro, PioneerForDetailDto>();

            CreateMap<Pioneiro, PioneerSimplifiedDto>();

            CreateMap<FieldServiceForUpdateDto, ServicoCampo>();

            CreateMap<TotalFieldServiceReportDto, ServicoCampo>();

            

        }
    }
}
