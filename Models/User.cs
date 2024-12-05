using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

// Classe que representa o modelo de usuário no sistema
public class User
{
    [Key] // Indica que a propriedade é a chave primária do modelo
    public int Id { get; set; }

    // Nome do usuário (campo obrigatório)
    public required string Name { get; set; }

    // Email do usuário (campo obrigatório)
    public required string Email { get; set; }

    // Senha do usuário (campo obrigatório)
    public required string Password { get; set; }

    // Relacionamento com a tabela UserOrder
    // Um usuário pode ter múltiplos pedidos associados
    public ICollection<UserOrder>? UserOrders { get; set; }
}
