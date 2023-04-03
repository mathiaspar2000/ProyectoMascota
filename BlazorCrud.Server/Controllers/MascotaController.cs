using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCrud.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly DbmascotasCrudBlazorContext _dbContext;

        public MascotaController(DbmascotasCrudBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responesApi = new ResponseAPI<List<MascotaDTO>>();
            var listaMascotaDTO = new List<MascotaDTO>();

            try
            {
                foreach (var item in await _dbContext.Mascota.Include(d => d.IdTipoNavigation).ToListAsync())
                {
                    listaMascotaDTO.Add(new MascotaDTO
                    {
                        IdMascota = item.IdMascota,
                        NombreMascota = item.NombreMascota,
                        NombreDueño = item.NombreDueño,
                        IdTipo = item.IdTipo,
                        Edad = item.Edad,
                        ValorPagar = item.ValorPagar,
                        FechaIngreso = item.FechaIngreso,
                        FechaSalida = item.FechaSalida,
                        Tipo = new TipoDTO
                        {
                            IdTipo = item.IdTipoNavigation.IdTipo,
                            TipoMascota = item.IdTipoNavigation.TipoMascota
                        }
                    });
                }
                responesApi.EsCorrecto = true;
                responesApi.Valor = listaMascotaDTO;
            }
            catch (Exception ex)
            {
                responesApi.EsCorrecto = false;
                responesApi.Mensaje = ex.Message;
            }

            return Ok(responesApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responesApi = new ResponseAPI<MascotaDTO>();
            var MascotaDTO = new MascotaDTO();

            try
            {
                var dbMascota = await _dbContext.Mascota.FirstOrDefaultAsync(x => x.IdMascota == id);
                if (dbMascota != null)
                {
                    MascotaDTO.IdMascota = dbMascota.IdMascota;
                    MascotaDTO.NombreMascota = dbMascota.NombreMascota;
                    MascotaDTO.NombreDueño = dbMascota.NombreDueño;
                    MascotaDTO.IdTipo = dbMascota.IdTipo;
                    MascotaDTO.Edad = dbMascota.Edad;
                    MascotaDTO.ValorPagar = dbMascota.ValorPagar;
                    MascotaDTO.FechaIngreso = dbMascota.FechaIngreso;
                    MascotaDTO.FechaSalida = dbMascota.FechaSalida;

                    responesApi.EsCorrecto = true;
                    responesApi.Valor = MascotaDTO;
                }
                else

                {
                    responesApi.EsCorrecto = false;
                    responesApi.Mensaje = "No encontrada";
                }


            }
            catch (Exception ex)
            {
                responesApi.EsCorrecto = false;
                responesApi.Mensaje = ex.Message;
            }

            return Ok(responesApi);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(MascotaDTO mascota)
        {
            var responesApi = new ResponseAPI<int>();

            try
            {
                var dbMascota = new Mascota
                {
                    IdMascota = mascota.IdMascota,
                    NombreMascota = mascota.NombreMascota,
                    NombreDueño = mascota.NombreDueño,
                    IdTipo = mascota.IdTipo,
                    Edad = mascota.Edad,
                    ValorPagar = mascota.ValorPagar,
                    FechaIngreso = mascota.FechaIngreso,
                    FechaSalida = mascota.FechaSalida,
                };
                _dbContext.Mascota.Add(dbMascota);
                await _dbContext.SaveChangesAsync();

                if (dbMascota.IdMascota != 0)
                {
                    responesApi.EsCorrecto = true;
                    responesApi.Valor = dbMascota.IdMascota;
                }
                else
                {
                    responesApi.EsCorrecto = false;
                    responesApi.Mensaje = "No guardado";
                }

            }
            catch (Exception ex)
            {
                responesApi.EsCorrecto = false;
                responesApi.Mensaje = ex.Message;
            }

            return Ok(responesApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(MascotaDTO mascota, int id)
        {
            var responesApi = new ResponseAPI<int>();

            try
            {
                var dbMascota = await _dbContext.Mascota.FirstOrDefaultAsync(e => e.IdMascota == id);



                if (dbMascota != null)
                {
                    dbMascota.IdMascota = dbMascota.IdMascota;
                    dbMascota.NombreMascota = dbMascota.NombreMascota;
                    dbMascota.NombreDueño = dbMascota.NombreDueño;
                    dbMascota.IdTipo = dbMascota.IdTipo;
                    dbMascota.Edad = dbMascota.Edad;
                    dbMascota.ValorPagar = dbMascota.ValorPagar;
                    dbMascota.FechaIngreso = dbMascota.FechaIngreso;
                    dbMascota.FechaSalida = dbMascota.FechaSalida;
             

                    _dbContext.Mascota.Update(dbMascota);
                    await _dbContext.SaveChangesAsync();

                    responesApi.EsCorrecto = true;
                    responesApi.Valor = dbMascota.IdMascota;
                }
                else
                {
                    responesApi.EsCorrecto = false;
                    responesApi.Mensaje = "Mascota no encontrada";
                }

            }
            catch (Exception ex)
            {
                responesApi.EsCorrecto = false;
                responesApi.Mensaje = ex.Message;
            }

            return Ok(responesApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responesApi = new ResponseAPI<int>();

            try
            {
                var dbMascota = await _dbContext.Mascota.FirstOrDefaultAsync(e => e.IdMascota == id);



                if (dbMascota != null)
                {


                    _dbContext.Mascota.Remove(dbMascota);
                    await _dbContext.SaveChangesAsync();

                    responesApi.EsCorrecto = true;
                }
                else
                {
                    responesApi.EsCorrecto = false;
                    responesApi.Mensaje = "Mascota no encontrada";
                }

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
