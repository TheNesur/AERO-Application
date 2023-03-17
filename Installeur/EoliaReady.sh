#!/bin/sh
 
read -p "Que voulez vous installer (SITE|LOGICIEL|LAMP|CONFIGECRAN|CONFIGBDD|CONFIGSERIE|TOUT) :   " answer

	echo  "\n Mis a jour des paquets\n"

	sudo apt-get update -y && sudo apt-get upgrade -y

if [ "$answer" = "LOGICIEL" ] || [ "$answer" = "TOUT" ]; then
	
	echo  "\n Installation de mono\n"
	
	sudo apt-get install mono-complete mono-devel
	
	cp Eolia-IHM / -r
	chmod a+rwx /Eolia-IHM/config/EoliaConfig.conf
	
	if grep -q "eolia-launch" /home/$SUDO_USER/.bashrc; then
		echo "alias existant\n"
	else
		echo "alias eolia-launch='sudo mono /Eolia-IHM/Eolia-IHM.exe'" >> /home/$SUDO_USER/.bashrc
		echo "Alias créée : 'eolia-launch'"
		
	fi

	 if grep -q "[Desktop" /home/$SUDO_USER/Desktop/Eolia.desktop; then
		echo "Raccourci déja existant"
	else
		echo "Raccourci créé"
		echo "[Desktop Entry]\nName=Eolia\nExec=sudo mono /Eolia-IHM/Eolia-IHM.exe\nTerminal=true\nType=Application" >> /home/$SUDO_USER/Desktop/Eolia.desktop
		chmod a+rwx /home/$SUDO_USER/Desktop/Eolia.desktop
	fi
fi

if [ "$answer" = "TOUT" ] || [ "$answer" = "CONFIGECRAN" ]; then

	if grep -q "hdmi_cvt 1024" /boot/config.txt; then

		echo "\n Ecran deja configuré \n"

	else
		echo "\n Configuration de l'écran\n"
		tail configscreen.txt >> /boot/config.txt	

	fi
fi

if [ "$answer" = "TOUT" ] || [ "$answer" = "LAMP" ]; then



	echo  "\n Installation da la pile LAMP\n"

	sudo apt-get install apache2 apache2-doc php php-mysql libapache2-mod-php mariadb-server 



	if [ -x "($command -v apache2)" ];
	then
		echo "\n Apache non installé ....\n"
		exit 1
	else
		echo "\n Apache bien installé ....\n"
	fi
fi

if [ "$answer" = "TOUT" ] || [ "$answer" = "CONFIGBDD" ]; then

	echo  "\n Mise en place de la BDD\n"

	mysql -e "UPDATE mysql.user SET Password = PASSWORD('rootEolia2023') WHERE User = 'root'"

	mysql -e "CREATE USER IF NOT EXISTS 'eolia'@'localhost' IDENTIFIED BY 'eoliaPWD'"
	mysql -e "CREATE USER IF NOT EXISTS 'eolia'@'%' IDENTIFIED BY 'eoliaPWD'"

	mysql -e "CREATE DATABASE IF NOT EXISTS EoliaBDD"

	mysql  EoliaBDD < Eolia.sql

	mysql -e  "GRANT ALL PRIVILEGES ON EoliaBDD.* to 'eolia'@'%'"
	mysql -e  "GRANT ALL PRIVILEGES ON EoliaBDD.* to 'eolia'@'localhost'"

	mysql -e "FLUSH PRIVILEGES"
	
	sudo sed -i '/bind-address/s/^/#/' /etc/mysql/mariadb.conf.d/50-server.cnf
fi

if [ "$answer" = "SITE" ] || [ "$answer" = "TOUT" ]; then
	cp Eolia-site/* /var/www/html/ -r
fi

if [ "$answer" = "TOUT" ] || [ "$answer" = "CONFIGSERIE" ]; then
	echo  "\nChangement permissions port séries\n"

	sudo usermod -a -G dialout $USER

	echo  "\n"$USER" est désormais l'utilisateur avec le quel il audra lancer Eolia"
fi
