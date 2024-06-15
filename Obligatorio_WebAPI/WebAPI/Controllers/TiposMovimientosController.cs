using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TiposMovimientosController : ControllerBase {

        public ICUAlta<TipoMovimientoDTO> CUAlta { get; set; }
        public ICUBaja<TipoMovimientoDTO> CUBaja { get; set; }
        public ICUListado<TipoMovimientoDTO> CUListado { get; set; }
        public ICUModificar<TipoMovimientoDTO> CUModificar { get; set; }
        public ICUBuscarPorId<TipoMovimientoDTO> CUBuscarPorIdTM { get; set; }

        public TiposMovimientosController(
             ICUAlta<TipoMovimientoDTO> cuAlta,
             ICUBaja<TipoMovimientoDTO> cuBaja,
             ICUListado<TipoMovimientoDTO> cuListado,
             ICUModificar<TipoMovimientoDTO> cuModificar,
             ICUBuscarPorId<TipoMovimientoDTO> cuBuscarPorIdTM
        )
        {
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUListado = cuListado;
            CUModificar = cuModificar;
            CUBuscarPorIdTM = cuBuscarPorIdTM;
        }

        // GET: api/<TiposMovimientosController>
        [HttpGet]
        public IActionResult Get() {
            List<TipoMovimientoDTO> tm = CUListado.ObtenerListado();
            return Ok(tm);
        }

        // GET api/<TiposMovimientosController>/5
        [HttpGet("{id}", Name = "BuscarPorIdTM")]
        public IActionResult Get(int id) {
            if (id <= 0) return BadRequest("El id deber ser positivo");
            TipoMovimientoDTO tm = CUBuscarPorIdTM.BuscarPorId(id);
            if (tm == null) return NotFound("El tipo de movimiento no existe");
            return Ok(tm);
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------

        // POST api/<TiposMovimientosController>
        [HttpPost]
        public IActionResult Post([FromBody] TipoMovimientoDTO tmDTO) {
            if (tmDTO == null) return BadRequest("Faltan datos requeridos para el alta");

            try {
                CUAlta.Alta(tmDTO);
                return CreatedAtRoute("BuscarPorIdTM", new { id = tmDTO.Id }, tmDTO);
            } catch (DuplicadoException e) {
                return BadRequest(e.Message);
            } catch (Exception e) {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        //--------------------------------------------------------------------------
        //----------------------------- UPDATE -------------------------------------
        //--------------------------------------------------------------------------

        // PUT api/<TiposMovimientosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoMovimientoDTO tmDTO) {
            if (id <= 0) return BadRequest("El id debe ser positivo");
            if (tmDTO == null) return BadRequest("Faltan datos requeridos para la modificación");

            try {
                CUModificar.Modificar(tmDTO);
                return Ok(tmDTO);
            } catch (DuplicadoException e) {
                return BadRequest(e.Message);
            } catch (Exception e) {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        //--------------------------------------------------------------------------
        //----------------------------- DELETE -------------------------------------
        //--------------------------------------------------------------------------

        // DELETE api/<TiposMovimientosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            if (id <= 0) return BadRequest("El id debe ser positivo");

            try {
                TipoMovimientoDTO aBorrar = CUBuscarPorIdTM.BuscarPorId(id);
                if (aBorrar == null) return NotFound("El tipo de movimiento no existe");
                CUBaja.Baja(id);
                return NoContent();
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}
