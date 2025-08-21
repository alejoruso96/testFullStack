using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testFullStack.Models;

namespace testFullStack.Controllers
{
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ServicioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> Get()
        {
            try
            {
                List<Servicio> listaServicios = new List<Servicio>();
                listaServicios = await _dataContext.Servicio.ToListAsync();
                if (listaServicios != null && listaServicios.Count > 0)
                {
                    return Ok(listaServicios);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servicio:" + ex.Message);
            }
        }

        [HttpGet("Buscar/{nombre}")]
        public async Task<ActionResult<Servicio>> GetServicio(string nombre)
        {
            try
            {
                Servicio? servicio = await _dataContext.Servicio.FirstOrDefaultAsync(x => x.Nombre == nombre);

                if (servicio == null)
                {
                    return BadRequest("Servicio no encontrado");
                }
                else
                {
                    return Ok(servicio);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servicio:" + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostServicio(Servicio servicioDatos)
        {
            try
            {
                Servicio servicio = new Servicio
                {
                    Nombre = servicioDatos.Nombre,
                    Descripcion = servicioDatos.Descripcion
                };

                _dataContext.Servicio.Add(servicio);
                await _dataContext.SaveChangesAsync();
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor:" + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutServicio(Servicio servicioDatos)
        {
            try
            {
                Servicio? servicio;
                servicio = await _dataContext.Servicio.FirstOrDefaultAsync(x => x.Id == servicioDatos.Id);
                if (servicio == null)
                {
                    return NotFound("Servicio no encontrado");
                }
                else
                {
                    servicio.Nombre = servicioDatos.Nombre;
                    servicio.Descripcion = servicioDatos.Descripcion;
                }
                _dataContext.Servicio.Update(servicio);
                await _dataContext.SaveChangesAsync();
                return Ok(servicio);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor:" + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteServicio(int id)
        {
            try
            {
                Servicio? servicio;
                servicio = _dataContext.Servicio.FirstOrDefault(x => x.Id == id);

                if (servicio == null)
                {
                    return NotFound("Servicio no encontrado");
                }
                else
                {
                    _dataContext.Servicio.Remove(servicio);
                    await _dataContext.SaveChangesAsync();
                    return Ok("Servicio eliminado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor: " + ex.Message);
            }
        }
    }
}