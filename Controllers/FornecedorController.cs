using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalOS.Contracts.Request;
using PortalOS.Contracts.Request.Fornecedor;
using PortalOS.Contracts.Response.Fornecedor;
using PortalOS.Services.Interfaces;

namespace PortalOS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorService fornecedorService, IMapper mapper)
        {
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo fornecedor no sistema.
        /// </summary>
        /// <remarks>
        /// Este endpoint cadastra um fornecedor com dados básicos:
        /// Nome, Documento, Email, Telefone e Endereço.
        /// </remarks>
        /// <param name="request">Dados do fornecedor</param>
        /// <returns>Fornecedor criado</returns>
        /// <response code="201">Fornecedor cadastrado com sucesso</response>
        /// <response code="400">Dados inválidos ou mal formatados</response>
        /// <response code="409">Já existe um fornecedor cadastrado com o mesmo documento</response>
        [HttpPost]
        [ProducesResponseType(typeof(FornecedorResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CriarFornecedor([FromBody] FornecedorRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var fornecedor = await _fornecedorService.CriarFornecedorAsync(request);

            var response = _mapper.Map<FornecedorResponseDto>(fornecedor);

            return CreatedAtAction(nameof(ObterFornecedorPorId), new { id = fornecedor.Id }, response);
        }

        /// <summary>
        /// Obtém um fornecedor pelo seu ID.
        /// </summary>
        /// <param name="id">ID do fornecedor</param>
        /// <returns>Fornecedor encontrado</returns>
        /// <response code="200">Fornecedor encontrado com sucesso</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FornecedorResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterFornecedorPorId([FromRoute] Guid id)
        {
            var fornecedor = await _fornecedorService.ObterFornecedorPorIdAsync(id);

            var response = _mapper.Map<FornecedorResponseDto>(fornecedor);

            return Ok(response);
        }

        /// <summary>
        /// Atualiza o contato do fornecedor.
        /// </summary>
        /// <param name="id">ID do fornecedor</param>
        /// <param name="request">Novos dados de contato</param>
        /// <response code="200">Contato atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpPut("{id:guid}/contato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarContatoFornecedor(
            [FromRoute] Guid id,
            [FromBody] AtualizarContatoFornecedorRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _fornecedorService.AtualizarContatoFornecedorAsync(id, request.Email, request.Telefone, request.Endereco);

            return Ok(new { message = "Contato do fornecedor atualizado com sucesso." });
        }

        /// <summary>
        /// Adiciona um novo valor hora para o fornecedor (histórico).
        /// </summary>
        /// <remarks>
        /// Ao adicionar um novo valor hora, o sistema encerra automaticamente o valor hora anterior (se existir).
        /// </remarks>
        /// <param name="id">ID do fornecedor</param>
        /// <param name="request">Dados do novo valor hora</param>
        /// <response code="200">Valor hora adicionado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpPost("{id:guid}/valor-hora")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AdicionarValorHora(
            [FromRoute] Guid id,
            [FromBody] HistoricoValorHoraFornecedorRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _fornecedorService.AdicionarValorHoraAsync(id, request.ValorHora, request.DataInicio);

            return Ok(new { message = "Novo valor hora registrado com sucesso." });
        }

        /// <summary>
        /// Registra um serviço executado pelo fornecedor.
        /// </summary>
        /// <remarks>
        /// Esse endpoint registra um histórico contendo:
        /// Horas realizadas, valor recebido e data do serviço.
        /// </remarks>
        /// <param name="id">ID do fornecedor</param>
        /// <param name="request">Dados do serviço realizado</param>
        /// <response code="200">Serviço registrado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpPost("{id:guid}/servicos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegistrarServico(
            [FromRoute] Guid id,
            [FromBody] HistoricoServicoFornecedorRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _fornecedorService.RegistrarServicoAsync(id, request.HorasRealizadas, request.ValorRecebido, request.DataServico);

            return Ok(new { message = "Serviço registrado com sucesso." });
        }

        /// <summary>
        /// Desativa um fornecedor (soft delete).
        /// </summary>
        /// <param name="id">ID do fornecedor</param>
        /// <response code="200">Fornecedor desativado com sucesso</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DesativarFornecedor([FromRoute] Guid id)
        {
            await _fornecedorService.DesativarFornecedorAsync(id);

            return Ok(new { message = "Fornecedor desativado com sucesso." });
        }
    }
}
