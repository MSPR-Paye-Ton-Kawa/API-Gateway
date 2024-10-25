# PS-2024-MSPR-Paye-Ton-Kawa

## 📚 Projet Scolaire | MSPR

Juin-Septembre 2024

Groupe : Juliette, Flavien, Yasmine & Colas

### 📌 Consignes du projet : 

CERTIFICATION PROFESSIONNELLE EXPERT EN INFORMATIQUE ET SYSTEME D’INFORMATION

BLOC 4 – Concevoir et développer des solutions applicatives métier et spécifiques (mobiles, embarquées et ERP)

Cahier des Charges de la MSPR « Conception d’une solution applicative en adéquation avec l’environnement technique étudié


### 🐱 Notre projet :

Ce repos est destiné à l'API Gateway.
Dans le contexte de notre projet, l'API Gateway regroupe nos trois services d'API : Produits, Clients et Commandes. Grâce à cette architecture, les clients peuvent interagir facilement avec ces différents services sans avoir à gérer chaque API séparément

Commandes Docker :

docker build -t api_gateway:latest .

docker run -d -p 8080:80 --name api_gateway api_gateway:latest


### 📎 Branches :

- main : Solution finale, prod.
  
- dev : Solution fonctionnelle en dev.
  
- hotfix : Correction de bugs et autres.

- release : Solution fonctionnelle de dev à prod.

- feature-pipeline : Développement lié à la pipeline ci-cd.

- feature-test : Développement des tests.

- feature-owasp-dependency-check : Développement de la partie sécurité.

- feature-docker-compose : Développement de la partie Docker.

- feature-routing : Développement lié au routing.

- bugfix-* : Correction de bugs.


### 💻 Applications et langages utilisés :

- C#
- Visual Studio
- Docker



## 🌸 Merci !
© J-IFT
