Umożliwia automatyczne wygenerowane modelu danych i kontekstu na podstawie istniejącej bazy danych. Sposób generowania modelu możemy dostosować za pomocą szablonów w formacie T4.

## Generowanie modelu

1. Zainstaluj narzędzia EF dla dotnet CLI

- lokalnie
~~~ bash
dotnet tool install --local dotnet-ef
~~~

- globalne
~~~ bash
dotnet tool install --global dotnet-ef
~~~

1. Sprawdź instalację
~~~ bash
dotnet ef
~~~ 

- Powinna pojawić się taka wizytówka:

```

                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 8.0.4

Usage: dotnet ef [options] [command]

Options:
  --version        Show version information
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  database    Commands to manage the database.
  dbcontext   Commands to manage DbContext types.
  migrations  Commands to manage migrations.

Use "dotnet ef [command] --help" for more information about a command.****
```


2. Dodaj paczkę
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
~~~ 

1. Dodaj paczkę
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.Design
~~~ 

1. Generowanie modelu 
~~~ bash
dotnet ef dbcontext scaffold "Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True"  Microsoft.EntityFrameworkCore.SqlServer
~~~

- Generowanie modelu 
~~~ bash
dotnet ef dbcontext scaffold "Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True"  Microsoft.EntityFrameworkCore.SqlServer -f -o Infrastructure -n Sakila.Infrastructure
~~~ 

- Generowanie modelu 

~~~ bash
 dotnet ef dbcontext scaffold "Name=ConnectionStrings:Sakila" Microsoft.EntityFrameworkCore.SqlServer -o ..\Sakila.Domain\Model  --context-dir ..\Sakila.Infrastructure\ -f -n Sakila.Domain.Model --context-namespace Sakila.Intrastructure
 ~~~ 


# Dostosowanie kontekstu

## Dostosowanie modelu

- Utwórz klasę częściową o takiej samej nazwie jak kontekst aplikacji
~~~ csharp
partial class SakilaContext
{

   

}
~~~