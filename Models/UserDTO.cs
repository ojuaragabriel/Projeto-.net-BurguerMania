namespace WebAPI.Models;

// DTO (Data Transfer Object) para retornar os dados do usuário
// sem incluir informações sensíveis, como a senha.
public class UserDTO 
{
    // Propriedade para o identificador único do usuário.
    public int Id { get; set; }

    // Propriedade para o nome do usuário.
    // Pode ser nula, caso o nome não esteja disponível.
    public string? Name { get; set; }

    // Propriedade para o e-mail do usuário.
    // Também pode ser nula.
    public string? Email { get; set; }

    // Propriedade para a coleção de pedidos associados ao usuário.
    // Define um relacionamento com a classe `UserOrder`.
    public ICollection<UserOrder>? UserOrders { get; set; }
}
