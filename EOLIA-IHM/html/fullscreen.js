
function onClick(element) {
  document.getElementById("img01").src = element.src;
  document.getElementById("modal01").style.display = "block";
}
function cache(element){
  document.getElementById("modal01").style.display = "none";
}