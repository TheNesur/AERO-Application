<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Connexion</title>
</head>
<body>
<?php
    $host = '172.17.4.187';
    $dbname = 'EoliaBDD';
    $username = 'eolia';
    $password = 'eoliaPWD';


    try {
        $db = new PDO("mysql:host=$host;dbname=$dbname", $username, $password);
    } catch (PDOException $e) {
        echo 'Echec de la connexion : ' . $e->getMessage();
        exit;
    }
?>
</body>
</html>