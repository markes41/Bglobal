using Bglobal.Data;
using Bglobal.Web.Helpers;
using Bglobal.Web.Models;
using Bglobal.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bglobal.Web.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly VehiculosModel logica;
        public VehiculosController()
        {
            this.logica = new VehiculosModel();
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var listado = await this.logica.BuscarAsync(new VehiculoViewModel());

                return View(listado);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "VehiculosController", "Index");
                return View(ex);
            }
        }

        public async Task<IActionResult> AgregarVehiculo()
        {
            try
            {
                var vehiculo = new VehiculoViewModel
                {
                    Titulares = await this.logica.ObtenerTitulares()
                };

                return View(vehiculo);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "VehiculosController", "AgregarVehiculo");
                return View("Index");
            }
        }

        public async Task<IActionResult> GuardarVehiculo(VehiculoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var saved = await this.logica.GuardarAsync(model);

                    return RedirectToAction("Index", "Vehiculos");
                }

                model.Titulares = await this.logica.ObtenerTitulares();
                return View("AgregarVehiculo", model);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "VehiculosController", "GuardarVehiculo");
                return View();
            }
        }
    }
}
