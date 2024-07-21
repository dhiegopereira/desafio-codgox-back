# Pair programming Back End

## Instruções para executar o projeto

- Inicializar a API

```cmd
cd DesafioBackCodgoX.Api
dotnet run
```

- Para realizar os testes
> Acesse: http://localhost:5030/swagger/index.html

## Objetivo do teste

Implementar o endpoint de login com os seguintes requisitos:
- Deve ser criado endpoint 

> POST /api/login

- Exemplo do payload:
```json
{
    "email": "teste@teste.com",
    "password": "12345678"
}
```
- Exemplo de resposta:
```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImRoaWVn"
}
```
- OBS: No token deve está contido o `id` e `email` do usuário

---

### Links úteis:
- [Autenticação e Autorização com JWT no ASP.NET Core](https://chatgpt.com/c/c4ecbec7-88bd-4957-91e5-e2fc9b71f4e0#:~:text=Autentica%C3%A7%C3%A3o%20e%20Autoriza%C3%A7%C3%A3o%20com%20JWT%20no%20ASP.NET%20Core)
- [Configurando o JWT Bearer Authentication](https://chatgpt.com/c/c4ecbec7-88bd-4957-91e5-e2fc9b71f4e0#:~:text=Configurando%20o%20JWT%20Bearer%20Authentication)
- [Trabalhando com JWTs no ASP.NET Core](https://chatgpt.com/c/c4ecbec7-88bd-4957-91e5-e2fc9b71f4e0#:~:text=Trabalhando%20com%20JWTs%20no%20ASP.NET%20Core)

---

![](./swagger.png)