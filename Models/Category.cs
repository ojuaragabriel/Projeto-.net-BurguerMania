using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

// Representa uma categoria no sistema, que pode conter produtos relacionados.
public class Category
{
    // Chave primária da tabela Category
    [Key]
    public int Id { get; set; }

    // Nome da categoria (campo obrigatório)
    public required string Name { get; set; }

    // Descrição básica da categoria (campo obrigatório)
    public required string BaseDescription { get; set; }

    // Descrição completa da categoria, com mais detalhes (campo obrigatório)
    public required string FullDescription { get; set; }

    // Caminho da imagem associada à categoria (campo obrigatório)
    public required string PathImage { get; set; }

    // Relacionamento com a entidade Product
    // Representa uma coleção de produtos que pertencem à categoria
    public ICollection<Product>? Products { get; set; } = new List<Product>();
}
