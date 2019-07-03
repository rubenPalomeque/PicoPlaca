using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PyPWeb.Clases;

namespace PyPWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicoPlacaController : ControllerBase
    {
        // GET: api/PicoPlaca
        [HttpGet]
        public IEnumerable<string> Get(string placa, string fecha, string hora)
        {
            if (string.IsNullOrEmpty(placa))
                return new string[] { "Error: placa" };
            if (string.IsNullOrEmpty(fecha))
                return new string[] { "Error: fecha" };
            if (string.IsNullOrEmpty(hora))
                return new string[] { "Error: hora" };

            var helper = new PicoPlacaHelper();
            return helper.PuedeCircular(placa, fecha, hora);
        }
    }
}
