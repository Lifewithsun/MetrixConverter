# MetrixConverter

1. Copy project files on your local machine.
2. Change the connection string of SQL Server in /Src/PublicApi/appsettings.json to your local sql
3. Ensure your connection strings in appsettings.json point to a local SQL Server instance.
4. Ensure the tool EF was already installed. 
5. Open Project managar console in your project run folowing command in sequenital manner
  ```
dotnet restore
dotnet tool restore
cd src\PublicApi
dotnet ef database update -c matrixdatacontext -p "../Infrastructure/Infrastructure.csproj" -s "PublicApi.csproj"
dotnet ef migrations add InitialModel --context matrixdatacontext -p ../Infrastructure/Infrastructure.csproj -s PublicApi.csproj -o Data/Migrations
  ```
6. Now run the Project.




