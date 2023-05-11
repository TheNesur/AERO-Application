
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
        <a href="index.html"><button class='button'>Accueil</button></a>
        <a href="VoirLogs.php"><button class="button">Logs</button></a>
        <?php
            		session_start();
                if(isset($_SESSION['login'])) {
                    echo "<a href='logout.php'><button class='button'>Se deconnecter</button></a>";
                }else{
                  echo "<a href='connexion.php'><button class='button'>Se connecter</button></a>";
                }
 ?>
    </nav>
    <br><br>
    <div id="configcontent">
    
        <?php
// Chemin absolu vers le fichier de configuration
$config_file = "/Eolia-IHM/config/EoliaConfig.conf";

// Verifier si le formulaire a ete soumis
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
  // Ouvrir le fichier de configuration en ecriture
if (!file_exists($config_file)) {
    die("Le fichier $file_path n'existe pas.");
}

$xml_string = file_get_contents($config_file);

if ($xml_string === false) {
    die("Impossible de lire le contenu du fichier XML.");
}
libxml_use_internal_errors(true);
$config = simplexml_load_string($xml_string);

if ($config === false) {
    $errors = libxml_get_errors();
    echo 'Errors are '.var_export($errors, true);
    throw new \Exception('invalid XML');
    die("Impossible de charger le fichier XML.");
}

  foreach ($_POST as $key => $value) {
    // Mettre a jour la valeur de chaque champ
        $setting = $config->appSettings->xpath("add[@key='$key']")[0];
        $setting['value'] = $value;
  }
  $config->asXML($config_file);
}

// Charger le fichier de configuration

if (!file_exists($config_file)) {
    die("Le fichier $file_path n'existe pas.");
}

$xml_string = file_get_contents($config_file);

if ($xml_string === false) {
    die("Impossible de lire le contenu du fichier XML.");
}
libxml_use_internal_errors(true);
$config = simplexml_load_string($xml_string);

if ($config === false) {
    $errors = libxml_get_errors();
    echo 'Errors are '.var_export($errors, true);
    throw new \Exception('invalid XML');
    die("Impossible de charger le fichier XML.");
}




?>
 <h1>Modifier la configuration</h1>
 <?php
            		session_start();
                if(isset($_SESSION['login'])) {
                    
 ?>
  <form id="formconfig" method="POST">
    <?php foreach ($config->appSettings->add as $setting): ?>
      <div>
        <label for="<?php echo $setting['key']; ?>"><?php echo $setting['key']; ?>:</label>
        <input type="text" id="<?php echo $setting['key']; ?>" name="<?php echo $setting['key']; ?>" value="<?php echo $setting['value']; ?>"><br>
      </div>
    <?php endforeach; ?>
    <button class="accueil" type="submit">Enregistrer</button>
  </form>
  <?php
        }else{
          echo "<h2>Priere de vous connecter</h2>";
      }
  ?>

    </div>
</body>
</html>