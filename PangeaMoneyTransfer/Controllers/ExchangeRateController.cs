using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PangeaMoneyTransfer.Interfaces.Application.Service;

namespace PangeaMoneyTransfer.Controllers
{
    [Route("api/exchange-rates")]
    public class ExchangeRateController : BaseController
    {
        private readonly IExchangeService _exchangeService;

      

        public ExchangeRateController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet("{country}")]
        public async Task<IActionResult> GetExchangeRates(string country)
        {
          var exchangeServiceResult =  await _exchangeService.ExchangeRatesAsync(country);
            if(exchangeServiceResult.isSuccess)
            {
                return Ok(exchangeServiceResult.rates);
            }
            return NotFound();
        }
    }
}
