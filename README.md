## Requisitos

1. Solução desenvolvida utilizando .NET 6.0 e Entity Framework Core. Sendo assim se faz necessário o download do ".NET SDK", conforme o ambiente em que a solução estiver operando. O download pode ser realizado através do link: https://dotnet.microsoft.com/en-us/download

2. Para armazenar os dados, utiliza-se o Banco de Dados SQL Server.
Caso o usuário deseje acessar os dados diretamente, pode-se fazer um download de algum SGBD como o "SQL Server Management Studio". 
Link para o download da ferramenta: https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms

3. Caso deseje publicar o projeto, certifique-se de instalar o ASP.NET Core Runtime 6.0. Para Windows é necessário o download e instalação do 'Hosting Bundle' e 'x64/x86 Runtime' presentes no link: https://dotnet.microsoft.com/en-us/download/dotnet/6.0 

## Anotações importantes sobre o dotnet ef

O projeto está sendo criado com .NET 6.0, por esse motivo deixarei aqui registrado algumas anotações para executar corretamente os comandos do dotnet ef no Console do Gerenciador de pacotes

1. É importante que a pasta atual onde o console inicializa seja a pasta da Solução do projeto. para isso rode o comando:
`dir`
E você verá a estrutura de pastas atual da instancia do seu console. Caso ainda nao esteja na pasta da Solução do projeto, use o comando:
`cd C:\Pasta\PastaSolucao\`
Para redirecionar o console para o local correto.

2. Para realizar os comandos do dotnet ef tools, você precisará utilizar de algumas "options" para referenciar o projeto de Data e o projeto Startup. Exemplo:

```
dotnet ef database update --project CRM.Data -c CRMDbContext --startup-project CRM
```

3. Toda vez que o repositório no github recebe um commit na branc develop ou main, o Azure Repo tambem é atualizado: https://dev.azure.com/desenvolvimento0610/_git/CRM_ANGULAR 

## Publicar o Projeto

A seguir um passo a passo para publicação da solução utilizando o Visual Studio 2022 no idioma pt-br.

1. Crie um novo site no IIS. Certifique-se de conceder as permissões necessárias ao pool e ao usuário do Windows para não obter erros de permissão de acesso.
2. Para criar um perfil de publicação o usuário pode clicar com o botão direito no projeto 'VariacaoDoAtivo' e escolher a opção 'Publicar'. Irá abrir uma janela com as opções de publicação. Escolha o Destino como 'Pasta' e clique em próximo. Por padrão, o visual studio preenche o 'Local da pasta', então já podemos clicar em Concluir.
3. Após concluir irá aparecer a janela de progresso e logo irá mostrar um aviso de Perfil de publicação criado. Clique em fechar. A janela que estará aberta no fundo é o perfil de publicação que criamos. Agora basta clicar no botão 'Publicar '
4. Clique na opção 'Mostrar todas as configurações'. Aguarde enquanto o Visual Studio carrega o Contexto de Dados. Serão mostradas as opções 'Banco de Dados' e 'Migrações do Entity Framework'. Expanda ambas as opções e marque suas caixas de seleção que representa o valor da ConnectionString do SQL Server. Clique em Salvar. **OBS:** caso seja apresentado algum erro de dotnet tool, certifique-se de que o dotnet tool está instalado executando o seguinte comando no Console de Gerenciador de pacotes: 'dotnet tool install --global dotnet-ef'
5. Agora o perfil está preparado para publicação. O usuári pode clicar no botão 'Publicar' que está na janela atual. 
6. Após publicar, o usuário deverá copiar o conteúdo que se encontra dentro do diretório que foi definido no etapa 2 deste passo-a-passo e colar no diretório onde foi criado o Site do IIS (na etapa 1).
7. Para acesso às rotas configuradas no projeto, o usuário deve acessar o endereço que foi configurado no IIS + o sufixo '/swagger/index.html'. Exemplo de acesso: http://localhost:7530/swagger/index.html


## Novos Services

Passo a passo para criar um novo serviço para uma nova entidade (Nova tabela no banco de dados).
Neste exemplo a palavra 'Entidade' deverá ser substituido pelo nome da tabela no seu banco de dados.

1 - Projeto Application:
    - Criar ViewModel herdando de : EntityIdViewModel (Atente-se para as Datta Annottations como [Required])
    - Criar IEntidadeSerice herdando de : IBaseService<Entidade,EntidadeViewModel>
    - Criar EntidadeService herdando de : iEntidadeService e implemente a interface. Tambem ja inclua o repositorio no inicio da classe com private readonly IEntidadeRepository entidadeRepository;
2 - Projeto Domain
    - Crie IEntidadeRepository herdando de : IRepository<Entidade>
3 - Projeo Data
    - Crie EntidadeRepository herdando de  : Repository<Entidade>, IEntidadeRepository
4 - De volta ao projeto Application
    - private readonly IMapper mapper; se precisar
    - ctor tab para criar o construtor e insira as dependencias para injeção. Exemplo
    - Crie a configuração para o Automapper em AutoMapperSetup.cs
5 - Projeto IoC
    - Cria a injeção de dependencia para o repositório e o servico criados. Ex: services.AddScoped<IEntidadeService, EntidadeService>(); services.AddScoped<IEntidadeRepository, EntidadeRepository>();

Modelo de envio de requisição
{
  "nome": "Pedro",
  "tipo": 2,
  "email": "user@example.com",
  "telefone": "3599999999",
  "documentoTipo": 3,
  "documento": "35.999.633/0001-30"
}

## Testes

Ao cadastrar uma nova pessoa, o sistema ja roda a regra de negocio para consultar o endereço e cadastrar no BD se ja nao existir. Exemplo de consulta:

SELECT A.NOME Pessoa, A.Documento CNPJ, A.Email, C.Nome Pais, DE.Nome Regiao, D.Nome Estado, E.Nome Cidade, B.Logradouro, B.Numero
from Pessoas A 
JOIN PessoaEnderecos B ON B.PessoaId = A.Id
JOIN Paises C ON C.Id = B.PaisId
JOIN Estados D ON D.Id = B.EstadoId
JOIN Regioes DE ON DE.Id = D.RegiaoId
JOIN Municipios E ON E.Id = B.MunicipioId