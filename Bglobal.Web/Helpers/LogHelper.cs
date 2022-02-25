namespace Bglobal.Web.Helpers
{
    public class LogHelper
    {
        #region Métodos públicos
        /// <summary>
        /// Salva el error en un .txt según fecha actual y módulo en D:\Logs
        /// </summary>
        public static void LogError(Exception ex, string modulo, string metodo)
        {
            try
            {
                // Crea la ruta donde guardar
                var ruta = string.Format(@"D:\Logs\{0:yyyy-MM-dd}\{1}", DateTime.Now, modulo);

                // Valida si existe para crear la carpeta
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);

                // Crea el .txt
                var archivo = string.Format(@"{0}\{1:yyyy-MM-dd}.txt", ruta, DateTime.Now);

                // Escribe el contenido
                var content = $"=====================================\n" +
                                $"---------{DateTime.Now:dd/MM/yyyy H:mm:ss}---------\n" +
                                $"Error: {ex.Message}\n" +
                                $"Módulo: {modulo}\n" +
                                $"Método: {metodo}\n" +
                                $"=====================================\n\n";

                // Agrega el contenido al .txt
                File.AppendAllText(archivo, content);
            }
            catch { }
        }
        #endregion

    }
}
