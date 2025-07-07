using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EditorJson.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class JsonController : ControllerBase
    {
       public class JsonRequest
    {
    public string Json { get; set; } = "";
    }

    
    [HttpPost("validar")]
        public IActionResult Validar([FromBody] JsonRequest request)
        {
            try
            {
            using var doc = JsonDocument.Parse(request.Json);
            var formatado = JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions

            {
            WriteIndented = true
            });

            return Ok(new{
            valido = true,
            jsonFormatado = formatado
            });}

            catch (JsonException e){
            // Retorna o erro de validação
            return BadRequest(new
            {
            valido = false,
            erro = e.Message
            });}}
 
    
    }
}
