using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  // Define o controlador como uma API com a rota base "api/status"
  [Route("api/[controller]")]
  [ApiController]
  public class StatusController : ControllerBase
  {
    private readonly AppDbContext _context;

    // Construtor do controlador, recebe o contexto do banco de dados via injeção de dependência
    public StatusController(AppDbContext context)
    {
      _context = context;
    }

    // GET ALL: api/status
    [HttpGet]
    // Rota para buscar todos os status
    public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
    {
      try
      {
        // Busca todos os status no banco de dados
        var status = await _context.Status.ToListAsync();

        // Caso nenhum status seja encontrado, retorna 404
        if (!status.Any())
        {
          return NotFound("Nenhum status encontrado.");
        }

        // Retorna os status encontrados com mensagem de sucesso
        return Ok(new { message = "Status encontrados com sucesso!", status });
      }
      catch (Exception ex)
      {
        // Captura erros inesperados e retorna status 500 com detalhes
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });
      }
    }

    // GET DETAILS BY ID: api/status/5
    [HttpGet("{id}")]
    // Rota para buscar um status pelo id
    public async Task<ActionResult<Status>> GetStatus(int id)
    {
      try
      {
        // Busca o status correspondente ao id
        var status = await _context.Status.FindAsync(id);

        // Caso o status não seja encontrado, retorna 404
        if (status == null)
        {
          return NotFound("Status não encontrado.");
        }

        // Retorna o status encontrado com mensagem de sucesso
        return Ok(new { message = "Status encontrado com sucesso!", status });
      }
      catch (Exception ex)
      {
        // Captura erros inesperados e retorna status 500 com detalhes
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });
      }
    }

    // POST: api/status
    [HttpPost]
    // Rota para criar um novo status
    public async Task<ActionResult<Status>> PostStatus(Status status)
    {
      try
      {
        // Verifica se o objeto status é nulo
        if (status == null)
        {
          return BadRequest("Status não informado.");
        }

        // Adiciona o status ao contexto
        _context.Status.Add(status);

        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();

        // Retorna o status criado com a rota para obter os detalhes
        return CreatedAtAction(nameof(GetStatus), new { id = status.Id }, new { message = "Status criado com sucesso!", status });
      }
      catch (Exception ex)
      {
        // Captura erros inesperados e retorna status 500 com detalhes
        return StatusCode(500, new
        {
          message = "Ocorreu um erro ao processar a requisição.",
          error = ex.Message
        });
      }
    }

    // PUT: api/status/5
    [HttpPut("{id}")]
    // Rota para atualizar um status existente
    public async Task<IActionResult> PutStatus(int id, Status status)
    {
      // Verifica se o objeto status é nulo
      if (status == null)
      {
        return BadRequest("Status não informado.");
      }

      // Atribui o ID da URL ao objeto status
      status.Id = id;

      // Marca o objeto como modificado no contexto
      _context.Entry(status).State = EntityState.Modified;

      try
      {
        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        // Verifica se o status existe antes de lançar uma exceção
        if (!StatusExists(id))
        {
          return StatusCode(500, new { message = "Status não encontrado.", error = ex.Message });
        }
        else
        {
          throw;
        }
      }

      // Retorna o status atualizado com mensagem de sucesso
      return Ok(new { message = "Status atualizado com sucesso!", status });
    }

    // DELETE: api/status/5
    [HttpDelete("{id}")]
    // Rota para remover um status
    public async Task<IActionResult> DeleteStatus(int id)
    {
      try
      {
        // Busca o status pelo ID
        var status = await _context.Status.FindAsync(id);

        // Caso o status não seja encontrado, retorna 404
        if (status == null)
        {
          return NotFound("Status não encontrado.");
        }

        // Remove o status do contexto
        _context.Status.Remove(status);

        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();

        // Retorna mensagem de sucesso
        return Ok(new { message = "Status removido com sucesso!", status });
      }
      catch (Exception ex)
      {
        // Captura erros inesperados e retorna status 500 com detalhes
        return StatusCode(500, new { message = "Erro ao remover o status.", error = ex.Message });
      }
    }

    // Método para verificar se um status existe no banco de dados
    private bool StatusExists(int id)
    {
      return _context.Status.Any(e => e.Id == id);
    }
  }
}
