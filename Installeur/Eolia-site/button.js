function returnback() {
    window.history.back();
 }


 function renameSession(id) {
    var newSessionName = prompt("Entrez un nouveau nom de session : ");
    if (newSessionName != null) {
      var xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
          console.log(this.responseText);
        }
      };
      xhttp.open("POST", "Mesure.php", true);
      xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
      xhttp.send("nouveau_nom=" + newSessionName + "&mesureamodifier=" + id);
      alert("La mesure " + id + " a été renommé par " + newSessionName);
      location.reload()
    }
  }
  