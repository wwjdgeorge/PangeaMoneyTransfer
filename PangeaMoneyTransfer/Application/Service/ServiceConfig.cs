using Microsoft.Extensions.Logging;
using PangeaMoneyTransfer.DomainModels.RequestModels;
using PangeaMoneyTransfer.Interfaces.Application.Service;
using System.Text.Json;

namespace PangeaMoneyTransfer.Application.Service
{
    public class ServiceConfig : IServiceConfig
    {
        private readonly ILogger<ServiceConfig> _logger;

        public ServiceConfig(ILogger<ServiceConfig> logger)
        {
            _logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<PartnerRate> PartnerRates, string ErrorMessage)> JsonDeserializeAsync()
        {
            try
            {
                _logger?.LogInformation("Deserialize JSON File");
                string fileName = "WeatherForecast.json";
                using FileStream openStream = File.OpenRead(fileName);
                var PartnerRates = await JsonSerializer.DeserializeAsync<IEnumerable<PartnerRate>>(openStream);
                if (PartnerRates.Any())
                {
                    return (true, PartnerRates, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
