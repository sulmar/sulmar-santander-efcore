# Przykłady ze szkolenia Entity Framework Core 8

## Wprowadzenie

Witaj w repozytorium z materiałami do szkolenia ** Entity Framework Core 8**.

Do rozpoczęcia tego kursu potrzebujesz następujących rzeczy:

1. [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
2. Sklonuj repozytorium  git repository from GitHub.

## Przygotowanie
1. Sklonuj repozytorium Git
```
git clone https://github.com/sulmar/sulmar-santander-efcore
```

2. Utwórz bazę danych
```
sqlcmd -S (local) -d master -E -i sql/sql-server-sakila-schema.sql
```

3. Załadowuj przykładowane dane
```
sqlcmd -S (local) -d sakila -E -i sql/sql-server-sakila-insert-data.sql
```

4. Sprawdź
```
sqlcmd -S (local) -d sakila -E -q "SELECT TOP 10 * FROM Film" 
```