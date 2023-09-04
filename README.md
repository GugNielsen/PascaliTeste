# PascaliTeste

Configuração do Banco de Dados
Primeiro, navegue até a pasta 'webApi' e abra o arquivo 'appsettings.json'. Em seguida, altere a string de conexão do banco de dados na seção "ConnectionStrings":

"ConnectionStrings": {
  "ApiConnection": "Server=DESKTOP-6R0VU8E\\SQLEXPRESS;Database=master;Trusted_Connection=True;"
}
Esta é a conexão do meu banco de dados local.

Depois, em um banco de dados SQL Server de sua preferência, execute os seguintes scripts para criar as tabelas 'Projects' e 'Users':

sql
CREATE TABLE Projects (
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  ResponsibilityUserId UNIQUEIDENTIFIER,
  CreateUserId UNIQUEIDENTIFIER NOT NULL,
  Title VARCHAR(255) NOT NULL,
  Description TEXT,
  StartProjectDate DATETIME NOT NULL,
  EndProjectDate DATETIME,
  Status INT NOT NULL
);

CREATE TABLE Users (
  UserId UNIQUEIDENTIFIER PRIMARY KEY,
  FirstName VARCHAR(255) NOT NULL,
  LastName VARCHAR(255) NOT NULL,
  Email VARCHAR(255) NOT NULL,
  Password VARCHAR(255) NOT NULL,
  Birthday DATETIME NOT NULL
);
Execução do Visual Studio
Após a configuração do banco de dados, você pode executar o Visual Studio. Eu habilitei o Swagger para facilitar o deploy.

Criação de Usuário na API
Utilize o seguinte JSON como exemplo para criar seu usuário através da API 'User Create':
POST https://localhost:7127/api/User/Create
json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string",
  "birthday": "2023-09-03T14:47:15.578Z"
}
Depois, faça o login 
POST https://localhost:7127/api/Auth/Login
{
  "email": "string",
  "password": "string"
}
com o usuário e a senha criados. Uma vez logado, você receberá um Token JWT, que deverá ser inserido no Swagger. Para isso, clique no botão 'Authorize' localizado na parte superior da página e insira "Bearer 'seu Token'" no campo fornecido.

Após a autorização, você estará habilitado para criar projetos, alterar o status dos projetos e navegar nas APIs.

Quando for definir a responsabilidade de um projeto, o usuário selecionado receberá um e-mail. Como se trata de um teste, não criei nenhum e-mail elaborado.

Além disso, por questões de tempo, criei testes unitários apenas para os usuários, e não para todas as funcionalidades.

as principais Apis são alem dessas duas 

POST https://localhost:7127/api/Project/Create
{
  "createUserId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "string",
  "description": "string"
}


Patch https://localhost:7127/api/Project/UpdateStatus
{
  "idProject": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "status": 0
}


Patch https://localhost:7127/api/Project/UpdateResponsibility
{
  "idProject": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "responsibilityUserId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}

GET https://localhost:7127/api/Status/GetAll

Espero que isso ajude! Se precisar de mais alguma coisa, por favor, me avise.

