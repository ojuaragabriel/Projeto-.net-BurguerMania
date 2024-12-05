using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderController : ControllerBase
  {
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context)
    {
      // Injeta o contexto do banco de dados para ser usado nos métodos do controlador
      _context = context;
    }

    // GET ALL: api/order
    [HttpGet]
    // Endpoint para buscar todas as ordens
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
      try
      {
        // Realiza uma busca no banco, incluindo os relacionamentos com Status, ProductOrders e UserOrders
        var orders = await _context.Orders
          .Include(o => o.Status)
          .Include(o => o.ProductOrders)
          .Include(o => o.UserOrders)
          .ToListAsync();

        if (!orders.Any())
        {
            // Retorna 404 se não houverem ordens cadastradas
            return NotFound("Nenhuma ordem encontrada.");
        }

        // Retorna as ordens em um objeto contendo mensagem de sucesso
        return Ok(new { message = "Ordens encontradas com sucesso!", orders });
      }
      catch (Exception ex)
      {
        // Retorna um erro 500 com detalhes caso algo inesperado ocorra
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });  
      }
    }

    // GET DETAILS BY ID: api/order/5
    [HttpGet("{id}")]
    // Endpoint para buscar uma ordem específica pelo ID
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
      try
      {
        // Busca a ordem pelo ID, incluindo os relacionamentos necessários
        var order = await _context.Orders
          .Include(o => o.Status)
          .Include(o => o.ProductOrders)
          .Include(o => o.UserOrders)
          .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            // Retorna 404 se a ordem não for encontrada
            return NotFound("Ordem não encontrada.");
        }

        // Retorna a ordem encontrada em um objeto com mensagem de sucesso
        return Ok(new { message = "Ordem encontrada com sucesso!", order });
      }
      catch (Exception ex)
      {
        // Retorna erro 500 com detalhes
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });  
      }
    }

    // POST: api/order
    [HttpPost]
    // Endpoint para criar uma nova ordem
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
      try
      {
        if (order == null)
        {
          // Retorna 400 caso o objeto ordem seja nulo
          return BadRequest("Ordem não informada.");
        }

        // Adiciona a nova ordem ao contexto e salva no banco de dados
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        // Retorna a ordem criada com o status 201 Created
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, new { message = "Ordem criada com sucesso!", order });
      }
      catch (Exception ex)
      {
        // Retorna erro 500 em caso de falha
        return StatusCode(500, new 
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });
      }
    }

    // PUT: api/order/5
    [HttpPut("{id}")]
    // Endpoint para atualizar uma ordem existente
    public async Task<IActionResult> PutOrder(int id, Order order)
    {
      if (order == null)
      {
        // Retorna 400 caso o objeto ordem seja nulo
        return BadRequest("Ordem não informada.");
      }

      // Atribui o ID recebido via URL ao objeto ordem
      order.Id = id;
      _context.Entry(order).State = EntityState.Modified;

      try
      {
        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        if (!OrderExists(id))
        {
          // Retorna erro 500 caso ocorra uma falha de concorrência
          return StatusCode(500, new { message = "Ordem não encontrada.", error = ex.Message });
        }
        else
        {
          throw;
        }              
      }

      // Retorna a ordem atualizada
      return Ok(new { message = "Ordem atualizada com sucesso!", order }); 
    }

    // DELETE: api/order/5
    [HttpDelete("{id}")]
    // Endpoint para deletar uma ordem
    public async Task<IActionResult> DeleteOrder(int id)
    {
      try
      {
        // Busca a ordem pelo ID
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
          // Retorna 404 se a ordem não existir
          return NotFound("Ordem não encontrada.");
        }

        // Remove a ordem do banco de dados
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        // Retorna mensagem de sucesso com os dados da ordem removida
        return Ok(new { message = "Ordem removida com sucesso!", order }); 
      }
      catch (Exception ex)
      {
        // Retorna erro 500 com detalhes em caso de falha
        return StatusCode(500, new { message = "Erro ao remover a ordem.", error = ex.Message });
      }
    }

    // Método auxiliar para verificar se uma ordem com o ID especificado existe no banco de dados
    private bool OrderExists(int id)
    {
      return _context.Orders.Any(e => e.Id == id);
    }
  }
}
