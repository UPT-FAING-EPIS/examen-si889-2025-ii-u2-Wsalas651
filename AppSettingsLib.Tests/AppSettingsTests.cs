using Xunit;
using AppSettingsLib;

namespace AppSettingsLib.Tests
{
    public class AppSettingsTests
    {
        [Fact]
        public void CrearConfiguracion_DeberiaRetornarResumenCorrecto()
        {
            AppSettings.Instance.Configure("Producción", "https://api.miapp.com");

            var resumen = AppSettings.Instance.GetSummary();

            Assert.Equal("Entorno: Producción, API: https://api.miapp.com", resumen);
        }

        [Fact]
        public void CambiarConfiguracion_DeberiaActualizarValores()
        {
            AppSettings.Instance.Configure("Desarrollo", "http://localhost:5000");
            // cambiar configuración a QA
            AppSettings.Instance.Configure("QA", "https://qa.api.miapp.com");

            var resumen = AppSettings.Instance.GetSummary();

            Assert.Equal("Entorno: QA, API: https://qa.api.miapp.com", resumen);
        }
    }
}
