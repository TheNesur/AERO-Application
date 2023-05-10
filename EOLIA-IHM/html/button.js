function returnback() {
    window.history.back();
 }


 function renameSession(id) {
  var newSessionName = document.getElementById("nouveaunom").value;
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
      location.reload()
    }
  }
  