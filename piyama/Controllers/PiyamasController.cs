using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using piyama.models;

namespace piyama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiyamasController : ControllerBase
    {
        //Variable de contexto de BD
        private readonly PiyamaenContext _baseDatos;
        public PiyamasController(PiyamaenContext baseDatos)
        {
            this._baseDatos = baseDatos;
        }

        //metodos GET ListaPiyama
        [HttpGet]
        [Route("ListaPiyama")]
        public async Task<IActionResult> Lista()
        {
            var listaPiyama = await _baseDatos.Piyamas.ToListAsync();

            return Ok(listaPiyama);

        }

    }
}
