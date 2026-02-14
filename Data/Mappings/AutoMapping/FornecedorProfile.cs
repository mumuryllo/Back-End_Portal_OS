using AutoMapper;
using PortalOS.Contracts.Request.Fornecedor;
using PortalOS.Contracts.Response;
using PortalOS.Contracts.Response.Fornecedor;
using PortalOS.Domain.Entities;

namespace PortalOS.Mappings
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<FornecedorRequestDto, Fornecedor>()
                .ConstructUsing(x =>
                    new Fornecedor(
                        x.Nome,
                        x.Documento,
                        x.Email,
                        x.Telefone,
                        x.Endereco
                    ));

            CreateMap<Fornecedor, FornecedorResponseDto>();

            CreateMap<HistoricoValorHoraFornecedor, HistoricoValorHoraFornecedorResponseDto>();
            CreateMap<HistoricoServicoFornecedor, HistoricoServicoFornecedorResponseDto>();
        }
    }
}
