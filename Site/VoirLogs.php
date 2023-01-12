<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link rel="stylesheet" href="style.css">
	<title>Eolia - Logs</title>
</head>
<body>
<h1 id="title2">Eolia - Logs</h1>
    <nav id="accueil">
        <a href="index.html"><button id="accueil">Accueil</button></a>
    </nav>
	<?php

	$LogsDir = scandir("./logs");
	echo '<form action="VoirLogs.php" method="get">';
	echo "<select name='logs'>";
	foreach($LogsDir as $fichier){
		if($fichier != "." && $fichier != "..")
		echo "<option value='" . $fichier . "'>" . $fichier . "</option>";
	}
	echo "<input type='submit' value='Visualiser logs'><br><br>";



	if (isset($_GET['logs'])) {
		
		$fichierdeLogs = "logs/". $_GET['logs'];
		if(file_exists($fichierdeLogs)){
			$content = file_get_contents($fichierdeLogs);
			echo "<textarea>$content</textarea>";
		}
	}else{
		echo "<textarea>Selectionner un fichier a visualiser</textarea>";
	}



	?>
</body>
</html>