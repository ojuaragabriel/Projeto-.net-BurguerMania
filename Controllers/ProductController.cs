using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  // Define a rota base para o controlador como "api/[controller]"
  // O controlador é responsável por gerenciar as operações relacionadas a produtos
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly AppDbContext _context;

    // Construtor que injeta o contexto do banco de dados
    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    // Método GET para buscar todos os produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      try
      {
        // Busca todos os produtos e inclui os dados relacionados da categoria
        var products = await _context.Products.Include(p => p.Category).ToListAsync(); 

        // Verifica se não há produtos retornados
        if (!products.Any())
        {
            return NotFound("Nenhum produto encontrado.");
        }

        // Retorna os produtos encontrados com mensagem de sucesso
        return Ok(new { message = "Produtos encontrados com sucesso!", products }); 
      }
      catch (Exception ex)
      {
        // Retorna erro 500 em caso de exceção, com detalhes do erro
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });  
      }
    }

    // Método GET para buscar um produto por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        try
        {
          // Busca o produto pelo ID, incluindo a categoria associada
          var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
            
          // Verifica se o produto não foi encontrado
          if (product == null)
          {
              return NotFound("Produto não encontrado.");
          }

          // Retorna o produto encontrado com mensagem de sucesso
          return Ok(new { message = "Produto encontrado com sucesso!", product }); 
        }
        catch (Exception ex)
        {
          // Retorna erro 500 em caso de exceção, com detalhes do erro
          return StatusCode(500, new
          {
            message = "Ocorreu um erro ao processar a requisição.",
            error = ex.Message
          });  
        }
    }

    // Método POST para criar um novo produto
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
      try
      {
        // Verifica se o objeto produto enviado é nulo
        if (product == null)
        {
          return BadRequest("Produto não informado.");
        }

        // Adiciona o produto ao contexto e salva no banco de dados
        _context.Products.Add(product); 
        await _context.SaveChangesAsync();

        // Retorna o produto criado com mensagem de sucesso
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, 
          new { message = "Produto criado com sucesso!", product }); 
      }
      catch (Exception ex)
      {
        // Retorna erro 500 em caso de exceção, com detalhes do erro
        return StatusCode(500, new 
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });
      }
    }

    // Método PUT para atualizar um produto existente
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        // Verifica se o objeto produto enviado é nulo
        if (product == null)
        {
            return BadRequest("Produto não informado.");
        }

        // Define o ID do produto como o mesmo passado na URL
        product.Id = id; 
        _context.Entry(product).State = EntityState.Modified; // Marca o produto como modificado

        try
        {
          // Salva as alterações no banco de dados
          await _context.SaveChangesAsync(); 
        }
        catch (DbUpdateConcurrencyException ex)
        {
          // Verifica se o produto ainda existe no banco
          if (!ProductExists(id))
          {
            return StatusCode(500, new { message = "Produto não encontrado.", error = ex.Message });
          }
          else
          {
            throw;
          }
        }

        // Retorna o produto atualizado com mensagem de sucesso
        return Ok(new { message = "Produto atualizado com sucesso!", product }); 
    }

    // Método DELETE para remover um produto
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id) 
    {
      try
      {
        // Busca o produto pelo ID
        var product = await _context.Products.FindAsync(id);

        // Verifica se o produto não foi encontrado
        if (product == null)
        {
            return NotFound("Produto não encontrado.");
        }

        // Remove o produto do contexto e salva no banco de dados
        _context.Products.Remove(product); 
        await _context.SaveChangesAsync();

        // Retorna mensagem de sucesso com o produto removido
        return Ok(new { message = "Produto removido com sucesso!", product }); 
      }
      catch (Exception ex)
      {
        // Retorna erro 500 em caso de exceção, com detalhes do erro
        return StatusCode(500, new { message = "Erro ao remover o produto.", error = ex.Message });
      }
    }

    // Método auxiliar para verificar se um produto existe no banco de dados
    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
  }
}
