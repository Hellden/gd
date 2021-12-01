

# ASPNETCORE
**EN**
### Prerequisite
 - IIS
 - [.Net Core SDK] (https://www.microsoft.com/net/download/windows)
 - SQL Server Express (tested on 2016 and 2017)
 - SQL Server Management
 
Load the project on Visual Studio and create the Web Deploy package in build release.

### IIS configuration
 - Create a GCSMS directory
 - Create the site gcsms.fr
 - In the application pool
    - .NET CLR Version -> No Managed Code (Reserved for ASP.NET CORE)
    - Managed pipeline mode -> integrated
 - Import WebDploy package created previously (Install WebDeploy version 3.5)
 - Fill in the following connection string:
 

> `Server =. \\ sqlexpress; Integrated Security = true; Database = ASPNETCORE_GCSMS`


### Assign rights to the sql database for the IIS Application Pool user.
Log in to *. \ Sqlexpress * with SQL Server Management with your local account.

We will put the rights on the database ASPNETCORE_GCSMS to the user ** [IIS APPPOOL \ gcsms.fr] **, think to put in role of the Server ** sysadmin **

Start the Website, it should be functional !!

### ENJOY



# ASPNETCORE
**FR**
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
