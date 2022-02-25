using AutoMapper;
using Bglobal.Data.Entities;
using Bglobal.Web.ViewModels;
using System.Reflection;

namespace Bglobal.Web.Helpers
{
    public static class MapperHelper
    {
        #region Métodos públicos
        /// <summary>
        /// Intercambia valores entre dos objetos que compartan propiedades con mismo nombre
        /// Ej: ViewModel - Model
        /// </summary>
        public static void CopyProperties(this object source, object destination)
        {
            try
            {
                // Se valida valores null
                if (source == null || destination == null)
                    throw new Exception("El objeto base y/o destino son null.");

                // Obtengo los tipos de datos
                var typeDest = destination.GetType();
                var typeSrc = source.GetType();

                // Se obtiene las properties y se itera
                var srcProps = typeSrc.GetProperties();
                foreach (PropertyInfo srcProp in srcProps)
                {
                    if (!srcProp.CanRead)
                        continue;

                    PropertyInfo targetProperty = typeDest.GetProperty(srcProp.Name);

                    // Valida posibles errores
                    if (targetProperty == null)
                        continue;

                    if (!targetProperty.CanWrite)
                        continue;

                    if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                        continue;

                    if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                        continue;

                    if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                        continue;

                    // Setea la propiedad al objeto destination
                    targetProperty.SetValue(destination, srcProp.GetValue(source, null), null);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex, "Mapper", "CopyProperties");
            }
        }
        #endregion
    }
}
