using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PangeaMoneyTransfer.Application.Service;
using PangeaMoneyTransfer.Controllers;
using PangeaMoneyTransfer.Interfaces.Application.Service;

namespace PangeaMoneyTransfer.Tests.Controller
{
    public class ExchangeRateControllerTest
    {
   

        [Fact] 
        public void DetailsUnitTest()
        {
            //arrange
            var mockExchangeService = new Mock<IExchangeService>();

            //act
            //assert 
        }
    }
}