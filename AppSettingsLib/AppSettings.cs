using System;

namespace AppSettingsLib
{
    /// <summary>
    /// Singleton que mantiene la configuración de la aplicación.
    /// Use AppSettings.Instance.Configure(...) para establecer valores.
    /// </summary>
    public sealed class AppSettings
    {
        private static readonly Lazy<AppSettings> _instance = new(() => new AppSettings());

        public static AppSettings Instance => _instance.Value;

        public string Environment { get; private set; }
        public string ApiBaseUrl { get; private set; }

        // Constructor privado para impedir instanciación externa
        private AppSettings()
        {
            Environment = "Undefined";
            ApiBaseUrl = string.Empty;
        }

        /// <summary>
        /// Configura el singleton con los valores proporcionados.
        /// Se puede invocar repetidamente para cambiar la configuración en tiempo de ejecución.
        /// </summary>
        public void Configure(string environment, string apiBaseUrl)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
            ApiBaseUrl = apiBaseUrl ?? string.Empty;
        }

        public string GetSummary()
        {
            return $"Entorno: {Environment}, API: {ApiBaseUrl}";
        }
    }
}
