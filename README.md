<h1>Projet de contrôle de soufflerie Eolia</h1>
<p>L'ensemble de logiciel développé dans ce projet a pour but de permettre d'étudier les forces d'un corps dans une soufflerie.</p>
<p>Le système se compose de deux parties :</p>
<ul>
  <li>
    <h3>ESP32</h3>
    <p>Permettant de récupérer les forces provenant des jauges de contraintes et de les mettre à l'échelle.</p>
  </li>
  <li>
    <h3>Raspberry Pi</h3>
    <p>Où se trouve l'interface utilisateur qui permet de modifier la vitesse de la soufflerie, afficher les valeurs en temps réel, enregistrer ces dernières dans des sessions qui sont hébergées sur le site web se trouvant aussi sur le Raspberry.</p>
  </li>
</ul>
<p>Le logiciel de l'interface utilisateur permet de :</p>
<ul>
  <li>Visualiser la portance et la traînée</li>
  <li>Visualiser la vitesse</li>
  <li>Modifier la vitesse</li>
  <li>Modifier l'échelle des jauges (par défaut, jauges de 1 kg configurées en milli-newton)</li>
  <li>Visualiser en temps réel la caméra CSI</li>
</ul>
<p>L'interface utilisateur peut fonctionner sous Windows nécessitant quelques adaptations du fichier de configuration, le script d'installation ne fonctionnant pas sur ce dernier.</p>
<p>Le diagramme ci-dessous permet de se rendre compte de comment fonctionne le système :</p>

![snoufl](https://user-images.githubusercontent.com/64744563/229600677-10613498-8f32-4ff8-ab7c-7f5c0e5bae6d.png)

<p>Nous vous invitons à consulter le dossier technique se trouvant dans le dossier DOC pour plus d'informations.</p>
<h2>Notice utilisateur - Logiciel de contrôle de soufflerie Eolia</h2>
<h3>Installation</h3>
<p>Pour installer le logiciel de contrôle de soufflerie Eolia, veuillez suivre les étapes suivantes :</p>
<ol>
  <li>Installer la version de Raspbian suivante : Buster (cette version est recommandée car c’est dessus que les tests et le développement ont été effectués).</li>
  <li>Télécharger et extraire le fichier EoliaPackage.zip sur votre Raspberry.</li>
  <li>Ouvrir un terminal et accéder au répertoire où se trouve le dossier extrait.</li>
  <li>Exécuter la commande suivante : <code>sudo sh EoliaReady.sh</code> (accès à internet nécessaire).</li>
  <li>Suivre les instructions à l'écran pour installer les composants nécessaires au logiciel.</li>
  <li>Par défaut, faire “TOUT”, puis redémarrer le Raspberry avec l’écran tactile branché. (La description des actions que fait le script se trouve dans la partie débogage.)</li>
</ol>
<h3>Lancement du logiciel</h3>
<p>Il existe trois moyens de lancer le logiciel de contrôle de soufflerie Eolia :</p>
<ol>
  <li>Exécuter la commande suivante : <code>mono Eolia-IHM.exe</code> dans le répertoire <code>/Eolia-IHM/</code>.</li>
  <li>Depuis l'interface graphique, cliquer sur l'icône Eolia dans le menu principal.</li>
  <li>Exécuter la commande suivante dans un terminal : <code>cd /Eolia-IHM/ && mono Eolia-IHM.exe</code></li>
</ol>
<p>Après le lancement du logiciel, vous accédez à la page d'accueil du système. Vous pouvez naviguer sur les différentes pages de l'interface utilisateur à l'aide des boutons situés en bas de la fenêtre.</p>
<p>Vous pouvez également accéder aux sessions enregistrées en cliquant sur l'icône “Session” dans le coin supérieur droit de l'interface utilisateur.</p>
<p>Pour arrêter le logiciel, vous pouvez fermer la fenêtre ou exécuter la commande suivante dans un terminal : <code>killall mono</code></p>
<p>Nous espérons que cette notice vous sera utile pour installer et utiliser le logiciel de contrôle de soufflerie Eolia. Si vous avez des questions ou des problèmes, n'hésitez pas à nous contacter.</p>