using ToyStoreAPI.Data;
using ToyStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyStoreAPI.Dto;

namespace ToyStoreAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        private readonly ToyContext _context;

        public ToysController(ToyContext context)
        {
            _context = context;
        }

        // GET: /toys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toy>>> GetToys()
        {
            try
            {
                var toys = await _context.Toys.ToListAsync();
                return Ok(toys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar brinquedos: {ex.Message}");
            }
        }

        // GET: /toys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToy(int id)
        {
            try
            {
                var toy = await _context.Toys.FindAsync(id);
                if (toy == null) return NotFound("Brinquedo não encontrado.");

                return Ok(toy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar brinquedo: {ex.Message}");
            }
        }

        // POST: /toys
        [HttpPost]
        public async Task<ActionResult<Toy>> PostToy(ToyDto toyDto)
        {
            try
            {
                if (toyDto == null) return BadRequest("Dados inválidos.");

                // Validações manuais dos atributos obrigatórios
                if (string.IsNullOrWhiteSpace(toyDto.NameToy))
                    return BadRequest("O nome do brinquedo é obrigatório.");

                if (toyDto.Price <= 0)
                    return BadRequest("O preço do brinquedo deve ser maior que zero.");

                var toy = new Toy
                {
                    NameToy = toyDto.NameToy,
                    TypeToy = toyDto.TypeToy,
                    Rating = toyDto.Rating,
                    ToySize = toyDto.ToySize,
                    Price = toyDto.Price
                };

                _context.Toys.Add(toy);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetToy), new { id = toy.IdToy }, toy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar brinquedo: {ex.Message}");
            }
        }

        // PUT: /toys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToy(int id, ToyDto toyDto)
        {
            try
            {
                if (toyDto == null) return BadRequest("Dados inválidos.");

                var toy = await _context.Toys.FindAsync(id);
                if (toy == null) return NotFound("Brinquedo não encontrado.");

                // Validações manuais dos atributos obrigatórios
                if (string.IsNullOrWhiteSpace(toyDto.NameToy))
                    return BadRequest("O nome do brinquedo é obrigatório.");

                if (toyDto.Price <= 0)
                    return BadRequest("O preço do brinquedo deve ser maior que zero.");

                toy.NameToy = toyDto.NameToy;
                toy.TypeToy = toyDto.TypeToy;
                toy.Rating = toyDto.Rating;
                toy.ToySize = toyDto.ToySize;
                toy.Price = toyDto.Price;

                await _context.SaveChangesAsync();

                return Ok(toy);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Toys.Any(e => e.IdToy == id)) return NotFound("Brinquedo não encontrado.");
                return StatusCode(500, "Erro de concorrência ao atualizar brinquedo.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar brinquedo: {ex.Message}");
            }
        }

        // DELETE: /toys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToy(int id)
        {
            try
            {
                var toy = await _context.Toys.FindAsync(id);
                if (toy == null) return NotFound("Brinquedo não encontrado.");

                _context.Toys.Remove(toy);
                await _context.SaveChangesAsync();

                return Ok("Brinquedo deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar brinquedo: {ex.Message}");
            }
        }
    }
}
