# SpotifyLite

## Descrição
### Aplicação desenvolvida como Projeto de bloco da disciplina Persistência e MVC da pós MIT em Engenharia de Software .Net no [Instituto Infnet](https://www.infnet.edu.br/infnet/instituto)
### Sob orientação do Prof. Msc. [Rafael Cruz](https://github.com/rafaelcruz-net)

## O objetivo dessa aplicação é ser uma streamer de música para uma startup, ultilizando .Net Core.
## Nesse sistema poderemos criar, editar listar e deletar usuários, playlists e bandas. 
                          
## Diagrama UML [draw.io](https://app.diagrams.net/#LC%C3%B3pia%20do%20DiagramaSpotifyLite.drawio)

##  Links
#### local: http://localhost:7215

#### Swagger: https://localhost:7215/swagger/index.html
## Iniciando aplicação
- Use o comando `dotnet build` para compilar o projeto dentro do arquivo SpotifyLite.Api
- Após a compilação use o comando `dotnet run` para inicializar a aplicação

## Rotas e modelos com campos obrigatórios para teste

##  - Usuario
####  `POST`
**​/api​/usuario/criar**
```js
{
  "nome": "string",
  "email": {
    "valor": "string"
  },
  "password": {
    "valor": "string"
  },
  "playlists": [
    {
      "nome": "string",
      "musicas": [
        {
          "nome": "string",
          "duracao": 0
        }
      ]
    }
  ]
}
```
####  `GET`
**​/api​/usuario/obter-todos**

####  `GET`
**​/api​/usuario/obter-por-id/{id}**

####  `PUT`
**​/api​/usuario/editar/{id}**
```js
{
  "nome": "string",
  "email": {
    "valor": "string"
  },
  "password": {
    "valor": "string"
  },
  "playlists": [
    {
      "nome": "string",
      "musicas": [
        {
          "nome": "string",
          "duracao": 0
        }
      ]
    }
  ]
}
```

####  `DELETE`
**​/api​/usuario/excluir/{id}**


## - Album
####  `POST`
**/api/album/criar**
```js
{
  "nome": "string",
  "dataLancamento": "2022-08-04T01:24:32.662Z",
  "backdrop": "string",
  "musicas": [
    {
      "nome": "string",
      "duracao": 0
    }
  ]
}
```

####  `GET`
**​/api​/album/obter-todos"**

####  `GET`
**​/api​/album/obter-por-id/{id}"**

####  `PUT`
**​/api​/album/editar/{id}**
```js
{
  "nome": "string",
  "dataLancamento": "2022-08-04T01:24:49.308Z",
  "backdrop": "string",
  "musicas": [
    {
      "nome": "string",
      "duracao": 0
    }
  ]
}
```
####  `DELETE`
**​/api​/album/excluir/{id}**


## - Banda
####  `POST`
**/api/banda/criar**
```js
{
  "nome": "string",
  "foto": "string",
  "descricao": "string"
}
```

####  `GET`
**​/api​/banda/obter-todos"**

####  `GET`
**​/api​/banda/obter-por-id/{id}"**

####  `PUT`
**​/api​/banda/editar/{id}**
```js
{
  "nome": "string",
  "foto": "string",
  "descricao": "string"
}
```
####  `DELETE`
**​/api​/banda/excluir/{id}**

