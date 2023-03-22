#!/bin/bash

if [ $# -eq 0 ]; then
  echo "Veuillez fournir le nom du dossier à supprimer en argument."
  exit 1
fi

if [ ! -d "$1" ]; then
  echo "$1 n'est pas un dossier valide."
  exit 1
fi

echo "Suppression du dossier $1 et de tous ses fichiers..."

rm -rf "$1"

echo "Le dossier $1 a été supprimé avec succès."
