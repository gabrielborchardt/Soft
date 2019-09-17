using Api.CalculaJuros.Controllers;
using Api.CalculaJuros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace Tdd.CalculaJuros
{
    public class JurosTest
    {
        private readonly ServiceSettings _serviceSettings;
        private readonly string _myGitHub = "https://github.com/gabrielborchardt/Soft";

        public JurosTest()
        {
            var serviceSettings = new ServiceSettings()
            {
                BaseUrl = "http://gabrielborchardt-001-site1.itempurl.com/",
                RouteTaxa = "taxajuros"
            };

            _serviceSettings = serviceSettings;
        }

        [Fact]
        public async Task TestCalculoJuros()
        {
            var options = Options.Create<ServiceSettings>(_serviceSettings);

            var controller = new CalcularController(options);

            // Arrange
            var valorInicial = 100;
            var tempoMeses = 5;

            // Act
            var response = await controller.GetJuros(valorInicial, tempoMeses) as ObjectResult;
            var value = response.Value;

            // Assert
            Assert.Equal(value, (decimal)105.10);

        }

        [Fact]
        public async Task TestUrlGitHub()
        {
            var options = Options.Create<ServiceSettings>(_serviceSettings);

            var controller = new CalcularController(options);

            // Act
            var response = await controller.GetUrlGitHub() as ObjectResult;
            var value = response.Value;

            // Assert
            Assert.Equal(value, _myGitHub);

        }
    }
}
