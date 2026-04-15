ifneq (, $(wildcard .env))
	include .env
	export ConnectionStrings__DefaultConnection
endif

all:
	dotnet run

add_migrations:
	dotnet-ef migrations add DbMigration

remove_migrations:
	dotnet-ef migrations remove

update_database:
	dotnet-ef database update