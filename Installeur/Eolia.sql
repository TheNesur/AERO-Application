-- Adminer 4.8.1 MySQL 5.5.5-10.3.38-MariaDB-0+deb10u1 dump

SET NAMES utf8;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET sql_mode = 'NO_AUTO_VALUE_ON_ZERO';

SET NAMES utf8mb4;

CREATE DATABASE IF NOT EXISTS `EoliaBDD` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `EoliaBDD`;

DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

INSERT INTO `admin` (`id`, `username`, `password`) VALUES
(1,	'Eoliadmin',	'PWDEolia');

DROP TABLE IF EXISTS `mesure`;
CREATE TABLE `mesure` (
  `idMesure` int(11) NOT NULL AUTO_INCREMENT,
  `portanceMesure` float NOT NULL,
  `traineeMesure` float NOT NULL,
  `vitesseMesure` float NOT NULL,
  `idSession` int(11) NOT NULL,
  PRIMARY KEY (`idMesure`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `mesure` (`idMesure`, `portanceMesure`, `traineeMesure`, `vitesseMesure`, `idSession`) VALUES
(178,	0,	0.9,	11.8277,	16),
(179,	0.3,	2,	11.8269,	16),
(180,	0.1,	0.6,	11.8284,	16),
(181,	658.2,	1,	11.8269,	16),
(182,	826.1,	2.1,	11.8269,	16),
(183,	818.9,	1.6,	11.8277,	16),
(184,	568.4,	0.6,	11.8288,	16),
(185,	1.8,	2.4,	11.8273,	16),
(16092,	22.9,	0.2,	0,	37),
(16093,	22.8,	0.1,	0,	37),
(16094,	22.9,	0.2,	0,	37),
(16095,	22.8,	0.2,	0,	37),
(16096,	24.5,	0.1,	0,	38),
(16097,	24.4,	0.2,	0,	38),
(16098,	24.4,	0,	0,	38),
(16099,	24.5,	0.1,	0,	38),
(16100,	24.4,	0.1,	0,	38),
(16101,	24.6,	0.3,	0,	38),
(16102,	0,	0.1,	0,	39),
(16103,	0,	0,	1,	39),
(16104,	0,	0,	2,	39),
(16105,	0.4,	0.2,	3,	39),
(16106,	395.6,	14.9,	4,	39),
(16107,	725.3,	26.6,	5,	39),
(16108,	759.9,	66.8,	6,	39),
(16109,	740.6,	211.8,	7,	39),
(16110,	871.1,	513.1,	0,	39),
(16111,	726,	532.4,	0,	39),
(16112,	878.8,	517,	0,	39),
(16113,	802.2,	459.4,	0,	39),
(16114,	922.7,	556.4,	0,	39),
(16115,	1006.4,	373.3,	0,	39),
(16116,	1082.2,	577.4,	0,	39),
(16117,	1098.3,	525.4,	0,	39),
(16118,	1224.3,	629.4,	0,	39),
(16119,	1342.1,	770.7,	0,	39),
(16120,	1456.3,	767.2,	0,	39),
(16121,	1508.6,	776.7,	0,	39),
(16122,	1479.4,	624.7,	0,	39),
(16123,	1532.8,	685.5,	0,	39),
(16124,	1465.4,	533.2,	0,	39),
(16125,	1498.2,	411.8,	0,	39),
(16126,	1520.1,	428,	0,	39),
(16127,	1510.8,	435.7,	0,	39),
(16128,	1465.5,	400.5,	0,	39),
(16129,	1154.5,	288.8,	0,	39),
(16130,	932.5,	250,	0,	39),
(16131,	937.6,	130.4,	0,	39),
(16132,	698.7,	126.4,	0,	39),
(16133,	635.8,	39,	0,	39),
(16134,	454.8,	34.5,	0,	39),
(16135,	2.7,	0,	0,	39),
(16136,	2.5,	0.1,	0,	39),
(16137,	2.6,	0.2,	0,	39),
(16138,	2.6,	0.1,	0,	39),
(16139,	2.5,	0.1,	0,	39);

DROP TABLE IF EXISTS `sessionmesure`;
CREATE TABLE `sessionmesure` (
  `idSession` int(11) NOT NULL AUTO_INCREMENT,
  `nomMesure` text NOT NULL,
  `dateMesure` timestamp NOT NULL DEFAULT current_timestamp(),
  `czMesure` float DEFAULT NULL,
  `cxMesure` float DEFAULT NULL,
  `rhoMesure` float DEFAULT NULL,
  `sMesure` float DEFAULT NULL,
  `photoMesure` text DEFAULT NULL,
  `videoMesure` text DEFAULT NULL,
  `fMesure` float NOT NULL,
  PRIMARY KEY (`idSession`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `sessionmesure` (`idSession`, `nomMesure`, `dateMesure`, `czMesure`, `cxMesure`, `rhoMesure`, `sMesure`, `photoMesure`, `videoMesure`, `fMesure`) VALUES
(16,	'new',	'2023-03-28 12:20:07',	1,	1,	1,	1,	'NULL',	'NULL',	0.25),
(37,	'13/04/2023_14:06:05',	'2023-04-13 12:06:11',	1,	1,	1,	1,	'13042023_140605',	'NULL',	0.1),
(38,	'13/04/2023_14:24:57',	'2023-04-13 12:25:08',	1,	1,	1,	1,	'13042023_142457',	'NULL',	0.1),
(39,	'13/04/2023_14:33:50',	'2023-04-13 12:34:36',	1,	1,	1,	1,	'13042023_143332',	'NULL',	0.1);

-- 2023-05-11 20:44:43