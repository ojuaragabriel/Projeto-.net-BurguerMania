using System.ComponentModel.DataAnnotations; // Biblioteca para atributos de validação.
using System.ComponentModel.DataAnnotations.Schema; // Biblioteca para atributos relacionados a mapeamento de banco de dados.

namespace WebAPI.Models; // Define o namespace do projeto.

public class ProductOrder
{
    // Chave primária da entidade.
    [Key]
    public int Id { get; set; }

    // Quantidade de produtos nesse pedido.
    public int Quantity { get; set; }
    
    // Relacionamentos

    // Chave estrangeira para a entidade Product.
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    // Propriedade de navegação para acessar os detalhes do produto relacionado.
    public Product? Product { get; set; }

    // Chave estrangeira para a entidade Order.
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    
    // Propriedade de navegação para acessar os detalhes do pedido relacionado.
    public Order? Order { get; set; }
}
