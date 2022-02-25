using Bglobal.Data;
using Bglobal.Data.Entities;
using Bglobal.Data.Manager;
using Bglobal.Web.Helpers;
using Bglobal.Web.Interfaces;
using Bglobal.Web.Models.Comunes;
using Bglobal.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bglobal.Web.Models
{
    public class VehiculosModel : IModel<VehiculoViewModel>
    {
        private Vehiculos_Manager manager;

        public VehiculosModel()
        {
            this.manager = new Vehiculos_Manager();
        }

        /// <summary>
        /// Obtiene un listao de Vehiculos en base
        /// </summary>
        public async Task<IList<VehiculoViewModel>> BuscarAsync(VehiculoViewModel entityModel)
        {
            try
            {
                // Busco registro en base
                var vehiculosDto = await manager.BuscarAsync(new Vehiculo() { Id = entityModel.Id });

                // Valido error
                if (vehiculosDto == null)
                    throw new ApplicationException("Error al buscar los vehículos");

                var listadoVehiculos = new List<VehiculoViewModel>();

                // Obtengo los titulares
                var listadoTitulares = await this.ObtenerTitulares();

                // Mapeo vehículos dto a viewmodel
                foreach (var vehiculo in vehiculosDto)
                {
                    var vehiculoViewModel = new VehiculoViewModel();

                    // Mapeo propiedades entre propiedades
                    MapperHelper.CopyProperties(vehiculo, vehiculoViewModel);

                    // Busco el titular del vehículo
                    vehiculoViewModel.Titular = listadoTitulares.Where(m => m.Id == vehiculoViewModel.Id_Titular).FirstOrDefault();

                    // Agrego vehículo a listado
                    listadoVehiculos.Add(vehiculoViewModel);
                }

                return listadoVehiculos;
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "VehiculosModel", "BuscarAsync");
                return null;
            }
        }

        /// <summary>
        /// Guarda registro en base
        /// </summary>
        public async Task<bool> GuardarAsync(VehiculoViewModel entityModel)
        {
            try
            {
                var vehiculo = new Vehiculo();

                // Mapeo propiedades entre propiedades
                MapperHelper.CopyProperties(entityModel, vehiculo);

                // Guarda el registro en base
                return await this.manager.GuardarAsync(vehiculo, vehiculo.Id == 0);
            }
            catch(Exception ex)
            {
                LogHelper.LogError(ex, "VehiculosModel", "GuardarAsync");
                return false;
            }
        }

        /// <summary>
        /// Devuelve un listado de titulares en https://reqres.in/api/users"
        /// </summary>
        public async Task<List<Titular>> ObtenerTitulares()
        {
            try
            {
                var titulares = new List<Titular>(); ;

                // Llamada a la api para obtener los titulares
                var response = await ApiHelper.GetRequest("https://reqres.in/api/users");

                // Obtengo el nodo data del json
                var titularesJson = JObject.Parse(response)["data"].Children();

                // Agrego al listado cada titular
                foreach (var titular in titularesJson)
                {
                    var titularParse = JsonConvert.DeserializeObject<Titular>(titular.ToString());
                    titulares.Add(titularParse);
                }

                return titulares;
            }
            catch(Exception ex)
            {
                LogHelper.LogError(ex, "VehiculosModel", "ObtenerTitulares");
                return null;
            }

        }
    }
}
