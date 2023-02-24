-- phpMyAdmin SQL Dump
-- version 5.1.1deb5ubuntu1
-- https://www.phpmyadmin.net/
--
-- Värd: localhost:3306
-- Tid vid skapande: 10 feb 2023 kl 10:44
-- Serverversion: 10.6.11-MariaDB-0ubuntu0.22.04.1
-- PHP-version: 8.1.2-1ubuntu2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `mvcexempel`
--
CREATE DATABASE IF NOT EXISTS `mvcexempel` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `mvcexempel`;

DELIMITER $$
--
-- Procedurer
--
DROP PROCEDURE IF EXISTS `samman`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `samman` (IN `abc` VARCHAR(50), IN `def` VARCHAR(50))  SELECT Concat( abc,def)$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tabellstruktur `Employee`
--

DROP TABLE IF EXISTS `Employee`;
CREATE TABLE IF NOT EXISTS `Employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `namn` varchar(255) NOT NULL,
  `mailadress` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `roll` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabellstruktur `Kund`
--

DROP TABLE IF EXISTS `Kund`;
CREATE TABLE IF NOT EXISTS `Kund` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `realname` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `age` int(11) NOT NULL,
  `password` varchar(255) NOT NULL,
  `language` varchar(5) NOT NULL,
  `credit` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumpning av Data i tabell `Kund`
--

INSERT INTO `Kund` (`id`, `realname`, `username`, `age`, `password`, `language`, `credit`) VALUES
(1, 'Ralf Hintz', 'hinra', 54, 'nosecretshit', 'de', 1000),
(2, 'Elon Musk', 'elony', 51, 'teslaisdashit', 'en', 1000000),
(3, 'Kalle Anka', 'ankka', 3, 'quackquack', 'anka', 0);

-- --------------------------------------------------------

--
-- Tabellstruktur `Orders`
--

DROP TABLE IF EXISTS `Orders`;
CREATE TABLE IF NOT EXISTS `Orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderDatum` datetime NOT NULL,
  `kundID` int(11) NOT NULL,
  `orderStatus` varchar(255) NOT NULL,
  `inkopsLista` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumpning av Data i tabell `Orders`
--

INSERT INTO `Orders` (`id`, `orderDatum`, `kundID`, `orderStatus`, `inkopsLista`) VALUES
(1, '2023-02-03 09:06:28', 3, 'plockas', '2,3,1'),
(2, '2022-02-09 09:06:28', 1, 'registrerad', '2,2,4');

-- --------------------------------------------------------

--
-- Tabellstruktur `Produkt`
--

DROP TABLE IF EXISTS `Produkt`;
CREATE TABLE IF NOT EXISTS `Produkt` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `produktnamn` varchar(255) NOT NULL,
  `tillverkare` varchar(255) NOT NULL,
  `pris` double NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumpning av Data i tabell `Produkt`
--

INSERT INTO `Produkt` (`id`, `produktnamn`, `tillverkare`, `pris`) VALUES
(1, '3090 GTX', 'Nvidia', 4989),
(2, 'Ryzen 7000x- 3.8GHz', 'AMD', 3599),
(3, 'Intel I7-10F300DA', 'Intel', 2689),
(4, 'DDRAM4 320Mhx 8GB', 'Kingston', 799);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
