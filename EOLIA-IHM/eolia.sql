-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Ven 03 Mars 2023 à 08:46
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `eolia`
--

-- --------------------------------------------------------

--
-- Structure de la table `mesure`
--

CREATE TABLE `mesure` (
  `idMesure` int(11) NOT NULL,
  `portanceMesure` int(11) NOT NULL,
  `vitesseMesure` float NOT NULL,
  `traineeMesure` float NOT NULL,
  `idSession` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `sessionmesure`
--

CREATE TABLE `sessionmesure` (
  `idSession` int(11) NOT NULL,
  `nomMesure` text NOT NULL,
  `dateMesure` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `czMesure` float DEFAULT NULL,
  `cxMesure` float DEFAULT NULL,
  `rhoMesure` float DEFAULT NULL,
  `sMesure` float DEFAULT NULL,
  `fMesure` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `mesure`
--
ALTER TABLE `mesure`
  ADD PRIMARY KEY (`idMesure`);

--
-- Index pour la table `sessionmesure`
--
ALTER TABLE `sessionmesure`
  ADD PRIMARY KEY (`idSession`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `mesure`
--
ALTER TABLE `mesure`
  MODIFY `idMesure` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `sessionmesure`
--
ALTER TABLE `sessionmesure`
  MODIFY `idSession` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
