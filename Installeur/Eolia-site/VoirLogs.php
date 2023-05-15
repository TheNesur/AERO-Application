<!DOCTYPE html>
<html lang="fr">
<head>
	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link rel="stylesheet" href="style.css">
	<link rel="shortcut icon" href="favicon.ico"/>
	<script src="button.js"></script>
	<title>Eolia - Logs</title>
</head>
<body>
<h1 class='title2'>Eolia - Logs</h1>
    <nav class='redir'>
        <a href="index.html"><button class='accueil'>Accueil</button></a>
		<button class='accueil' onclick="returnback()">Retour</button>
    </nav>
	<?php
	echo '<br>';
	$LogsDir = scandir("./logs");
	echo '<form id="choix" action="VoirLogs.php" method="get">';
	echo "<select class ='logsstyle' name='logs'>";
	foreach($LogsDir as $fichier){
		if($fichier != "." && $fichier != "..")
		echo "<option value='" . $fichier . "'";
		if(isset($_GET['logs']) && $_GET['logs'] == $fichier) {
			echo " selected";
		}
		echo ">" . $fichier . "</option>";
	}
	echo "<input class ='logsstyle' type='submit' value='Valider' ><br><br>";

	if (isset($_GET['logs'])) {
		$fichierdeLogs = "logs/". $_GET['logs'];
		if(file_exists($fichierdeLogs)){
			$content = file_get_contents($fichierdeLogs);
			echo "<textarea>$content</textarea>";
		}
	}else{
		echo "<textarea>Sélectionner un fichier à visualiser</textarea>";
	}
?>
</body>
</html>