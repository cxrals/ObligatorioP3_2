using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosStockController : ControllerBase {
        public ICUAlta<MovimientoStockDTO> CUAlta { get; set; }
        public ICUListado<MovimientoStockIndexDTO> CUListado { get; set; }
        public ICUBuscarPorId<MovimientoStockDTO> CUBuscarPorIdMS { get; set; }

        public MovimientosStockController(
            ICUAlta<MovimientoStockDTO> cuAlta, 
            ICUListado<MovimientoStockIndexDTO> cuListado, 
            ICUBuscarPorId<MovimientoStockDTO> cuBuscarPorIdMS
        ){
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUBuscarPorIdMS = cuBuscarPorIdMS;
        }


        // GET: api/<MovimientosStockController>
        [HttpGet]
        public IActionResult Get() {
            List<MovimientoStockIndexDTO> movimientosStock = CUListado.ObtenerListado();
            return Ok(movimientosStock);
        }

        // GET api/<MovimientosStockController>/5
        [HttpGet("{id}", Name = "BuscarPorId")]
        public IActionResult Get(int id) {
            if (id <= 0) return BadRequest("El id deber ser positivo");
            MovimientoStockDTO msDTO = CUBuscarPorIdMS.BuscarPorId(id);
            if (msDTO == null) return NotFound("El tipo de movimiento no existe");
            return Ok(msDTO);
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------

        // POST api/<MovimientosStockController>
        [HttpPost]
        public IActionResult Post([FromBody] MovimientoStockDTO msDTO) {
            if (msDTO == null) return BadRequest("Faltan datos requeridos para el alta");
            if (msDTO.ArticuloId <= 0) return BadRequest("El artículo es requerido para el alta");

            try {
                CUAlta.Alta(msDTO);
                return CreatedAtRoute("BuscarPorId", new { id = msDTO.Id }, msDTO);
            } catch (DuplicadoException e) {
                return BadRequest(e.Message);
            } catch (Exception e) {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }
    }
}
