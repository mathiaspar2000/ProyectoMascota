using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCrud.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly DbmascotasCrudBlazorContext _dbContext;

        public TipoController(DbmascotasCrudBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responesApi = new ResponseAPI<List<TipoDTO>>();
            var listaTipoDTO = new List<TipoDTO>();

            try
            {
                foreach (var item in await _dbContext.Tipos.ToListAsync())
                {
                    listaTipoDTO.Add(new TipoDTO
                    {
                        IdTipo = item.IdTipo,
                        TipoMascota = item.TipoMascota,
                    });
                }
                responesApi.EsCorrecto = true;
                responesApi.Valor = listaTipoDTO;
            }
            catch (Exception ex)
            {
                responesApi.EsCorrecto = false;
                responesApi.Mensaje = ex.Message;
            }

            return Ok(responesApi);
        }
    }
}
