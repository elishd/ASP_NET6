using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemplateNet6.Application.InterfacesServices;
using TemplateNet6.Application.UseCase;
using TemplateNet6.Domain.Constants;
using TemplateNet6.Domain.Entities.TipoCuenta;
using TemplateNet6.Domain.Exceptions.TipoCuenta;
using TemplateNet6.WebApi.Models.Request.TipoCuenta;
using TemplateNet6.WebApi.Models.Response;

namespace TemplateNet6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCuentaController : ControllerBase
    {
        #region ATRIBUTES
        private readonly ITipoCuentaUseCase _tipoCuentaUseCase;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public TipoCuentaController(ITipoCuentaUseCase tipoCuentaUseCase, ILoggerService loggerService, IMapper mapper)
        {
            _tipoCuentaUseCase = tipoCuentaUseCase ?? throw new ArgumentNullException(nameof(tipoCuentaUseCase));
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region METHODS
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetByCodigoAsync(int codigo)
        {
            try
            {
                var dato = _mapper.Map<TipoCuentaSelectRequest>(await _tipoCuentaUseCase.GetByCodigoAsync(codigo));
                return Ok(new ResposeGeneric(ResponseCodeConstant.EXITO, dato));
            }
            catch (Exception ex)
            {
                _loggerService.ErrorObj(LoggerConstant.ERROR_DESCONOCIDO, new { Codigo = codigo }, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, $"Ha ocurrido un error en: GetById({codigo})"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var datos = _mapper.Map<List<TipoCuentaSelectRequest>>(await _tipoCuentaUseCase.GetAllAsync());
                return Ok(new ResposeGeneric(ResponseCodeConstant.EXITO, datos));
            }
            catch (Exception ex)
            {
                _loggerService.ErrorObj(LoggerConstant.ERROR_DESCONOCIDO, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, $"Ha ocurrido un error en: GetAllAsync"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(TipoCuentaInsertRequest request)
        {
            try
            {
                var codigo = await _tipoCuentaUseCase.InsertAsync(_mapper.Map<TipoCuenta>(request));
                return Ok(new ResposeGeneric(ResponseCodeConstant.EXITO, codigo));
            }
            catch (Exception ex)
            {
                _loggerService.ErrorObj(LoggerConstant.ERROR_DESCONOCIDO, request, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, $"Ha ocurrido un error en: InsertAsync({request.Nombre})"));
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(TipoCuentaUpdateRequest request)
        {
            try
            {
                var filasActualizadas = await _tipoCuentaUseCase.UpdateAsync(_mapper.Map<TipoCuenta>(request));
                return Ok(new ResposeGeneric(ResponseCodeConstant.EXITO, filasActualizadas));
            }
            catch(TipoCuentaNoEncontradaException ex)
            {
                return NotFound(new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, ex.Message, 0));
            }
            catch (Exception ex)
            {
                _loggerService.ErrorObj(LoggerConstant.ERROR_DESCONOCIDO, request, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, $"Ha ocurrido un error en: UpdateAsync({request.Codigo})"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> InsertOrUpdateAsync(TipoCuentaUpdateRequest request)
        {
            try
            {
                var filasActualizadas = await _tipoCuentaUseCase.UpdateAsync(_mapper.Map<TipoCuenta>(request));
                return Ok(new ResposeGeneric(ResponseCodeConstant.EXITO, filasActualizadas));
            }
            catch (TipoCuentaNoEncontradaException ex)
            {
                return NotFound(new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, ex.Message, 0));
            }
            catch (Exception ex)
            {
                _loggerService.ErrorObj(LoggerConstant.ERROR_DESCONOCIDO, request, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, $"Ha ocurrido un error en: UpdateAsync({request.Codigo})"));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(TipoCuentaDeleteRequest request)
        {
            try
            {
                var filasEliminadas = await _tipoCuentaUseCase.DeleteAsync(_mapper.Map<TipoCuenta>(request));
                return Ok(new ResposeGeneric(ResponseCodeConstant.EXITO, filasEliminadas));
            }
            catch (TipoCuentaNoEncontradaException ex)
            {
                return NotFound(new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, ex.Message, 0));
            }
            catch (Exception ex)
            {
                _loggerService.ErrorObj(LoggerConstant.ERROR_DESCONOCIDO, request, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ResposeGeneric(ResponseCodeConstant.ERROR.Codigo, $"Ha ocurrido un error en: DeleteAsync({request.Codigo})"));
            }
        }
        #endregion
    }
}
