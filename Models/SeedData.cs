using WebAPI.Models;

namespace WebAPI.Data;

// Dados iniciais para preenchimento das tabelas de status, usuários, categorias e produtos no banco de dados.
public static class SeedData
{
  public static List<Status> Status = new List<Status>
  {
    new Status
    {
      Id = 1,
      Name = "Pendente"
    },
    new Status
    {
      Id = 2,
      Name = "Em Processamento"
    },
    new Status
    {
      Id = 3,
      Name = "Finalizado"
    }
  };

    public static List<User> Users = new List<User>
  {
    new User
    {
      Id = 1,
      Name = "Testando testanto",
      Email = "Tesste@testemail.com",
      Password = "HelloWorld1" 
    },
    new User
    {
      Id = 2,
      Name = "anonimo nonimo",
      Email = "flamengo@flamail.com",
      Password = "Helloworld2" 
    }
  };

  public static List<Category> Categories = new List<Category>
  {
    new Category
    {
      Id = 1,
      Name = "X-Vegan",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 2,
      Name = "X-Fitness",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Uma refeição leve e deliciosa, ideal para quem busca vitalidade e bem-estar. Preparado com hambúrguer grelhado de peito de frango, temperado com ervas finas e cúrcuma, servido em pão integral artesanal. Acompanhado de folhas frescas de rúcula, espinafre e brotos de alfafa, além de rodelas crocantes de pepino, fatias de cenoura e uma pasta de iogurte grego com hortelã. Finalizado com azeite extravirgem e sementes de chia, proporcionando uma refeição balanceada, repleta de sabores e ingredientes naturais.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 3,
      Name = "X-Infarto",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um sanduíche delicioso e cheio de sabor para quem aprecia uma refeição marcante. Feito com um hambúrguer de 200g de carne bovina Angus, envolto em uma camada crocante de bacon e coberto por uma generosa porção de queijo cheddar derretido. Servido em um pão brioche macio, o sanduíche é recheado com cebolas crocantes, fatias de tomate, alface americana, molho especial de maionese com alho e um toque de ketchup e mostarda. Para dar o toque final, uma camada de pulled pork desfiado e uma pitada de páprica picante, proporcionando uma explosão de sabores a cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 4,
      Name = "X-Gourmet",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Uma verdadeira obra-prima culinária, desenvolvida para os amantes da boa comida. O hambúrguer, feito com carne Angus macia, é acompanhado por queijo brie derretido e cogumelos trufados, intensificando a sofisticação do prato. Servido em um pão brioche artesanal, é complementado por rúcula fresca e uma maionese artesanal com leve toque cítrico. Cada mordida oferece uma experiência única, equilibrando ingredientes de alta qualidade e texturas incríveis, tornando o X-Gourmet uma opção memorável.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true"
    },
    new Category
    {
      Id = 5,
      Name = "X-Clássicos",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Uma verdadeira homenagem aos clássicos da culinária. O Cheeseburger Tradicional, com hambúrguer grelhado na medida exata, vem acompanhado de queijo cheddar derretido, alface crocante e tomate fresco, tudo em um pão macio. Para quem adora bacon, o X-Bacon traz a crocância perfeita junto ao molho barbecue. O X-Egg, por sua vez, se destaca com o sabor único do ovo frito e gema cremosa. Simples e saborosos, esses hambúrgueres proporcionam prazer e satisfação em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true"
    }
  };

  public static List<Product> Products = new List<Product>
  {
    new Product
    {
      Id = 1,
      Name = "X-Alface-Premium",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 28.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 2,
      Name = "X-Tomate",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 38.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 3,
      Name = "X-Frutas",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 4,
      Name = "X-Salada",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 1
    },
    new Product
    {
      Id = 5,
      Name = "X-Fitness-Grelhado",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 28.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 6,
      Name = "X-Proteína",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 38.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 7,
      Name = "X-Low-Carb",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 8,
      Name = "X-Light",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 2
    },
    new Product
    {
      Id = 9,
      Name = "X-Mega-Bacon",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 28.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 10,
      Name = "X-Parada-Cardíaca",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 38.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 11,
      Name = "X-Queijo-Extra",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 12,
      Name = "X-Triplo",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 3
    },
    new Product
    {
      Id = 13,
      Name = "X-Trufado-Supreme",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 58.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 14,
      Name = "X-Blue-Cheese-Delight",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 68.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 15,
      Name = "X-Mediterrâneo",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 78.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 16,
      Name = "X-Deluxe",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 4
    },
    new Product
    {
      Id = 17,
      Name = "X-Cheeseburger-Tradicional",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 28.99,
      CategoryId = 5
    },
    new Product
    {
      Id = 18,
      Name = "X-Bacon",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 38.99,
      CategoryId = 5
    },
    new Product
    {
      Id = 19,
      Name = "X-Egg",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 5
    },
    new Product
    {
      Id = 20,
      Name = "X-Tudo",
      BaseDescription = "Pão, hambúrguer, alface, tomate, queijo e maionese.",
      FullDescription = "Um hambúrguer vegano recheado de sabor, feito com grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, criando uma textura irresistível e cheia de sabor. Servido em um pão macio, é acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma camada generosa de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino recém-moída, oferecendo uma explosão de sabores e texturas em cada mordida.",
      PathImage = "https://github.com/ojuaragabriel/Projeto-Angular-JS-BurguerMania/blob/main/src/app/assets/images/image4.png?raw=true",
      Price = 48.99,
      CategoryId = 5
    }
  };
}
