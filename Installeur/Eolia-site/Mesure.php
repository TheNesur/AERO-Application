<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <link rel="shortcut icon" href="favicon.ico" />
    <script src="chartjs/Chart.min.js"></script>
    <script src="button.js"></script>
    <script src="graphportance.js"></script>
    <title>Eolia - Mesure</title>
</head>

<body>
    <h1 class='title2'>Eolia - Mesure</h1>
    <nav class='redir'>
        <a href="index.html"><button class='accueil'>Accueil</button></a>
        <button class='accueil' onclick="returnback()">Retour</button>
    </nav>
<?php
require 'connexionbdd.php';


if (isset($_POST['mesureamodifier'])) 
{
    $nouveau_nom = $_POST['nouveau_nom'];
    $idmesure = $_POST['mesureamodifier'];
    $sql = "UPDATE sessionmesure SET nomMesure = '$nouveau_nom' WHERE idSession = $idmesure;";
    $db->exec($sql);
    echo 'bien renommé : ' . $e->getMessage();
}
    
if (isset($_POST['supprimer'])) {
   
    $idmesure = $_POST['mesureasupprimer'];
    $repphoto = $_POST['photoasupprimer'];
    $repvideo = $_POST['videoasupprimer'];
	$imgDir = "./IMG/" . $repphoto;
	$vidDir = "./VIDEO/" . $repvideo;
		
	
	if (is_dir($imgDir)) { // si image existe alors on supprime les images du dossier

        // Supprimer tous les fichiers dans le répertoire "photo"
        $files = scandir($imgDir);
        foreach ($files as $file) {

			if($file != "." && $file != "..")
            {
				$file = "./IMG/" . $repphoto . "/" . $file;
				if (is_file($file)) {
					if(!unlink(realpath($file))){
						echo "Erreur lors de la supression d'une image"; exit();}
				}else{
					echo "Erreur lors de la supression d'une image";
					exit(); 
				}
			}
        }
    }
	
	if (is_dir($vidDir)) { // idem que image


        // Supprimer tous les fichiers dans le répertoire "video"
        $files = scandir($vidDir);
        foreach ($files as $file) {

			if($file != "." && $file != "..")
            {
				$file = "./VIDEO/" . $repvideo . "/" . $file;
				if (is_file($file)) {
					is_writable(realpath($file));
					if(!unlink(realpath($file))){
						echo "Erreur lors de la supression d'une vidéo"; exit(); }
				}else{
					echo "Erreur lors de la supression d'une video";
					exit();
				}
			}
        }
    }

	
    $sql = "DELETE FROM sessionmesure WHERE idSession = $idmesure;";
    $db->exec($sql);
    $sql = "DELETE FROM mesure WHERE idSession = $idmesure;";
    $db->exec($sql);



}

    ?>
    
