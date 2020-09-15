# AVALIAÇÃO TÉCNICA DESENVOLVEDOR C#

### Projeto TestDgBar - API

### Decisões técnicas
  - A API foi implementada com o **.net core 3.1**;
  - API implementada com arquitetura REST em camadas baseada nos principios do DDD;
  - Foi utilizado a biblioteca **Autofac 5.2.0** para realizar a injeção de dependência dos serviços da aplicação;
  - Foi utilizado a politica "Wait and Retry" com a biblioteca **Polly 7.2.1** para aplicar a resiliência na API;
  - Foi utilizada o swagger ui **Swashbuckle.AspNetCore 5.5.1** para documentação da API;
  - Foi utilizado o banco local **localdb** do SQL Server para persistir os dados (é necessário rodar os script no banco); 
  - Os teste unitários foram implementados com as bibliotecas **xUnit 2.4.0**, **FluentAssertions 5.10.3** e **Moq 4.14.5**;
  - Pagina web em Vue.js https://github.com/guisaulo/TestDgBar-front;

### Arquitetura utilizada
Foi criada uma arquitetura com quatro camadas utilizando o conceito de DDD:
  - 1 - **Presentation (Apresentação)**: Camada de entrada da aplicação. Possui a implementação das controllers para efetuar as chamadas na API;
  - 2 - **Application (Aplicação)**: Camada que coordena a execução das tarefas vindo das controllers para os objetos de dominio. Armazena os DTOs e Mappers da solução para transferência de dados entre a camada de dominio e de apresentação;
  - 3 - **Domain (Domínio)**: Camada independente, com as entidades, contratos (interfaces de repositório e serviços) e serviços de domínio da aplicação (regras de negócio);
  - 4 - **Infrastructure** (Infraestrutura): Camada dividida em duas sub-camadas.:
  - **Data:** Possui a implementação dos repositórios que fazem a persistência dos dados com o banco de dados via Entity Framework;
  - **Cross-Cutting:** Camada que cruza toda hierarquia com as funcionalidades comuns a qualquer parte do código. Possui o papel de implementar a injeção de dependências. Possui as configurações de IOC em container (via AutoFac) e o modulo IOC que é registrado no Startup do projeto.

### Pontos de melhorias e evolução
  - Criar uma estratégia de autenticação entre a Api e a Interface (Pendente, por causa do tempo):
    **Proposta**: Para garantir o acesso seguro na API REST, poderia utilizar o padrão JWT (JSON Web Token) para realizar autenticação entre o front e a API por meio de um token assinado que seria autenticado na requisição. Por exemplo, um serviço pode gerar um token com a declaração "usuario com acesso" e fornecê-lo ao cliente. O cliente pode então usar esse token para provar que tem acesso à aplicação. 

  - Foi utilizado a abordagem de resiliência Wait e Retry. Mas em outros cenários é possível utilizar outras políticas de tratamento e recuperação de falhas na aplicação com Polly, como:
  - a) Circuit-Break: Se algo de errado ocorre na requisição, é retornado uma mensagem de alerta para evitar novas operações;
  - b) Time-out: Caso a requisição demore pra responder dentro de um periodo de tempo especificado, uma exceção é lançada e os recursos liberados;
  - c) Fallback: Caso ocorra um erro na requisição, a API retorna algo customizado;

  - A tabelas do banco poderiam ser criadas automaticamente com a abordagem Code-First do Migrations do Entity Framework. Uma forma de controlar as alterações do banco juntamente com o versionamento da aplicação (Não foi realizada por falta de tempo).
  
### End-Points
A API possui os seguintes end-points:
  - **GET /Comanda/GetAll**: Retorna todas as comandas cadastradas
  - **GET /Item/GetAll**: Retorna todos os items cadastrados
  - **POST /ComandaItem/InserirItemComanda/{"comandaId", "itemId"}**: Registra um item em uma comanda
  - **POST /ComandaItem/InserirItemComanda/{"comandaId", "itemId"}**: Registra um item em uma comanda
  - **POST /ComandaItem/ResetarComanda/comandaId**: Reseta uma comanda
  - **POST /ComandaItem/GerarNotaFiscalComanda/comandaId**: Gera uma nota fiscal de uma comanda

### Script tabelas:

 É necessário criar o banco "TestDgBar" no servidor **(localdb)\\mssqllocaldb** do SqlServer e rodar os scripts da pasta https://github.com/guisaulo/TestDgBar/tree/master/scripts%20SQL na seguinte ordem:
  - 1.CREATE_DATABASE.sql
  - 2.CREATE_COMANDA.sql
  - 3.CREATE_ITEM.sql
  - 4.CREATE_COMANDAITEM.sql
