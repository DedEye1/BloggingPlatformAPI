ifneq (, $(wildcard .env))
	include .env
	export ConnectionStrings__DefaultConnection
endif

all:
	dotnet run