<div id="global">
        <?php
  

    $query = 'SELECT idSession,nomMesure FROM sessionmesure ORDER BY dateMesure DESC';

    // récuperer les resultat 
    $stmt = $db->query($query);
    $results = $stmt->fetchAll(PDO::FETCH_ASSOC);


    // les afficher dans la combobox
    echo '<br>';
    echo '<form id="choix" method="post">';
    echo '<select class="logsstyle" name="id_mesure">';
    foreach ($results as $row) {
        $selected = "";
        if(isset($_POST['id_mesure']) && $_POST['id_mesure'] == $row['idSession']){
            $selected = "selected";
        }
        echo '<option value="' . $row['idSession'] . '" '.$selected.'>' . $row['nomMesure'] . '</option>';
    }
    echo '</select>';
    echo '<input class="logsstyle"type="submit" value="Valider">';
    echo '</form>';


    if (isset($_POST['id_mesure'])) 
    {
        $id_mesure = $_POST['id_mesure']; // récupérer ce qu'on a choisi

        // récupérer les valeurs de ce qu'on a choisi dans la combobox
        $query = "SELECT nomMesure, dateMesure,czMesure, cxMesure, rhoMesure, sMesure, fMesure, photoMesure, videoMesure FROM sessionmesure WHERE idsession = $id_mesure";
        $stmt = $db->prepare($query);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);


        $query = "SELECT portanceMesure, traineeMesure, idmesure, vitesseMesure FROM mesure WHERE idSession = $id_mesure ORDER BY idMesure";
        $stmt = $db->prepare($query);
        $stmt->execute();
        $result1 = $stmt->fetchAll(PDO::FETCH_ASSOC);

    }else{

        // récupérer la derniere session faite
        $query = "SELECT nomMesure, dateMesure, czMesure, cxMesure, rhoMesure, sMesure, fMesure, photoMesure, videoMesure, idsession FROM sessionmesure ORDER BY dateMesure DESC LIMIT 1";
        $stmt = $db->prepare($query);
        $stmt->execute();
        $result = $stmt->fetch(PDO::FETCH_ASSOC);
        $id_mesure = $result['idsession'];
    
        $query = "SELECT portanceMesure, traineeMesure, vitesseMesure, idmesure FROM mesure WHERE idSession = {$result['idsession']} ORDER BY idMesure";
        $stmt = $db->prepare($query);
        $stmt->execute();
        $result1 = $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

        foreach ($result1 as $row) {
            $portanceValeurs[] = $row['portanceMesure'];
            $traineeValeurs[] = $row['traineeMesure'];
            $vitesseValeurs[] = $row['vitesseMesure'];
        }
        $frequencemesure = $result['fMesure'];


        ?>

<div id="container">
        <div id="picture" class="bouton">
        </div>
    <?php
        echo "<div id='result' class='whitetext'>";
            echo 'Nombre de valeurs portance : '.count($portanceValeurs) . '<br>';
            echo  'Nombre de valeurs trainée : '.count($traineeValeurs) . '<br>';
            echo  'Nombre de valeurs vitesse : '.count($vitesseValeurs) . '<br>';
    ?>

            <canvas id="graph"></canvas>
<script>
     afficherGraphique(<?php echo json_encode($portanceValeurs); ?>, <?php echo json_encode($traineeValeurs); ?>, <?php echo json_encode($vitesseValeurs); ?>,<?php echo $frequencemesure; ?>);
</script>
        
    <div class='whitetext'>
        <?php
            echo 'Date : ' . $result['dateMesure'] . '<br>';
            echo'Frequence mesure : ' . $result['fMesure'] .'<br>';
            echo 'Cz : ' . $result['czMesure'] . '<br>';
            echo 'Cx : ' . $result['cxMesure'] . '<br>';
            echo 'S : ' . $result['sMesure'] . '<br>';
            echo 'Rho : ' . $result['rhoMesure'] . '<br>';
        ?>
    </div>
</div>

<div id="change" class="bouton">
    <form class= "buttonfoot" method="post" action="">
        <input type="text" id="nouveaunom">
        <button class='button' onclick="renameSession('<?php echo $id_mesure; ?>')">Renommer la session</button>
    </form>

    <form class="buttonfoot" method="post" action="">
                <input type="hidden" name="mesureasupprimer" value="<?php echo $id_mesure; ?>">
                <input type="hidden" name="photoasupprimer" value="<?php echo $result['photoMesure']; ?>">
                <input type="hidden" name="videoasupprimer" value="<?php echo $result['videoMesure']; ?>">
                <input class ="button" type="submit" name="supprimer" value=" Supprimer la session" onclick="Delete()">
    </form>


    <?php
            if(!is_null($result['photoMesure'])){
                if($result['photoMesure'] != "NULL"){

        ?>
        <form class= "buttonfoot" method="post" action="photos.php">
            <input type="hidden" name="id_mesure" value="<?php echo $id_mesure; ?>">
            <input class="button" type="submit" value="Photos de la session">
        </form>
        <?php
                }
            }
        ?>

    <?php
             
             if(!is_null($result['videoMesure'])){
             $imgDir = scandir("./VIDEO/" . $result['videoMesure']);


                foreach($imgDir as $fichier)
                {
    
                    if($fichier != "." && $fichier != "..")
                    {
                        echo "<div class='resultimg2'>";
                        echo "<a href='./VIDEO/" . $result['videoMesure'] . "/" . $fichier . "'><button class='accueil'>Télécharger la vidéo </button></a>";
                        echo "</div>";
                        
                    }
                }
             }       
        ?>
    
    </div>
    </div>
        <script>

    function Delete()
        {
        alert("La mesure vient d'être supprimé !");
        }
        </script>
</div>
</body> 
</html> 