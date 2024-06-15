### Evaluation - Workshop final - CDA C#

#### Objectif et notation
L'objectif de cette évaluation est d'évaluer les compétences non couvertes durant les cours et workshops, en mettant l'accent sur :

- **Façon de coder :** Pratique du clean code avec des standards élevés.
- **Développement orienté objet :** Application des principes fondamentaux de l'OO.
- **Développement d'une API :** Création d'une API REST pour la gestion des animaux et des races.
- **Développement avec une base de données :** Utilisation de SQL direct ou d'un ORM pour la persistance des données.
- **Tests unitaires :** Écriture de tests unitaires pour assurer le bon fonctionnement des fonctionnalités.

#### Règles de l'évaluation
**Contexte :** Vous êtes chargé de développer une application de gestion d'animaux avec système d'authentification obligatoire.

#### UI / UX
Le projet peut être réalisé en console avec des menus numérotés. Bien que la qualité des contrôles de saisie soit facultative, elle peut être prise en compte pour des points bonus.

#### Fonctionnalités demandées
1. **Authentification :**
   - Création de compte (Email + Mot de passe, sans confirmation).
   - Connexion utilisateur (Email + Mot de passe).

2. **Gestion des animaux :**
   - Ajout, modification, suppression d'un animal.
   - Listing de tous les animaux.
   - Recherche par race ou nom d'animal (choisir l'un des deux).

3. **Gestion des races :**
   - Ajout, modification, listing de races.

#### Contraintes techniques
- **Façon de coder :** Respect des principes de clean code (noms de variables explicites, méthodes courtes, etc.).
- **Développement orienté objet :** Utilisation de classes pour modéliser les animaux et les races.
- **Développement d'une API :** Création d'une API REST pour gérer les données.
- **Développement avec une base de données :** Utilisation de SQL direct ou d'un ORM comme Entity Framework.
- **Tests unitaires :** Minimum 5 tests unitaires avec NUnit ou xUnit pour assurer la robustesse du code.

#### Livrables attendus
- Le code source de l'application, compressé dans un fichier ZIP nommé avec votre nom et prénom (excluant les dossiers /bin et /obj), ou un lien public vers un dépôt Git.
- Scripts pour créer et peupler la base de données si SQL direct est utilisé.
- Les tests unitaires.

#### Conseils
- Gestion rigoureuse des erreurs et exceptions.
- Utilisation d'outils comme Postman pour tester l'API.

#### Bonus
Points bonus pour l'intégration d'un Docker permettant de déployer l'application sans manipulation directe de SQL.

