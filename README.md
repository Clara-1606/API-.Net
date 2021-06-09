# API .Net

Nous avons réaliser une API .NET CORE suivant les bonnes pratiques vues  :
• Découper les couches Presentation – BusinessLayer – DataAccessLayer
• Utiliser la librairie Entity Framework Core et Swagger
• Utiliser l’injection de dépendances et l’inversion de contrôle


Le but de l’API va être une gestion de tâches à effectuer par utilisateur.

Il y a un CRUD des utilisateurs et des tâches. Cependant la suppression d’une tâche à un utilisateur ne pourra seulement être faite que lorsque celle-ci a le statut « à faire ». Une tâche terminée ou en cours pour un utilisateur ne pourra pas être supprimée.
On peut aussi lui/leur associer des tâches qui auront un intitulé et un état (à faire, en cours, terminé). 

Toutes les routes sont disponibles pour récupérer les utilisateurs ainsi que leurs tâches associées.
La gestion des erreurs est mis en place (ex : récupérer un utilisateur qui n’existe pas, associer une tâche qui n’existe pas à un utilisateur, etc.)

