using System.ComponentModel.DataAnnotations; // Necessário para anotações de validação, como [Key] e [Required].
using System.ComponentModel.DataAnnotations.Schema; // Necessário para mapeamento de banco de dados, como [ForeignKey].
using System.Text.Json.Serialization; // Necessário para controle da serialização JSON.

namespace WebAPI.Models;

// Representa o modelo de dados para um produto.
public class Product
{
    [Key] // Indica que esta propriedade é a chave primária da tabela no banco de dados.
    public int Id { get; set; }

    [Required] // Indica que esta propriedade é obrigatória.
    public required string Name { get; set; } // Nome do produto.

    [Required] 
    public required string BaseDescription { get; set; } // Descrição básica do produto.

    [Required]
    public required string FullDescription { get; set; } // Descrição detalhada do produto.

    [Required]
    public required string PathImage { get; set; } // Caminho da imagem associada ao produto.

    public double Price { get; set; } // Preço do produto.

    // Relacionamentos
    [ForeignKey("Category")] // Indica que esta propriedade é uma chave estrangeira que referencia a tabela de categorias.
    public required int CategoryId { get; set; } // ID da categoria associada ao produto.

    [JsonIgnore] // Impede que a propriedade seja serializada para JSON (evita loops de referência).
    public Category? Category { get; set; } // Objeto de navegação para a categoria do produto.

    public ICollection<ProductOrder>? ProductOrders { get; set; } // Relacionamento com pedidos de produtos (muitos-para-muitos).
}
