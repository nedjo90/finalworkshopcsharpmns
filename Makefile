# Déterminer le système d'exploitation
UNAME := $(shell uname)

# Variables par défaut (Linux par exemple)
OPEN_COMMAND := xdg-open

# Condition pour macOS
ifeq ($(UNAME), Darwin)
    OPEN_COMMAND := open
endif

# Condition pour Windows avec PowerShell
ifeq ($(findstring MINGW,$(UNAME)), MINGW)
    OPEN_COMMAND := start
endif


run: docker
	$(OPEN_COMMAND) "http://localhost:5043"

docker:
	docker compose up -d

clean:
	docker compose down

fclean:
	docker compose down --rmi all -v

re: fclean run
	
