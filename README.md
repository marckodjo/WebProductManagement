# Web Product Management API

Une API CRUD simple et efficace pour la gestion de produits, bas�e sur ASP.NET Core 8 et SQLite.

## Fonctionnalit�s

Cette API permet de g�rer des produits avec les op�rations CRUD compl�tes :
- ? Cr�er un produit
- ? Lire tous les produits ou un produit sp�cifique
- ? Mettre � jour un produit
- ? Supprimer un produit
- ? Obtenir uniquement les produits en stock
- ? Mettre � jour le stock d'un produit

## Technologies utilis�es

- **ASP.NET Core 8**
- **Entity Framework Core** avec **SQLite**
- **Swagger** pour la documentation de l'API

## D�marrage rapide

1. **Restaurer les packages** :
   ```bash
   dotnet restore
   ```

2. **Lancer l'application** :
   ```bash
   dotnet run
   ```

3. **Acc�der � l'API** :
   - Swagger UI : `https://localhost:7257/swagger`
   - API : `https://localhost:7257/api/products`

## Endpoints disponibles

### Produits

| M�thode | Endpoint | Description |
|---------|----------|-------------|
| GET | `/api/products` | R�cup�re tous les produits |
| GET | `/api/products/{id}` | R�cup�re un produit par son ID |
| GET | `/api/products/instock` | R�cup�re les produits en stock |
| POST | `/api/products` | Cr�e un nouveau produit |
| PUT | `/api/products/{id}` | Met � jour un produit existant |
| DELETE | `/api/products/{id}` | Supprime un produit |
| PATCH | `/api/products/{id}/stock` | Met � jour le stock d'un produit |

### Mod�le Product (Simplifi�)

```json
{
  "id": 0,
  "name": "string (requis, max 100 caract�res)",
  "description": "string (optionnel, max 500 caract�res)",
  "price": 0.0,
  "stock": 0
}
```

## Exemples d'utilisation

### Cr�er un produit
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

### R�cup�rer tous les produits
```bash
curl https://localhost:7257/api/products
```

### Mettre � jour le stock
```bash
curl -X PATCH https://localhost:7257/api/products/1/stock \
  -H "Content-Type: application/json" \
  -d '15'
```

## Base de donn�es

L'application utilise SQLite avec une base de donn�es `products.db` cr��e automatiquement au d�marrage.

### Donn�es de test

L'application inclut 3 produits de test :
1. Ordinateur portable (999.99�, stock: 10)
2. Souris sans fil (29.99�, stock: 50)
3. Clavier m�canique (89.99�, stock: 25)

## Architecture simplifi�e

Cette impl�mentation utilise une approche **simple et directe** :
- **DbContext directement dans le contr�leur** (sans Repository Pattern)
- **Mod�le Product minimaliste** (4 propri�t�s essentielles)
- **Gestion d'erreurs simplifi�e** (validation automatique ASP.NET Core)
- **Configuration en dur** (pas de fichiers de configuration complexes)

### Structure du projet
```
WebProductManagement/
??? Controllers/
?   ??? ProductsController.cs (API endpoints)
??? Data/
?   ??? AppDbContext.cs (Entity Framework)
??? Models/
?   ??? Product.cs (Mod�le simplifi�)
??? Program.cs (Configuration minimale)
??? README.md
```

## Avantages de cette approche

- ? **Simplicit�** : Code minimal et facile � comprendre
- ? **Performance** : Pas de couches d'abstraction inutiles
- ? **Maintenance** : Moins de fichiers, moins de complexit�
- ? **Rapidit� de d�veloppement** : Id�al pour prototypes et petites applications
- ? **Validation automatique** : Annotations sur le mod�le Product
- ? **Base de donn�es automatique** : SQLite cr�� au d�marrage