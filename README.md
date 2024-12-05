
# BackEnd | FullStack ResTIC36

## Descrição do Projeto

O objetivo deste projeto é desenvolver o backend de uma aplicação fullstack utilizando o framework .NET e o Entity Framework para interação com o banco de dados. Após receber o design do frontend em Figma, foi elaborado um modelo de dados para o backend. O backend foi então implementado como uma API RESTful que se conecta com o frontend, permitindo a manipulação dos dados. O uso do Entity Framework facilita a comunicação com o banco de dados PostgreSQL, garantindo uma integração fluida entre as camadas da aplicação.

## Como Executar a Aplicação

Para rodar o projeto localmente, siga os passos abaixo:

1. Clone o repositório para sua máquina local.
2. Abra o projeto em sua IDE de preferência.
3. No terminal, navegue até a pasta raiz do projeto.
4. Execute o comando para restaurar as dependências do projeto:

   ```bash
   dotnet restore
   ```

5. Realize a atualização do banco de dados com o comando:

   ```bash
   dotnet ef database update
   ```

6. Inicie a aplicação com o comando:

   ```bash
   dotnet run
   ```

7. Abra um novo terminal e execute o seguinte comando para abrir o Swagger:

   ```bash
   start http://localhost:5290/swagger
   ```

   Isso abrirá automaticamente o Swagger em seu navegador, onde você poderá testar as rotas da API.


## Tecnologias Utilizadas

- **.NET**: Framework utilizado para o desenvolvimento do backend.
- **Entity Framework**: ORM para interagir com o banco de dados PostgreSQL.
- **PostgreSQL**: Banco de dados utilizado na aplicação.
- **Swagger**: Interface para testar e visualizar a API de forma interativa.

Este projeto visa proporcionar uma experiência completa de desenvolvimento backend com integração ao frontend, garantindo que a aplicação seja funcional e esteja pronta para ser consumida de forma eficiente e organizada.
