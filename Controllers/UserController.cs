using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models; 
using WebAPI.Context; 

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Construtor que injeta o contexto do banco de dados
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL: api/user
        [HttpGet]
        // Rota para buscar todos os usuários 
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                // Busca todos os usuários com seus pedidos associados
                var users = await _context.Users.Include(u => u.UserOrders).ToListAsync();

                if (!users.Any())
                {
                    // Caso nenhum usuário seja encontrado, retorna um erro 404
                    return NotFound("Nenhum usuário encontrado.");
                }

                // Mapeia os usuários para usar o UserDTO e não retornar a senha
                var userDTOs = users.Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                }).ToList();

                // Retorna os usuários encontrados com uma mensagem de sucesso
                return Ok(new {message= "Usuários encontrados com sucesso!", users = userDTOs}); 
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro no processo, retorna um erro 500 com a mensagem detalhada
                return StatusCode(500, new
                {
                    message = "Ocorreu um erro ao processar a requisição.",
                    error = ex.Message
                });  
            }
        }

        // GET DETAILS BY ID: api/user/1
        [HttpGet("{id}")]
        // Rota para buscar um usuário pelo id
        public async Task<ActionResult<User>> GetUser(int id) 
        {
            try
            {
                // Busca o usuário específico pelo id e inclui os pedidos
                var user = await _context.Users
                    .Include(u => u.UserOrders)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    // Caso o usuário não seja encontrado, retorna erro 404
                    return NotFound("Usuário não encontrado.");
                }

                // Mapeia o usuário para o UserDTO para não retornar a senha
                var userDTO = MapToDTO(user);

                // Retorna o usuário encontrado com uma mensagem de sucesso
                return Ok(new {message= "Usuário encontrado com sucesso!", user = userDTO}); 
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro no processo, retorna erro 500 com a mensagem detalhada
                return StatusCode(500, new
                {
                    message = "Ocorreu um erro ao processar a requisição.",
                    error = ex.Message
                });  
            }
        }

        // POST: api/user
        [HttpPost]
        // Rota para criar um novo usuário
        public async Task<ActionResult<User>> PostUser(User user) 
        {
            try
            {
                if (user == null)
                {
                    // Caso o usuário não seja informado, retorna erro 400 (Bad Request)
                    return BadRequest("Usuário não informado.");
                }

                _context.Users.Add(user); // Adiciona o usuário ao contexto do banco
                await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados

                // Mapeia o usuário para o UserDTO para não retornar a senha
                var userDTO = MapToDTO(user);

                // Retorna o usuário criado com a localização do recurso (CreatedAtAction)
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new {message= "Usuário criado com sucesso!", user = userDTO}); 
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro no processo, retorna erro 500 com a mensagem detalhada
                return StatusCode(500, new 
                {
                    message = "Ocorreu um erro ao processar a requisição.",
                    error = ex.Message
                });
            }
        }

        // PUT: api/user/1
        [HttpPut("{id}")]
        // Rota para atualizar os dados de um usuário
        public async Task<IActionResult> PutUser(int id, [FromBody] User user) 
        {
            if (user == null)
            {
                // Caso o usuário não seja informado, retorna erro 400 (Bad Request)
                return BadRequest("Usuário não informado.");
            }

            user.Id = id; // Atribui o id da URL ao objeto usuário
            _context.Entry(user).State = EntityState.Modified; // Marca o usuário para atualização

            try
            {
                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    // Caso ocorra um erro de concorrência ou o usuário não exista
                    return StatusCode(500, new { message = "Usuário não encontrado.", error = ex.Message });
                }
                else
                {
                    throw;
                }
            }

            // Mapeia o usuário para o UserDTO para não retornar a senha
            var userDTO = MapToDTO(user);

            // Retorna o usuário atualizado com uma mensagem de sucesso
            return Ok(new {message= "Usuário atualizado com sucesso!", user = userDTO}); 
        }

        // DELETE: api/user/1
        [HttpDelete("{id}")]
        // Rota para remover um usuário
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                // Busca o usuário pelo id
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    // Caso o usuário não seja encontrado, retorna erro 404
                    return NotFound("Usuário não encontrado.");
                }

                _context.Users.Remove(user); // Remove o usuário do contexto
                await _context.SaveChangesAsync(); // Salva a remoção no banco de dados

                // Mapeia o usuário para o UserDTO para não retornar a senha
                var userDTO = MapToDTO(user);

                // Retorna o usuário removido com uma mensagem de sucesso
                return Ok(new {message= "Usuário removido com sucesso!", user = userDTO}); 
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro no processo, retorna erro 500 com a mensagem detalhada
                return StatusCode(500, new { message = "Erro ao remover o usuário.", error = ex.Message });
            }
        }

        // Método para mapear o usuário para o UserDTO e não retornar a senha
        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserOrders = user.UserOrders
            };
        }

        // Método para verificar se o usuário existe no banco de dados
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id); 
        }
    }
}
