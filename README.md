# PascaliTeste

Configura��o do Banco de Dados
Primeiro, navegue at� a pasta 'webApi' e abra o arquivo 'appsettings.json'. Em seguida, altere a string de conex�o do banco de dados na se��o "ConnectionStrings":

"ConnectionStrings": {
  "ApiConnection": "Server=DESKTOP-6R0VU8E\\SQLEXPRESS;Database=master;Trusted_Connection=True;"
}
Esta � a conex�o do meu banco de dados local.

Depois, em um banco de dados SQL Server de sua prefer�ncia, execute os seguintes scripts para criar as tabelas 'Projects' e 'Users':

sql
Copy code
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
Execu��o do Visual Studio
Ap�s a configura��o do banco de dados, voc� pode executar o Visual Studio. Eu habilitei o Swagger para facilitar o deploy.

Cria��o de Usu�rio na API
Utilize o seguinte JSON como exemplo para criar seu usu�rio atrav�s da API 'User Create':

json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string",
  "birthday": "2023-09-03T14:47:15.578Z"
}
Depois, fa�a o login com o usu�rio e a senha criados. Uma vez logado, voc� receber� um Token JWT, que dever� ser inserido no Swagger. Para isso, clique no bot�o 'Authorize' localizado na parte superior da p�gina e insira "Bearer 'seu Token'" no campo fornecido.

Ap�s a autoriza��o, voc� estar� habilitado para criar projetos, alterar o status dos projetos e navegar nas APIs.

Quando for definir a responsabilidade de um projeto, o usu�rio selecionado receber� um e-mail. Como se trata de um teste, n�o criei nenhum e-mail elaborado.

Al�m disso, por quest�es de tempo, criei testes unit�rios apenas para os usu�rios, e n�o para todas as funcionalidades.

Espero que isso ajude! Se precisar de mais alguma coisa, por favor, me avise.

