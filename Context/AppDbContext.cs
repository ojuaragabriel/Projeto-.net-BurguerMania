using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Context
{
    // Define o contexto do banco de dados que herda de DbContext
    public class AppDbContext : DbContext 
    {
        // Construtor do contexto que recebe as opções de configuração para o DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define as tabelas (DbSets) que correspondem às entidades no banco de dados
        public required DbSet<User> Users { get; set; }  // Tabela de usuários
        public required DbSet<Category> Categories { get; set; }  // Tabela de categorias
        public required DbSet<Product> Products { get; set; }  // Tabela de produtos
        public required DbSet<Status> Status { get; set; }  // Tabela de status
        public required DbSet<Order> Orders { get; set; }  // Tabela de pedidos
        public required DbSet<ProductOrder> ProductOrders { get; set; }  // Tabela de produtos em pedidos
        public required DbSet<UserOrder> UserOrders { get; set; }  // Tabela de usuários em pedidos

        // Método chamado para configurar o modelo de dados e popular o banco com dados iniciais (Seed Data)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama a implementação base do método OnModelCreating
            base.OnModelCreating(modelBuilder);

            // Seed Data para a tabela de Categorias
            foreach (var category in SeedData.Categories)
            {
                modelBuilder.Entity<Category>().HasData(category);  // Adiciona os dados iniciais de categorias
            }

            // Seed Data para a tabela de Produtos
            foreach (var product in SeedData.Products)
            {
                modelBuilder.Entity<Product>().HasData(product);  // Adiciona os dados iniciais de produtos
            }

            // Seed Data para a tabela de Status
            foreach (var status in SeedData.Status)
            {
                modelBuilder.Entity<Status>().HasData(status);  // Adiciona os dados iniciais de status
            }

            // Seed Data para a tabela de Usuários
            foreach (var user in SeedData.Users)
            {
                modelBuilder.Entity<User>().HasData(user);  // Adiciona os dados iniciais de usuários
            }
        }
    }
}
