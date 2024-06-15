using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebAPI.Token;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase {

        public ICUAutenticarUsuario CUAutenticar { get; set; }

        public UsuariosController(ICUAutenticarUsuario cuAutenticar)
        {
            CUAutenticar = cuAutenticar;
        }

        //--------------------------------------------------------------------------
        //---------------------------- INGRESAR ------------------------------------
        //--------------------------------------------------------------------------
        [HttpPost("Ingresar")]
        public IActionResult Ingresar([FromBody] UsuarioDTO usuarioDTO) {
            if (usuarioDTO == null) return BadRequest("Datos incorrectos");

            try {
                usuarioDTO = CUAutenticar.Autenticar(usuarioDTO.Email, usuarioDTO.Password);
                if (usuarioDTO == null) return NotFound("El usuario no existe");

                UsuarioAutenticadoDTO usuarioAutenticado = new UsuarioAutenticadoDTO();
                usuarioAutenticado.Tipo = usuarioDTO.Tipo;
                usuarioAutenticado.Email = usuarioDTO.Email;
                usuarioAutenticado.Token = TokenHandler.GenerarToken(usuarioDTO);

                return Ok(usuarioAutenticado);
            } catch (DatosInvalidosException e) {
                return BadRequest(e.Message);
            } catch {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        //    // GET: api/<UsuariosController>
        //    [HttpGet]
        //    public IEnumerable<string> Get() {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/<UsuariosController>/5
        //    [HttpGet("{id}")]
        //    public string Get(int id) {
        //        return "value";
        //    }

        //    // POST api/<UsuariosController>
        //    [HttpPost]
        //    public void Post([FromBody] string value) {
        //    }

        //    // PUT api/<UsuariosController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value) {
        //    }

        //    // DELETE api/<UsuariosController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id) {
        //    }
    }
}
