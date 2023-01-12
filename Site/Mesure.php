<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <title>Eolia - Mesure</title>
</head>
<body>
    <h1 id="title2">Eolia - Mesure</h1>
    <nav id="accueil">
        <a href="index.html"><button id="accueil">Accueil</button></a>
    </nav>
    <?php
// Paramètres de connexion à la base de données
$host = 'localhost';
$dbname = 'mesures';
$username = 'root';
$password = 'root';

// Connexion à la base de données
try {
    $db = new PDO("mysql:host=$host;dbname=$dbname", $username, $password);
} catch (PDOException $e) {
    echo 'Echec de la connexion : ' . $e->getMessage();
    exit;
}

// Requête SQL pour récupérer tous les champs "nom" de la table "mesures"
$query = 'SELECT idmesure,nom FROM mesure';

// Exécution de la requête et récupération des résultats
$stmt = $db->query($query);
$results = $stmt->fetchAll(PDO::FETCH_ASSOC);

// Affichage des résultats dans une liste déroulante (combobox)
echo '<br>';
echo '<form method="post">';
echo '<select name="nom_mesure">';
foreach ($results as $row) {
    $selected = "";
    if(isset($_POST['nom_mesure']) && $_POST['nom_mesure'] == $row['nom']){
        $selected = "selected";
    }
    echo '<option value="' . $row['idmesure'] . '" '.$selected.'>' . $row['nom'] . '</option>';
}
echo '</select>';
echo '<input type="submit" value="Valider">';
echo '</form>';


if (isset($_POST['nom_mesure'])) {
    $nom_mesure = $_POST['nom_mesure']; // Récupération de la valeur choisie dans la combobox

    // Requête SQL préparée pour récupérer les champs "portance" et "trainée" de la table "mesure" où le champ "nom" est égal à la valeur choisie dans la combobox
    $query = "SELECT portance, trainee, date, vitesse, cz, cx, repertoirephoto FROM mesure WHERE idmesure = $nom_mesure";
    
    $stmt = $db->prepare($query);
    $stmt->bindParam(':nom_mesure', $nom_mesure);
    $stmt->execute();
    $result = $stmt->fetch(PDO::FETCH_ASSOC);

    // Affichage des résultats
    echo 'Portance : ' . $result['portance'] . '<br>';
    echo 'Trainée : ' . $result['trainee'] . '<br>';
    echo 'Date : ' . $result['date'] . '<br>';
    echo 'Vitesse : ' . $result['vitesse'] . ' km/h' . '<br>';
    echo 'Cz : ' . $result['cz'] . '<br>';
    echo 'Cx : ' . $result['cx'] . '<br>';
    echo 'Repertoirephoto : ' . $result['repertoirephoto'] ;
    echo '<br>';
    $imgDir = scandir("./img/" . $result['repertoirephoto']);
    foreach($imgDir as $fichier){
        if($fichier != "." && $fichier != ".."){
        echo "<img width='200' height='200'  src='./img/" . $result['repertoirephoto'] . "/" . $fichier . "'></br>";
          
            if(strpos($fichier, "PORTANCE") !== false) {
                $valeur = preg_split('/ /', $fichier);
                        echo "Valeur de Portance: " . $valeur[1] . "<br>";
                        echo "Valeur de Trainée: " . $valeur[3] . "<br>";
            }
        }
    }
}
?>
</body>
</html>