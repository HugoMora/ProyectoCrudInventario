using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.AplicacionWeb.Models;
using ProyectoCrud.AplicacionWeb.Models.ViewModels;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.Models;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrud.AplicacionWeb.Controllers
{
    public class InventarioController : Controller
    {
        private readonly IIventarioService _InventarioService;

        public InventarioController(IIventarioService InventarioServ)
        {
            _InventarioService = InventarioServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<Inventario> queryInventarioSQL = await _InventarioService.ObtenerTodos();

            List<VMInventario> lista = queryInventarioSQL
                                                     .Select(c => new VMInventario()
                                                     {
                                                         CodCia = c.CodCia,
                                                         CompaniaVenta3=c.CompaniaVenta3,
                                                         AlmacenVenta =c.AlmacenVenta,
                                                         TipoMovimiento=c.TipoMovimiento,
                                                         TipoDocumento=c.TipoDocumento,
                                                         NroDocumento=c.NroDocumento,
                                                         CodItem2=c.CodItem2,
                                                         AlmacenDestino=c.AlmacenDestino,
                                                         Proveedor=c.Proveedor,
                                                         Cantidad=c.Cantidad,
                                                         FechaTransaccion = c.FechaTransaccion
                                                     }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }


        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMInventario modelo)
        {

            Inventario NuevoModelo = new Inventario()
            {
                CodCia = modelo.CodCia,
                CompaniaVenta3 = modelo.CompaniaVenta3,
                AlmacenVenta = modelo.AlmacenVenta,
                TipoMovimiento = modelo.TipoMovimiento,
                TipoDocumento = modelo.TipoDocumento,
                NroDocumento = modelo.NroDocumento,
                CodItem2 = modelo.CodItem2,
                Proveedor = modelo.Proveedor,
                Cantidad = modelo.Cantidad,
                FechaTransaccion = modelo.FechaTransaccion
            };

            bool respuesta = await _InventarioService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMInventario modelo)
        {

            Inventario NuevoModelo = new Inventario()
            {
                CodCia = modelo.CodCia,
                CompaniaVenta3 = modelo.CompaniaVenta3,
                AlmacenVenta = modelo.AlmacenVenta,
                TipoMovimiento = modelo.TipoMovimiento,
                TipoDocumento = modelo.TipoDocumento,
                NroDocumento = modelo.NroDocumento,
                CodItem2 = modelo.CodItem2,
                Proveedor = modelo.Proveedor,
                Cantidad = modelo.Cantidad,
                FechaTransaccion = modelo.FechaTransaccion
            };

            bool respuesta = await _InventarioService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        //[HttpDelete]
        //public async Task<IActionResult> Eliminar([FromBody] VMInventario modelo)
        //{

        //    bool respuesta = await _InventarioService.Eliminar(modelo);

        //    return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
