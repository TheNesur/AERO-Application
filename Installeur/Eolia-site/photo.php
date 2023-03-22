<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Eolia - Photo</title>
    <link rel="stylesheet" href="style.css">
    <link rel="shortcut icon" href="favicon.ico" />
    <script src="fullscreen.js"></script>
    <script src="button.js"></script>

</head>
<body>
<h1 class='title2'>Eolia - Photo</h1>
    <nav class='redir'>
        <a href="index.html"><button class='accueil'>Accueil</button></a>
        <button class='accueil' onclick="returnback()">Retour</button>
    </nav>

</div>
    <br><br>
<?php
    
    require 'connexion.php';

if (isset($_POST['id_mesure'])) 
{
    $id_mesure = $_POST['id_mesure']; // récupérer ce qu'on a choisi
    $query = "SELECT nomMesure, dateMesure,czMesure, cxMesure, rhoMesure, sMesure, fMesure, photoMesure, videoMesure FROM sessionmesure WHERE idsession = $id_mesure";
    $stmt = $db->prepare($query);
    $stmt->execute();
    $result = $stmt->fetch(PDO::FETCH_ASSOC);
    // récupérer les valeurs de ce qu'on a choisi dans la combobox
    

echo '<br>';
        $imgDir = scandir("./IMG/" . $result['photoMesure']);
        echo" <div id='modal01' class='modal' onclick='cache(this)'>
        <div class='contenu'>
          <img id='img01' style='width:100%'>
        </div>
        </div>";
        echo"<div class='scroll'>";
        if(!is_null($result['photoMesure'])){
            foreach($imgDir as $fichier)
            {

                if($fichier != "." && $fichier != "..")
                {
                    echo "<div class='resultimg2'>";
                echo "<img  onclick='onClick(this)' class='w3-hover-opacity' class ='imgrep' src='./IMG/" . $result['photoMesure'] . "/" . $fichier . "'></br>";
                
            
                    if(strpos($fichier, "PORTANCE") !== false) 
                    {
                        $valeur = preg_split('/ /', $fichier);
                                echo "Valeur de Portance: " . $valeur[2] . "<br>";
                                echo "Valeur de Trainee: " . $valeur[4] . "<br>";
                    }
                    echo "</div>";
                    
                }
            }
        }echo"</div>"; 
        
    }
?>     


</body>
</html>