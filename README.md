# 14530_employes_managment

# ligacao a base de dados

1. verificar nos container se o sql server esta operacional !! 
se nao estiver .. docker compose up .. para ativar e instalar as imagens do serviço

2. verificar a extensao de SQL Server (mssql) para instalar pacotes como o SSMS 

3. como fazer ligação .. na extensao Sql Server.. criar nova conexão  
    1. nome: qualquer 1
    2. server : 127.0.0.1
    3. user: sa (é sempre este)
    4. password: o que está no docker (Password123!)
    5. tipo de certificação: Optional  

## Como iniciar o projeto e a base de dados (local)

1. Subir o banco (Docker Compose):

```bash
docker compose up -d
docker compose ps
```

2. Restaurar e executar a aplicação (perfil `http` abre em http://localhost:5170):

```bash
dotnet restore 14530_employes_managment/14530_employees_managment.csproj
dotnet run --project 14530_employes_managment/14530_employees_managment.csproj --launch-profile http
dotnet watch run
```
3. Migrações:

```bash
add migrations
update database
dotnet database updat

dotnet ef database update1 --project 14530_employes_managment/14530_employees_managment.csproj --startup-project 14530_employes_managment/14530_employees_managment.csproj
```
