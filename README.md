Notice Utilisateur- Logiciel de contrôle de soufflerie Eolia

Installation :

Installer la version de Raspbian suivante : Buster
(Cette version est recommandée car c’est dessus que les tests et le développement a été effectuée.)

- Téléchargez et extraire le fichier EoliaPackage.zip sur votre Raspberry
- Ouvrez un terminal et accédez au répertoire où se trouve le dossier extrait
- Exécutez la commande suivante : sudo sh EoliaReady.sh  (accès à internet nécessaire)
- Suivez les instructions à l'écran pour installer les composants nécessaires au logiciel.
- Par défaut, faites “TOUT”, puis redémarrer le raspberry avec l’écran tactile branché.
(La description des actions que fait le script se trouve dans la partie débogage.)


Lancement du logiciel :

Il existe trois moyens de lancer le logiciel de control de la soufflerie

- Exécutez la commande suivante : sudo mono Eolia-IHM.exe dans le repertoire /Eolia-IHM/
- Exécutez la commande suivante : eolia-launch
- Cliquez sur la raccourci sur le bureau “Eolia”
