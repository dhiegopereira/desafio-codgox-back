# Como Executar o Projeto

## 1. **Execução com Docker**

### 1.1 **Iniciar o Docker**

Para iniciar o ambiente com Docker, execute o comando abaixo. Ele irá construir a imagem e rodar os containers em segundo plano:

```sh
sudo docker compose up --build -d
```

- `--build`: Garantir que as imagens sejam reconstruídas.
- `-d`: Executar os containers em segundo plano (modo "detached").

### 1.2 **Parar o Docker**

Para parar os containers, execute o seguinte comando:

```sh
sudo docker compose down
```

### 1.3 **Verificar o status dos containers Docker**

Se quiser verificar o status dos containers em execução, use:

```sh
sudo docker ps
```

Isso exibirá todos os containers que estão em execução, permitindo verificar se o seu ambiente está funcionando corretamente.

### 1.4 **Verificar logs dos containers**

Se precisar de mais informações sobre o que está acontecendo no seu container, você pode acessar os logs com:

```sh
sudo docker logs <nome_do_container>
```

Ou para um log contínuo:

```sh
sudo docker logs -f <nome_do_container>
```

## 2. **Execução Manual**

Caso prefira rodar o projeto manualmente (sem Docker), siga as etapas abaixo.

### 2.1 **Comando para Adicionar uma Migration**

Para adicionar uma nova migration ao projeto, execute o comando abaixo substituindo `<your_name_migration>` pelo nome da migration desejada:

```sh
dotnet ef migrations add <your_name_migration> --project ManageCustomer.Infrastructure --startup-project ManageCustomer.Api
```

- `--project`: Caminho do projeto que contém as migrations (`ManageCustomer.Infrastructure`).
- `--startup-project`: Caminho do projeto que executa a aplicação (`ManageCustomer.Api`).

### 2.2 **Comando para Atualizar o Banco com a Migration**

Depois de criar uma migration, execute o comando abaixo para atualizar o banco de dados com as mudanças:

```sh
dotnet ef database update --project ManageCustomer.Infrastructure --startup-project ManageCustomer.Api
```

### 2.3 **Realizar o Build do Projeto**

Para realizar o build do projeto, utilize o comando:

```sh
dotnet build ManageCustomer.Api
```

### 2.4 **Executar o Projeto**

Para rodar a aplicação, execute o comando abaixo:

```sh
dotnet run --project ManageCustomer.Api
```

```sh
ASPNETCORE_ENVIRONMENT=Development dotnet run --project ManageCustomer.Api
```

## 3. **Comandos Extras**

### 3.1 **Formatar o Projeto**

Se precisar formatar todo o código do projeto, execute:

```sh
dotnet format
```
