using Bglobal.Web.Models;
using Bglobal.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bglobal.UnitTest
{
    [TestClass]
    public class VehiculosUnitTest
    {
        private VehiculosModel logica = new VehiculosModel();

        [TestMethod]
        public async Task TestBuscarVehiculo()
        {
            var result = await this.logica.BuscarAsync(new VehiculoViewModel() { Id = 1});

            var marca = result.ElementAt(0).Marca.ToUpper();

            Assert.AreEqual("BMW", marca);
        }

        [TestMethod]
        public async Task TestGuardarVehiculo()
        {
            var vehiculo = new VehiculoViewModel()
            {
                Marca = "Volkswagen",
                Modelo = "Amarok CD",
                Patente = "ABC 123",
                Puertas = 4,
                Id_Titular = 3
            };

            var result = await this.logica.GuardarAsync(vehiculo);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task TestObtenerTitulares()
        {

            var result = await this.logica.ObtenerTitulares();

            Assert.AreEqual(true, result != null);
        }

    }
}
