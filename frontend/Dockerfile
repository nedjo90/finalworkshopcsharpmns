# Utiliser l'image Node.js pour la construction
FROM node:22.3.0 AS build

# Définir le répertoire de travail
WORKDIR /app

# Copier les fichiers package.json et package-lock.json
COPY package*.json ./

# Installer les dépendances
RUN npm install

# Copier le reste des fichiers du projet
COPY . .

# Construire l'application avec Vite
RUN npm run build

# Utiliser une image nginx pour servir l'application
FROM nginx:alpine

# Copier les fichiers construits depuis l'étape précédente
COPY --from=build /app/dist /usr/share/nginx/html

# Exposer le port 80
EXPOSE 80

# Démarrer nginx
CMD ["nginx", "-g", "daemon off;"]

