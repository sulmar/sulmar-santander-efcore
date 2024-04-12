# Zadanie: Tworzenie aplikacji konsolowej do importowania aktorów do bazy danych Sakila

## Wprowadzanie
Twoim zadaniem jest stworzenie aplikacji konsolowej, która umożliwi użytkownikowi zaimportowanie pliku z listą aktorów i zapisanie jej do bazy danych Sakila. Aplikacja powinna umożliwiać użytkownikowi określenie nazwy pliku.


## Wymagania:
- Użytkownik powinien mieć możliwość wprowadzenia nazwy pliku, np. _actors.csv_
- Aplikacja powinna obsługiwać format pliku CSV z nagłówkami, separator przecinek:
```
first_name,last_name
```
- Aplikacja powinna wyświetlać na bieżąco postęp
- Wszelkie operacje zapisu na bazie danych Sakila powinny być realizowane przy użyciu Entity Framework Core (EF Core) do obsługi baz danych.


_actors.csv_

```
first_name,last_name
Leonardo,Dicaprio
Meryl,Streep
Tom,Hanks
Brad,Pitt
Angelina,Jolie
Will,Smith
Jodie,Foster
Johnny,Depp
Julia,Roberts
Tom,Cruise
Scarlett,Johansson
Robert,De Niro
Natalie,Portman
Sharon,Stone
Anne,Hathaway
Nicole,Kidman
Matt,Damon
Kate,Winslet
Emma,Watson
George,Clooney
```