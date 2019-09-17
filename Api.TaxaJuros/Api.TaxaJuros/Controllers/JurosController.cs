using Microsoft.AspNetCore.Mvc;

namespace Api.TaxaJuros.Controllers
{
    [Produces("application/json")]
    [Route("")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        /// <summary>
        /// Retorna taxa de juros.
        /// </summary>
        /// <param name="taxaJuros">Taxa de juros</param>
        /// <returns>Retorna o juros de 1% ou 0,01.</returns>
        [HttpGet("taxajuros")]
        public IActionResult GetTaxaJuros()
        {
            try
            {
                return Ok(0.01m);
            }
            catch (System.Exception ex)
            {
                return BadRequest("Algo deu errado." + ex.Message);
            }
        }
    }
}
