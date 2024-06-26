﻿using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosStockController : ControllerBase {
        public ICUAlta<MovimientoStockDTO> CUAlta { get; set; }
        public ICUListado<MovimientoStockIndexDTO> CUListado { get; set; }
        public ICUBuscarPorId<MovimientoStockDTO> CUBuscarPorIdMS { get; set; }
        public ICUBuscarPorFechaMovimiento CUBuscarPorFecha { get; set; }
        public ICUBuscarPorArticuloYTipoMovimiento CUBuscarPorArticuloYTipo { get; set; }
        public ICUResumenMovimientos CUResumenMovimientos { get; set; }
        public ICUCantidadDePaginas CUCantidadDePaginas { get; set; }
        

        public MovimientosStockController(
            ICUAlta<MovimientoStockDTO> cuAlta,
            ICUListado<MovimientoStockIndexDTO> cuListado,
            ICUBuscarPorId<MovimientoStockDTO> cuBuscarPorIdMS,
            ICUBuscarPorFechaMovimiento cuBuscarPorFecha,
            ICUBuscarPorArticuloYTipoMovimiento cuBuscarPorArticuloYTipo,
            ICUResumenMovimientos cuResumenMovimientos,
            ICUCantidadDePaginas cuCantidadPaginas
        ) {
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUBuscarPorIdMS = cuBuscarPorIdMS;
            CUBuscarPorFecha = cuBuscarPorFecha;
            CUBuscarPorArticuloYTipo = cuBuscarPorArticuloYTipo;
            CUResumenMovimientos = cuResumenMovimientos;
            CUCantidadDePaginas = cuCantidadPaginas;
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
            if (msDTO == null) return NotFound("El movimiento de stock no existe");
            return Ok(msDTO);
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------

        // POST api/<MovimientosStockController>
        [HttpPost]
        [Authorize(Roles = "Encargado")]
        public IActionResult Post([FromBody] MovimientoStockDTO msDTO) {
            if (msDTO == null) return BadRequest("Faltan datos requeridos para el alta");
            if (msDTO.ArticuloId <= 0) return BadRequest("El artículo es requerido para el alta");

            try {
                CUAlta.Alta(msDTO);
                return CreatedAtRoute("BuscarPorId", new { id = msDTO.Id }, msDTO);
            } catch (DatosInvalidosException e) {
                return BadRequest(e.Message);
            } catch (DuplicadoException e) {
                return BadRequest(e.Message);
            } catch (Exception e) {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        //--------------------------------------------------------------------------
        //----------------------------- BUSCAR -------------------------------------
        //--------------------------------------------------------------------------
        [HttpGet("MovimientosPorFecha/{desde}/{hasta}/{page}")]
        [Authorize(Roles ="Encargado")]
        public IActionResult MovimientosPorFecha(string desde, string hasta, int page) {
            DateTime fechaDesde = DateTime.Parse(desde);
            DateTime fechaHasta = DateTime.Parse(hasta);

            if (desde == null || hasta == null) return BadRequest("Las fechas son requeridas.");
            try {
                List<ArticuloDTO> articulos = CUBuscarPorFecha.BuscarPorFecha(fechaDesde, fechaHasta, page);
                if (articulos == null) return NotFound("No existen movimientos para las fechas seleccionadas.");
                return Ok(articulos);
            } catch {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        [HttpGet("MovimientosPorArticuloYTipo/{articuloId}/{tipoMovimiento}/{page}")]
        [Authorize(Roles = "Encargado")]
        public IActionResult MovimientosPorArticuloYTipo(int articuloId, string tipoMovimiento, int page) {
            if (articuloId <= 0 || String.IsNullOrEmpty(tipoMovimiento)) return BadRequest("Artículo y tipo de movimiento son requeridos.");
            try {
                List<MovimientoStockIndexDTO> movimientos = CUBuscarPorArticuloYTipo.BuscarMovimientosPorArticuloYTipo(articuloId, tipoMovimiento, page);
                if (movimientos == null) return NotFound("No existen movimientos para la combinacion de Artículo y tipo de movimiento seleccionados.");
                return Ok(movimientos);
            } catch {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        //--------------------------------------------------------------------------
        //----------------------------- RESUMEN ------------------------------------
        //--------------------------------------------------------------------------
        [HttpGet("ResumenMovimientos/")]
        [Authorize(Roles = "Encargado")]
        public IActionResult ResumenMovimientos() {
            try {
                List<MovimientoCantidadPorAnioYTipoDTO> movimientos = CUResumenMovimientos.ObtenerResumen();
                return Ok(movimientos);
            } catch (RegistroNoExisteException e) {
                return NotFound(e.Message);
            } catch {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        //--------------------------------------------------------------------------
        //--------------------------- PAGINACIÓN -----------------------------------
        //--------------------------------------------------------------------------
        [HttpGet("CantidadDePaginas/{articuloId}/{tipoMovimiento}")]
        public IActionResult CantidadDePaginas(int articuloId, string tipoMovimiento) {
            try {
                double cantidad = CUCantidadDePaginas.ObtenerCantidadDePaginas(articuloId, tipoMovimiento);
                return Ok(cantidad);
            } catch (Exception ex) {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }

        //--------------------------------------------------------------------------
        //--------------------------- PAGINACIÓN -----------------------------------
        //--------------------------------------------------------------------------
        [HttpGet("CantidadDePaginasFechas/{articuloId}/{tipoMovimiento}")]
        public IActionResult CantidadDePaginas(string articuloId, string tipoMovimiento) {
            try {
                double cantidad = CUCantidadDePaginas.ObtenerCantidadDePaginas(articuloId, tipoMovimiento);
                return Ok(cantidad);
            } catch (Exception ex) {
                return StatusCode(500, "Ocurrió un error inesperado en el servidor. Reintente más tarde.");
            }
        }
    }
}
