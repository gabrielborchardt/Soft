using Api.TaxaJuros.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace Tdd.TaxaJuros
{
    public class JurosTest
    {
        [Fact]
        public async Task TestGetTaxa()
        {
            // Arrange
            var controller = new JurosController();

            // Act
            var response = controller.GetTaxaJuros() as ObjectResult;
            var value = response.Value;

            // Assert
            Assert.Equal(value,(decimal)0.01);
        }
    }
}
