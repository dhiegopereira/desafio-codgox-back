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

Implementar o endpoint que recebe o parâmetro email e retorna o nome e sobrenome
- Deve ser criado endpoint 

> POST /api/user?email=jose@gmail.com

- Exemplo de resposta:
```json
{
    "Nome completo": "José Silva"
}
```
