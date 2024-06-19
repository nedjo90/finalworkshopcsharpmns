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


run: docker sleep_with_timer
	$(OPEN_COMMAND) "http://localhost:5043"

docker:
	docker compose up -d

clean:
	docker compose down

fclean:
	docker compose down --rmi all -v

re: fclean run

sleep_with_timer:
	@bash -c 'for ((i=1;i<=100;i++)); do printf "\rAlmost done %i%%" $$i;\
	sleep 0.1; done; echo ""'
	
