# Web Product Management API

Une API CRUD simple et efficace pour la gestion de produits, basée sur ASP.NET Core 8 et SQLite.

## Fonctionnalités

Cette API permet de gérer des produits avec les opérations CRUD complètes :
- ? Créer un produit
- ? Lire tous les produits ou un produit spécifique
- ? Mettre à jour un produit
- ? Supprimer un produit
- ? Obtenir uniquement les produits en stock
- ? Mettre à jour le stock d'un produit

## Technologies utilisées

- **ASP.NET Core 8**
- **Entity Framework Core** avec **SQLite**
- **Swagger** pour la documentation de l'API

## Démarrage rapide

1. **Restaurer les packages** :
   ```bash
   dotnet restore
   ```

2. **Lancer l'application** :
   ```bash
   dotnet run
   ```

3. **Accéder à l'API** :
   - Swagger UI : `https://localhost:7257/swagger`
   - API : `https://localhost:7257/api/products`

## Endpoints disponibles

### Produits

| Méthode | Endpoint | Description |
|---------|----------|-------------|
| GET | `/api/products` | Récupère tous les produits |
| GET | `/api/products/{id}` | Récupère un produit par son ID |
| GET | `/api/products/instock` | Récupère les produits en stock |
| POST | `/api/products` | Crée un nouveau produit |
| PUT | `/api/products/{id}` | Met à jour un produit existant |
| DELETE | `/api/products/{id}` | Supprime un produit |
| PATCH | `/api/products/{id}/stock` | Met à jour le stock d'un produit |

### Modèle Product (Simplifié)

```json
{
  "id": 0,
  "name": "string (requis, max 100 caractères)",
  "description": "string (optionnel, max 500 caractères)",
  "price": 0.0,
  "stock": 0
}
```

## Exemples d'utilisation

### Créer un produit
```bash
curl -X POST https://localhost:7257/api/products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Nouvel ordinateur",
    "description": "Description du produit",
    "price": 1299.99,
    "stock": 5
  }'
```

### Récupérer tous les produits
```bash
curl https://localhost:7257/api/products
```

### Mettre à jour le stock
```bash
curl -X PATCH https://localhost:7257/api/products/1/stock \
  -H "Content-Type: application/json" \
  -d '15'
```

## Base de données

L'application utilise SQLite avec une base de données `products.db` créée automatiquement au démarrage.

### Données de test

L'application inclut 3 produits de test :
1. Ordinateur portable (999.99€, stock: 10)
2. Souris sans fil (29.99€, stock: 50)
3. Clavier mécanique (89.99€, stock: 25)

## Architecture simplifiée

Cette implémentation utilise une approche **simple et directe** :
- **DbContext directement dans le contrôleur** (sans Repository Pattern)
- **Modèle Product minimaliste** (4 propriétés essentielles)
- **Gestion d'erreurs simplifiée** (validation automatique ASP.NET Core)
- **Configuration en dur** (pas de fichiers de configuration complexes)

### Structure du projet
```
WebProductManagement/
??? Controllers/
?   ??? ProductsController.cs (API endpoints)
??? Data/
?   ??? AppDbContext.cs (Entity Framework)
??? Models/
?   ??? Product.cs (Modèle simplifié)
??? Program.cs (Configuration minimale)
??? README.md
```

## Avantages de cette approche

- ? **Simplicité** : Code minimal et facile à comprendre
- ? **Performance** : Pas de couches d'abstraction inutiles
- ? **Maintenance** : Moins de fichiers, moins de complexité
- ? **Rapidité de développement** : Idéal pour prototypes et petites applications
- ? **Validation automatique** : Annotations sur le modèle Product
- ? **Base de données automatique** : SQLite créé au démarrage