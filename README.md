# Utiliser les commandes ci dessous pour le projet

## Cloner le repo et lancer le projet

```
git clone git@github.com:nedjo90/finalworkshopcsharpmns.git && cd finalworkshopcsharpmns && make
```


## Commandes Makefile

### Lancer tout automatiquement (MySQL + API + Frontend, puis ouvrir le navigateur)

Pour lancer tous les services (MySQL, API, Frontend) et ouvrir automatiquement le navigateur :

```
make
```

ou explicitement :

```
make run
```

### Lancer uniquement le docker-compose up

Pour démarrer les conteneurs Docker en arrière-plan :

```
make docker
```

### Arrêter les conteneurs Docker

Pour arrêter les conteneurs Docker en cours d'exécution :

```
make clean
```

### Arrêter les conteneurs, supprimer les images et les volumes

Pour nettoyer complètement l'environnement Docker (arrêter les conteneurs, supprimer les images et les volumes) :

```
make fclean
```

### Tout supprimer et tout relancer

Pour effectuer un nettoyage complet, puis relancer tous les services :

```
make re
```
---

