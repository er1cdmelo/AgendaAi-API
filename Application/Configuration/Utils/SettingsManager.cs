namespace Application.Configuration.Utils
{
    public class SettingsManager
    {
        // Essa classe é um gerenciador de configurações que pega as configurações do arquivo appsettings.json

        private readonly IConfiguration _configuration;
        public SettingsManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetStringValue(string key)
        {
            return _configuration[key] ?? "";
        }

        public int GetIntValue(string key)
        {
            return int.Parse(_configuration[key] ?? "0");
        }

        public bool GetBoolValue(string key)
        {
            return bool.Parse(_configuration[key] ?? "false");
        }
    }
}
