ifneq (, $(wildcard .env))
	include .env
	export ConnectionStrings__DefaultConnection
endif

all:
	dotnet run

run_local:
	dotnet run --urls "http://0.0.0.0:5000"

add_migrations:
	dotnet-ef migrations add DbMigration

remove_migrations:
	dotnet-ef migrations remove

update_database:
	dotnet-ef database update