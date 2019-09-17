using Api.CalculaJuros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.CalculaJuros.Controllers
{
    [Produces("application/json")]
    [Route("")]
    [ApiController]
    public class CalcularController : ControllerBase
    {
        private readonly IOptions<ServiceSettings> _serviceSettings;

        public CalcularController(IOptions<ServiceSettings> serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }

        /// <summary>
        /// Cálculo em memória de juros compostos.
        /// </summary>
        /// <param name="CalculaJuros">Calcular Juros</param>
        /// <returns>Retorna o cálculo do juros.</returns>
        [HttpGet("calculajuros")]
        public async Task<IActionResult> GetJuros(decimal valorInicial, int meses)
        {
            try
            {
                var apiTaxaJurosUri = string.Concat(_serviceSettings.Value.BaseUrl, _serviceSettings.Value.RouteTaxa);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(apiTaxaJurosUri);

                if (response.IsSuccessStatusCode)
                {
                    var juros = await response.Content.ReadAsAsync<decimal>();

                    var valPow = Math.Pow((double)(1 + juros), meses);
                    var valFinal = valorInicial * (decimal)valPow;
                    var valFinalTrunc = Math.Truncate(100 * valFinal) / 100;

                    return Ok(valFinalTrunc);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest("Algo deu errado." + ex.Message);
            }
        }

        [HttpGet("showmethecode")]
        public async Task<IActionResult> GetUrlGitHub()
        {
            try
            {
                return Ok("https://github.com/gabrielborchardt/Soft");
            }
            catch (System.Exception ex)
            {
                return BadRequest("Algo deu errado." + ex.Message);
            }
        }
    }
}
