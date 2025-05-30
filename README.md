# 🛒 Projet E-commerce - ASP.NET MVC

Ce projet est une application e-commerce développée avec **ASP.NET MVC**. Il permet à des clients de parcourir des produits, les ajouter au panier et passer des commandes. Les administrateurs peuvent gérer les produits, les commandes et les utilisateurs.

---

## 🚀 Fonctionnalités

### 👤 Côté Client
- S’inscrire et se connecter
- Parcourir les produits
- Ajouter des produits au panier
- Passer une commande
- Voir l’historique des commandes

### 🛠️ Côté Admin
- Ajouter, modifier et supprimer des produits
- Gérer les commandes
- Gérer les utilisateurs

---

## 🧩 Diagramme de classe

![Diagramme UML](./demo/diagramme.jpg)

---

## 🖼️ Captures d’écran

### 🔐 Page de connexion
![Login](./demo/Login.jpg)

### 🎛️ Interface Admin

- Capture 1 
  ![Admin1](./demo/Admin1.jpg)

- Capture 2
  ![Admin2](./demo/Admin2.jpg)

- Capture 3
  ![Admin3](./demo/Admin3.jpg)

### 🛍️ Interface Client

- Capture 1
  ![Client1](./demo/client1.jpg)

- Capture 2
  ![Client2](./demo/client2.jpg)

- Capture 3
  ![Client3](./demo/client3.jpg)

- Capture 4
  ![Client4](./demo/client4.jpg)

---

## ⚙️ Technologies utilisées

- ASP.NET MVC
- Entity Framework
- SQL Server
- Bootstrap

---

## 📁 Structure de base du projet

```bash
ecommerce/
├── Controllers/
├── Models/
│   └── Domain/
│   └── ViewModels/
├── Views/
├── wwwroot/
├── demo/
│   ├── *.jpg (captures d'écran)
│   └── diagramme.jpg
├── appsettings.json
├── Program.cs
└── Startup.cs
