<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <link rel="shortcut icon" href="favicon.ico" />
    <script src="button.js"></script>
    <title>Eolia - Configuration</title>
</head>
<body>
    <h1 class='title2'>Eolia - Configuration</h1>
    <nav class='redir'>
        <a href="index.html"><button class='accueil'>Accueil</button></a>
        <button class='accueil' onclick="returnback()">Retour</button>
        <a href="VoirLogs.php"><button class="accueil">Logs</button></a>
    </nav>
    <br><br>
    <div id="box">
    
        <?php
            		$ficherconfig = "/Eolia-IHM/config/EoliaConfig.conf";
                    if($_POST['contenu']){
                        $content = $_POST['contenu'];
                        file_put_contents($ficherconfig, $content);
                    }
                    if(file_exists($ficherconfig)){
                        echo "<form action='Configuration.php' method='post'>";
                        $content = file_get_contents($ficherconfig);
                        echo "<textarea id='textarea2' name='contenu'>$content</textarea>";
                        echo "<input type='submit' class='accueil' name='submit' value='Valider les modifications'>";
                        echo "</form>";
                    }else{
                        echo "<textarea>Fichier config non trouvé</textarea>";
                    }

                    



        ?>


                <script>
                var myTextArea = document.getElementById("textarea2");
                myTextArea.addEventListener("keydown", function(event) {
                if (event.keyCode === 13 || event.keyCode === 40) { // 13 est le code de la touche "Entrée", 40 est le code de la touche de flèche basse
                event.preventDefault();
                }
                  });
                </script>

    </div>
</body>
</html>