using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testFullStack.Models;

namespace testFullStack.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ClienteController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            try
            {
                List<Cliente> listaClientes = new List<Cliente>();
                listaClientes = await _dataContext.Cliente.ToListAsync();
                if (listaClientes != null && listaClientes.Count > 0)
                {
                    return Ok(listaClientes);
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest("Error en el servicio:" +ex.Message);
            }
        }

        [HttpGet("Buscar/{correo}")]
        public async Task<ActionResult<Cliente>> GetCliente(string correo)
        {
            try
            {
                Cliente? cliente = await _dataContext.Cliente.FirstOrDefaultAsync(x => x.Correo == correo);

                if (cliente == null)
                {
                    return BadRequest("Cliente no encontrado");
                }
                else 
                {
                    return Ok(cliente);
                }

            }
            catch (Exception ex)
            {

                return BadRequest("Error en el servicio:" + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostClient(Cliente clienteDatos)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    Correo = clienteDatos.Correo,
                    Nombre = clienteDatos.Nombre
                };

                _dataContext.Cliente.Add(cliente);
                await _dataContext.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return BadRequest("Error en el servidor:" + ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> PutCliente(Cliente clienteDatos)
        {
            try
            {
                Cliente? cliente;
                cliente = await _dataContext.Cliente.FirstOrDefaultAsync(x => x.Id == clienteDatos.Id);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }
                else { 
                    cliente.Nombre = clienteDatos.Nombre;
                    cliente.Correo = clienteDatos.Correo;
                
                }
                _dataContext.Cliente.Update(cliente);
                await _dataContext.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return BadRequest("Error en el servidor:" + ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeteleCliente(int id)
        {
            try
            {
                Cliente? cliente;
                cliente = _dataContext.Cliente.FirstOrDefault(x => x.Id == id);

                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");

                }
                else {
                    _dataContext.Cliente.Remove(cliente);
                    await _dataContext.SaveChangesAsync();
                    return Ok("Cliente eliminado");
                }

            }
            catch (Exception ex)
            {

                return BadRequest("Error en el servidor: " + ex.Message);
            }
        }

    }
}
