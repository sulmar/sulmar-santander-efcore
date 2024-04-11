# Zadanie: Dostępność filmów

## Wprowadzanie
Twoim zadaniem jest stworzenie aplikacji konsolowej, która umożliwi wyszukiwanie filmów i wyświetli ilość dostępnych sztuk w poszczególnych wypożyczalniach.


## Wymagania:
- Użytkownik powinien mieć możliwość wprowadzenia kryteriów wyszukiwania, takich jak tytuł filmu lub kategoria.
- Aplikacja powinna wyświetlać wyniki wyszukiwania w czytelny sposób, prezentując informacje o znalezionych filmach, takie jak tytuł, miasto wypożyczalni, ilość dostępnych sztuk w następujący sposób:

| film_id | film_title | store_city | inventory_stack |
| ---- | ---- | ---- | ---- |
| 1 | ACADEMY DINOSAUR | Lethbridge | 3 |
| 2 | ACADEMY DINOSAUR | Woodridge | 4 |
| 3 | ADAPTATION HOLES | Lethbridge | 2 |
| 4 | ADAPTATION HOLES | Lethbridge | 1 |
| ... | ... | ... | ... |


- Wszelkie operacje na bazie danych Sakila powinny być realizowane przy użyciu Dapper.


