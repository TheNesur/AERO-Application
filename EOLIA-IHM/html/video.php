<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <link rel="shortcut icon" href="favicon.ico" />
    <script src="button.js"></script>
    <title>Eolia - Video</title>
</head>
<body>
<h1 class='title2'>Eolia - Video</h1>
    <nav class='redir'>
        <a href="index.html"><button class='accueil'>Accueil</button></a>
        <button class='accueil' onclick="returnback()">Retour</button>
    </nav>
    <br><br>
<?php
    
    require 'connexionbdd.php';

if (isset($_POST['id_mesure'])) 
{
    $id_mesure = $_POST['id_mesure']; // récupérer ce qu'on a choisi
    $query = "SELECT nomMesure, dateMesure,czMesure, cxMesure, rhoMesure, sMesure, fMesure, photoMesure, videoMesure FROM sessionmesure WHERE idsession = $id_mesure";
    $stmt = $db->prepare($query);
    $stmt->execute();
    $result = $stmt->fetch(PDO::FETCH_ASSOC);
    // récupérer les valeurs de ce qu'on a choisi dans la combobox
    
    // récupérer les valeurs de ce qu'on a choisi dans la combobox
    
    
echo '<br>';
        $imgDir = scandir("./VIDEO/" . $result['videoMesure']);
        
        echo"<div class='scroll'>";
        if(!is_null($result['videoMesure'])){
            foreach($imgDir as $fichier)
            {

                if($fichier != "." && $fichier != "..")
                {
                    echo "<div class='resultimg2'>";
                    echo "<a href='./VIDEO/" . $result['videoMesure'] . "/" . $fichier . "'><button class='accueil'>Télécharger la vidéo de la session</button></a>";
                    echo "</div>";
                    
                }
            }
        }echo"</div>"; 
    
    }
?>     


</body>
</html>