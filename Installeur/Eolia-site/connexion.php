<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Eolia - Connexion</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<h1 class='title2'>Eolia - Connexion</h1>
<nav class='redir'>
        <a href="index.html"><button class='accueil'>Accueil</button></a>
</nav>
    <br><br>
<div id='connexion'>
<?php
session_start();
require 'connexionbdd.php';

if(isset($_POST['username']) && isset($_POST['password'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];

    $query = ("SELECT * FROM admin WHERE username = '$username' AND password = '".mysqli_real_escape_string($password)."'");
	$stmt = $db->prepare($query);
	$stmt->execute();
	$requete = $stmt->fetch(PDO::FETCH_ASSOC);
    
    if($requete) {
        $_SESSION['login'] = $username;
        header('Location: Configuration.php');
		echo "Connexion ok";

    }
    else {
        echo "<p class='error-message'>Nom d'utilisateur ou mot de passe incorrect</p>";
    }
}
?>
<form method="post" action="connexion.php">
    <label for="username" id="ident">Nom d'utilisateur :</label>
    <input type="text" id="username" name="username" required><br><br>
    
    <label for="password" id="ident2">Mot de passe :</label>
    <input type="password" id="password" name="password" required><br><br>
    
    <input type="submit" id="inputco" value="Se connecter">
</form>
</div>
</body>
</html>
