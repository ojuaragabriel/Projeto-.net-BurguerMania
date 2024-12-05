using System.ComponentModel.DataAnnotations; // Importa atributos de validação de dados.
using System.Text.Json.Serialization; // Importa funcionalidades para manipular serialização JSON.

namespace WebAPI.Models; // Define o namespace da aplicação.
public class Status // Define a classe "Status" que representa um status no sistema.
{
    [Key] // Indica que a propriedade "Id" é a chave primária da tabela no banco de dados.
    public int Id { get; set; } // Propriedade para armazenar o identificador único do status.

    public required string Name { get; set; } // Propriedade obrigatória para armazenar o nome do status.

    // Relacionamento
    [JsonIgnore] // Indica que esta propriedade não será incluída na serialização JSON.
    public ICollection<Order>? Orders { get; set; } // Representa a relação com a entidade "Order", podendo ser nula.
}
