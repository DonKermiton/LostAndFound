# LostAndFound
 
Tworzenie bazy danych
 dotnet ef migrations add Init
 dotnet ef database update

W przypadku błedu migracji należy zmienić connectionString w pliku Entities/LostDbContext.cs z SQLEXPRESS na LocalDB

Autentykacja
Po utworzeniu konta należy się zalogować, następnie zostanie zwrócony zostanie JWT.
Aplikacja front (angular) posiada interceptor, który po udanym logowaniu przypisuje do pola jwt-token w localstorage.
Aby dokonać autentykacji z opcji innych niż angular, należy wysłać zapytanie z headerem Authorization z tokenem (Bearer d4sa5d45ads45as4d)
