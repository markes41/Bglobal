using Bglobal.Data.Entities;
using Bglobal.Data.Manager.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bglobal.Data.Manager
{
    public class Vehiculos_Manager : Base_Manager<Vehiculo>
    {
        public async Task<IList<Vehiculo>> BuscarAsync(Vehiculo entity)
        {
            return await base.Context.Vehiculos.Where(m => 
                m.Id == entity.Id || entity.Id == 0).ToListAsync();
        }
    }
}
