using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bglobal.Data.Manager.Base
{
    public class Base_Manager<T> where T : class
    {
        public readonly BglobalContext Context = new BglobalContext();

        public async Task<bool> GuardarAsync(T entity, bool isNew)
        {
            try
            {
                if (isNew)
                    this.Context.Entry<T>(entity).State = EntityState.Added;
                else
                    this.Context.Entry<T>(entity).State = EntityState.Modified;

                // Valida si se guardaron los datos
                return await this.Context.SaveChangesAsync() > 0;

            }
            catch(Exception ex)
            {
                throw new ValidationException("Ha ocurrido un error al guardar un registro." + ex.Message);
            }
        }
    }
}
