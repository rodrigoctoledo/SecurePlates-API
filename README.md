🚘 SecurePlates API
SecurePlates-API é uma aplicação ASP.NET Core que fornece uma API robusta para gerenciamento de usuários, placas veiculares e ocorrências. A aplicação utiliza autenticação JWT para garantir a segurança dos endpoints.

🛠️ Funcionalidades
✅ Registro de usuários

🔐 Login com autenticação JWT

🔁 Recuperação de senha

🚗 CRUD completo de placas

📋 CRUD completo de ocorrências

🧰 Tecnologias Utilizadas
.NET 9

ASP.NET Core

Entity Framework Core

SQL Server

JWT (JSON Web Token) para autenticação segura

⚙️ Configuração do Projeto
✅ Pré-requisitos
.NET 9 SDK

SQL Server

🚀 Instalação
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/seu-usuario/SecurePlates-API.git
cd plateguardian-api
Configure a string de conexão:

No arquivo appsettings.json, atualize a seção ConnectionStrings com os dados do seu SQL Server:

json
Copiar
Editar
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=PlateGuardianDb;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
Execute as migrações do Entity Framework:

bash
Copiar
Editar
dotnet ef database update
Execute a aplicação:

bash
Copiar
Editar
dotnet run
A API estará disponível em https://localhost:5001 ou http://localhost:5000.

📌 Endpoints
🔐 Autenticação
Método	Endpoint	Descrição
POST	/api/auth/register	Registro de novo usuário
POST	/api/auth/login	Login de usuário
POST	/api/auth/recover	Recuperação de senha
🚗 Placas
Método	Endpoint	Descrição
GET	/api/plates	Lista todas as placas
GET	/api/plates/{id}	Obtém placa por ID
POST	/api/plates	Cria nova placa
PUT	/api/plates/{id}	Atualiza uma placa existente
DELETE	/api/plates/{id}	Remove uma placa
📋 Ocorrências
Método	Endpoint	Descrição
GET	/api/ocorrencias	Lista todas as ocorrências
GET	/api/ocorrencias/{id}	Obtém ocorrência por ID
POST	/api/ocorrencias	Cria nova ocorrência
PUT	/api/ocorrencias/{id}	Atualiza uma ocorrência existente
DELETE	/api/ocorrencias/{id}	Remove uma ocorrência
Todos os endpoints (exceto autenticação) requerem token JWT válido no header Authorization.

🤝 Contribuição
Contribuições são muito bem-vindas!
Sinta-se à vontade para abrir uma issue ou enviar um pull request com melhorias, correções ou novas funcionalidades.

📄 Licença
Este projeto está licenciado sob a Licença MIT.
Confira o arquivo LICENSE para mais detalhes.

