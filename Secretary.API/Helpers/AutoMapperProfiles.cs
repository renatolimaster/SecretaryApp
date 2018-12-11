
using System.Linq;
using AutoMapper;
using Secretary.API.Dtos;
using Secretary.API.Model;

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

            // CONGREGATION
            CreateMap<Congregacao, CongregationForListDto>();
            CreateMap<Congregacao, CongregationSimplifiedDto>();
            CreateMap<CongregationForCreateDto, Congregacao>();
            CreateMap<CongregationForUpdateDto, Congregacao>();

            CreateMap<Dianteira, LeadForListDto>();

            CreateMap<Dianteira, LeadSimplifiedDto>();

            CreateMap<Grupo, GroupSimplifiedDto>();
            // SITUACAO
            CreateMap<Situacao, SituacaoForListDto>();
            CreateMap<SituacaoForListDto, Situacao>();
            // COUNTRY

            // FIELD SERVICE
            CreateMap<ServicoCampo, FieldServiceForListDto>();
            CreateMap<FieldServiceForListDto, ServicoCampo>();
            CreateMap<FieldServiceForUpdateDto, ServicoCampo>();
            CreateMap<ServicoCampo, FieldServiceForUpdateDto>();
            CreateMap<TotalFieldServiceReportDto, ServicoCampo>();

            CreateMap<Pioneiro, PioneerForDetailDto>();

            CreateMap<Pioneiro, PioneerSimplifiedDto>();

            CreateMap<CountryForListDto, Country>();
            CreateMap<Country, CountryForListDto>();
            
            CreateMap<StateForListDto, Estado>();

            CreateMap<Estado, StateForListDto>();

            CreateMap<TipoLogradouroForListDto, TipoLogradouro>();

            CreateMap<TipoLogradouro, TipoLogradouroForListDto>();

        }
    }
}
