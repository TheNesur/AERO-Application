<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Eolia - Connexion</title>
</head>
<body>
<?php
	session_start();
	$login = $_POST['login'];
	$password = $_POST['password'];
	if($login == 'admin' && $password == 'admin') {
		$_SESSION['login'] = $login;
		header('Location: Configuration.php');
	} else {
		echo "<h2>Identifiants incorrects, veuillez réessayer</h2>";
		echo "<a href='Configuration.php'>Retour</a>";
	}
?>
</body>
</html>