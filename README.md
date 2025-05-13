Este repositório apresenta uma implementação prática da Arquitetura Hexagonal (também conhecida como Ports and Adapters) utilizando C# e .NET. O objetivo é demonstrar como organizar um sistema de forma modular, desacoplada e testável, separando claramente as responsabilidades de cada componente.

🚀 Tecnologias Utilizadas
C#: Linguagem de programação principal.

.NET: Framework para desenvolvimento da aplicação.

Docker: Contêinerização da aplicação para facilitar o desenvolvimento e implantação.

Docker Compose: Orquestração de múltiplos contêineres para ambientes de desenvolvimento consistentes.

🧱 Estrutura do Projeto
A arquitetura do projeto segue o padrão hexagonal, com a seguinte organização:

Core: Contém a lógica de negócio central da aplicação.

Ports: Define as interfaces que conectam o núcleo da aplicação ao mundo externo.

Adapters: Implementações concretas das interfaces definidas nas portas, conectando-se a bancos de dados, APIs ou outras fontes externas.

Tests: Conjunto de testes automatizados para garantir o funcionamento correto da aplicação.

🛠️ Como Executar
Clone este repositório:

Para clonar o projeto:
git clone https://github.com/flavioneto-prog/Arquitetura-Hexagonal.git
cd Arquitetura-Hexagonal

Construa e execute os contêineres Docker:
docker-compose up --build

A aplicação estará disponível em http://localhost:5000.

✅ Testes
Os testes automatizados estão localizados na pasta tests/Users.Api.Tests. Para executá-los, utilize o seguinte comando:
dotnet test
