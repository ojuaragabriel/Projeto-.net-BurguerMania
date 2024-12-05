using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

// Classe que representa a entidade de relacionamento entre Usuários e Pedidos (UserOrder)
public class UserOrder
{
    // Chave primária da entidade
    [Key]
    public int Id { get; set; }
    
    // Relacionamentos

    // Chave estrangeira que faz referência à entidade "User"
    [ForeignKey("User")]
    public required int UserId { get; set; } // O modificador "required" garante que este campo seja obrigatório
    
    // Propriedade de navegação para o relacionamento com "User"
    [JsonIgnore] // Ignora esta propriedade durante a serialização para JSON
    public User? User { get; set; } // Propriedade opcional para evitar problemas com entidades não carregadas

    // Chave estrangeira que faz referência à entidade "Order"
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    
    // Propriedade de navegação para o relacionamento com "Order"
    [JsonIgnore] // Ignora esta propriedade durante a serialização para JSON
    public Order? Order { get; set; } // Propriedade opcional para evitar problemas com entidades não carregadas
}
