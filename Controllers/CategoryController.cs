using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly AppDbContext _context;

    // Construtor que injeta o contexto do banco de dados
    public CategoryController(AppDbContext context)
    {
      _context = context;
    }

    // GET ALL: api/categoria
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      try
      {
        // Busca todas as categorias e inclui os produtos relacionados
        var categories = await _context.Categories.Include(p => p.Products).ToListAsync(); 

        if (!categories.Any()) // Verifica se há categorias disponíveis
        {
            return NotFound("Nenhuma categoria encontrada.");
        }

        // Retorna a lista de categorias e uma mensagem de sucesso
        return Ok(new {message = "Categorias encontradas com sucesso!", categories}); 
      }
      catch (Exception ex)
      {
        // Trata erros inesperados e retorna código de status 500
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });  
      }
    }

    // GET DETAILS BY ID: api/categoria/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        try
        {
          // Busca uma categoria específica pelo ID, incluindo os produtos relacionados
          var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);
            
          if (category == null) // Verifica se a categoria existe
          {
              return NotFound("Categoria não encontrada.");
          }

          // Retorna a categoria encontrada com uma mensagem de sucesso
          return Ok(new {message = "Categoria encontrada com sucesso!", category}); 
        }
        catch (Exception ex)
        {
          // Trata erros inesperados e retorna código de status 500
          return StatusCode(500, new
          {
            message = "Ocorreu um erro ao processar a requisição.",
            error = ex.Message
          });  
        }
    }

    // POST: api/categoria
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
      try
      {
        if (category == null) // Valida se a categoria foi informada
        {
          return BadRequest("Categoria não informada.");
        }

        // Adiciona a nova categoria ao contexto do banco de dados
        _context.Categories.Add(category);
        await _context.SaveChangesAsync(); // Persiste a nova categoria no banco de dados

        // Retorna a categoria criada com código 201 (Created)
        return CreatedAtAction(nameof(GetCategory), new { id = category.Id },  new {message = "Categoria criada com sucesso!", category}); 
      }
      catch (Exception ex)
      {
        // Trata erros inesperados e retorna código de status 500
        return StatusCode(500, new 
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });
      }
    }

    // PUT: api/categoria/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Category category)
    {
        if (category == null) // Valida se a categoria foi informada
        {
            return BadRequest("Categoria não informada.");
        }

        category.Id = id; // Garante que o ID da URL será atribuído ao objeto categoria
        _context.Entry(category).State = EntityState.Modified; // Marca a entidade como modificada

        try
        {
          await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        }
        catch (DbUpdateConcurrencyException ex)
        {
          if (!CategoryExists(id)) // Verifica se a categoria existe
          {
            return StatusCode(500, new { message = "Categoria não encontrada.", error = ex.Message });
          }
          else
          {
            throw; // Lança exceções que não foram tratadas
          }
        }

        // Retorna a categoria atualizada com uma mensagem de sucesso
        return Ok(new {message = "Categoria atualizada com sucesso!", category}); 
    }

    // DELETE: api/categoria/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id) 
    {
      try
      {
        // Busca a categoria pelo ID
        var category = await _context.Categories.FindAsync(id);

        if (category == null) // Verifica se a categoria existe
        {
            return NotFound("Categoria não encontrada.");
        }

        // Remove a categoria do contexto do banco de dados
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(); // Persiste a remoção no banco de dados

        // Retorna a categoria removida com uma mensagem de sucesso
        return Ok(new {message = "Categoria removida com sucesso!", category}); 
      }
      catch (Exception ex)
      {
        // Trata erros inesperados e retorna código de status 500
        return StatusCode(500, new { message = "Erro ao remover a categoria.", error = ex.Message });
      }
    }

    // Método auxiliar para verificar se uma categoria existe no banco de dados
    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id); 
    }
  }
}
