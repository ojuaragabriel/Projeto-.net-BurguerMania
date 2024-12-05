using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;

// Representa um pedido no sistema
public class Order
{
    // Chave primária do pedido
    [Key]
    public int Id { get; set; }

    // Valor total do pedido
    public float Value { get; set; }

    // Observações adicionais sobre o pedido (opcional)
    public string? Observation { get; set; }

    // Relacionamentos

    // Chave estrangeira que referencia o Status do pedido
    [ForeignKey("Status")]
    public required int StatusId { get; set; }

    // Navegação para o Status do pedido
    public Status? Status { get; set; }

    // Relacionamento com a tabela intermediária ProductOrder, ignorado na serialização JSON
    [JsonIgnore]
    public ICollection<ProductOrder>? ProductOrders { get; set; }

    // Relacionamento com a tabela intermediária UserOrder, ignorado na serialização JSON
    [JsonIgnore]
    public ICollection<UserOrder>? UserOrders { get; set; }
}
