 # API - Central de Erros
<p align="center"><img src="https://i.imgur.com/BmoshZc.gif"><p>

## Aceleração em .Net Core da [Codenation](https://codenation.dev/) em Parceria com [ClearSale](https://br.clear.sale/)


<br><br>
<img src="https://i.imgur.com/1tyiTCv.png" align="left"><h3>Trabalho desenvolvido pela Squad: </h3>
<br>
  
* [Mariana Tancredi](https://github.com/matancredi)
* [Mayara Ferreira](https://github.com/mayaracsferreira)
* [Sofia Viesti](https://www.linkedin.com/in/sofia-viesti-2213591a9/)
* [Tabatha Macedo](https://github.com/tabskey)

### Descrição do projeto
Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.

### Organização do Projeto
Cada tarefa é documentada em uma issue que será atribuída a um membro do grupo conforme disponibilidade. A issue deverá ser desenvolvida em uma nova branch, criada a partir da master e que tenha em seu nome o ID da issue e uma descrição curta. Ao terminar o desenvolvimento, deverá ser submetido um pull request com a requisição de revisão dos demais membros do grupo. Quando aprovada, a branch será mergeada com a master e a issue será encerrada.

A arquitetura do projeto é formada por:

### Backend - API

* criar endpoints para serem usados pelo frontend da aplicação
* criar um endpoint que será usado para gravar os logs de erro em um banco de dados relacional
* a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

### Frontend

* deve implementar as funcionalidades apresentadas nos wireframes
* deve ser acessada adequadamente tanto por navegadores desktop quanto mobile
* deve consumir a API do produto
* desenvolvida na forma de uma Single Page Application

<br>
<img src="https://i.imgur.com/zxUU9TV.png" align="left"><h3> Tecnologias Utilizadas</h3>
<br>

* .NET Core
* Entity FrameWork Core
* Clean Code
* Swagger
* JWT
* Azure

<br>
<img src="https://i.imgur.com/Y3FAv0G.png" align="left"><h3> Ferramentas Utilizadas</h3>
<br>

* Visual Studio
* Trello
* WhatsApp
* Azure
* Heroku
* Asesprite

<br>
<img src="https://i.imgur.com/1tyiTCv.png" align="left"><h3>Banco de dados</h3>
<br> 

* SQLServer criado através do Azure.
<br>
<p align="center"><img src="https://i.imgur.com/Q0Lbafe.gif"><p>
<br>
  
### Rodar Aplicação

* Digite no gitbash:
```
git clone https://github.com/mayaracsferreira/error-central

```
Restaure as dependências, faça o build e rode:
```
dotnet restore
dotnet build
dotnet run

```

Acesse a url: [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html)
* Crie o usuário e logue para o obter o token pedido;
```
bearer {token}
```

### Deploy da Aplicação

O deploy da aplicação foi feito através do Azure.

* [API](https://errorcentral.azurewebsites.net/swagger/index.html)

### Demonstração da Aplicação

* [Back-end](https://www.youtube.com/watch?v=YM-jQsjoo_I)
* [Front-end](https://www.youtube.com/watch?v=CsaxbobwwpY)

<br>
<img src="https://i.imgur.com/1tyiTCv.png" align="left"><h3>Rotas </h3>
<br>


*  EventLogController
    - POST /api/EventLog - Cadastra novo erro na Central.
    - GET /api/EventLog - Traz todos os erros ativos cadastrados na Central.
    - GET /api/EventLog/{id} - Traz erro por número de ID
    - PUT /api/EventLog/{id} - Atualizo erro cadastrado
    - DELETE /api/EventLog/{id} - Apaga erro de acordo com o número de ID.
    - GET /api/EventLog/filters/{environment}/{orderBy}/{searchFor}/{field} - Filtra e agrupa os erros de acordo com os filtros selecionados.
    - GET /api/EventLog/groupBy/{environment}/{orderBy} - Agrupa e orderna dados de acordo com os parâmetros recebidos.
    - PUT /api/EventLog/arquivar/{id} - Arquiva erro por ID.
 
* Login
  - POST /api/login - Realiza o login do usuário
* User
  - GET /api/user - Lista todos os usuários cadastrados.
  - POST /api/user - Adiciona um novo usuário para acesso ao sistema
  - PUT /api/user - Troca a senha do usuário dado seu email e nova senha.

<br>
<img src="https://i.imgur.com/1tyiTCv.png" align="left"><h3>Front-end </h3>
<br>

Front-end foi desenvolvido por Mayara com a tecnologia Angular.
* Você pode checar [aqui](https://github.com/mayaracsferreira/error-central-frontend)!<p><br>

<br>
<img src="https://i.imgur.com/0BHIBij.gif" align="left"><h3>Agradecimentos</h3>
<br>

* [Alessandra Soares](https://www.linkedin.com/in/alessandrasoaressantos/)
* [Codenation](https://www.linkedin.com/company/code-nation/)
* [Ingrid Oliveira](https://www.linkedin.com/in/ingrid-c-oliveira/)
* [Thamirys Gameiro](https://www.linkedin.com/in/thamirys-gameiro-5535a520/)
* [ClearSale](https://www.linkedin.com/company/clearsale/)
* [Jacke Araujo](https://www.linkedin.com/in/jacke-araujo-it-recruiter-18691923/)
* Toda Comunidade .Net Girls.
<br>

![](https://i.imgur.com/n4mgcv2.gif)


## Curiosidades:

* Existe um sistema de automático de envio de emails de Boas vindas após a criação de usuário com email válido;<br>
~~desativado no deploy por questões de segurança haha~~
* Nosso mascote se chama **BugHunter**;
* Foi criado em Asesprite baseados nas cores da parceira do curso, *ClearSale* ;

### Primeira versão
<img src="https://i.imgur.com/G8jUrKj.gif" height=100>

