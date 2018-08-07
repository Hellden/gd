# ASPNETCORE_GCSMS

### Prérequis
 - IIS
 - [.Net Core SDK](https://www.microsoft.com/net/download/windows)
 - SQL Serveur Express (testé sur 2016 et 2017)
 - SQL Serveur Management
 
Charger le projet sur Visual Studio et créer le packet Web Deploy en build Release.

### Configuration IIS
 - Créer un répertoire GCSMS
 - Créer le site gcsms.fr
 - Dans le pool d'application
    - Version du CLR .NET -> Aucun code managé (réservé à ASP.NET CORE)
    - Mode pipeline géré -> intégré
 - Importer le packet WebDploy créé précédement (Installer la version WebDeploy 3.5)
 - Renseigner la chaine de connexion suivante:
 

>`Server=.\\sqlexpress;Integrated Security=true;Database=ASPNETCORE_GCSMS`


### Attribuer les droits sur la base de données sql pour l'utilisateur du Pool d'application IIS.
Connectez-vous à *.\sqlexpress* avec SQL Serveur Management avec votre compte local.

Nous allons mettre les droits sur la base de donnée ASPNETCORE_GCSMS à l'utilisateur **[IIS APPPOOL\gcsms.fr]**, penser à mettre en rôle du Serveur **sysadmin**

Démarrer le Site Web, il devrait être fonctionnel !!

### ENJOY