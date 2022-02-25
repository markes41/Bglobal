namespace Bglobal.Web.Interfaces
{
    public interface IModel<T>
    {
        /// <summary>
        /// Intermediario para el guardado de un registro entre capa de datos y capa de negocio
        /// </summary>
        Task<bool> GuardarAsync(T entityModel);
        /// <summary>
        /// Intermediario para traer un listado de registros entre capa de datos y capa de negocio
        /// </summary>
        Task<IList<T>> BuscarAsync(T entityModel);
    }
}
