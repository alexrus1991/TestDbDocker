using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebAppDocker.DTO.Models;
using WebAppDocker.Models;

namespace WebAppDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProduitController(TestApiDbContext _context) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
         
            return Ok(_context.Produits);
        }

        [HttpPost]
        public IActionResult AddProduit(ProduitDTO produitDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                Produit p = produitDTO.Adapt<Produit>();
                _context.Produits.Add(p);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
