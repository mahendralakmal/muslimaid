-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: muslimaid
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.13-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `due_history`
--

DROP TABLE IF EXISTS `due_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `due_history` (
  `id_due_history` int(11) NOT NULL AUTO_INCREMENT,
  `update_date` varchar(45) DEFAULT NULL,
  `cf` decimal(12,2) DEFAULT NULL,
  `rbf` decimal(12,2) DEFAULT NULL,
  `prbf` decimal(12,2) DEFAULT NULL,
  `micro` decimal(12,2) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `rbf_so` decimal(12,2) DEFAULT NULL,
  `rbf_be` decimal(12,2) DEFAULT NULL,
  `rbf_tm` decimal(12,2) DEFAULT NULL,
  `rbf_co` decimal(12,2) DEFAULT NULL,
  `rbf_nr` decimal(12,2) DEFAULT NULL,
  `rbf_rp` decimal(12,2) DEFAULT NULL,
  `prbf_so` decimal(12,2) DEFAULT NULL,
  `prbf_be` decimal(12,2) DEFAULT NULL,
  `prbf_tm` decimal(12,2) DEFAULT NULL,
  `prbf_co` decimal(12,2) DEFAULT NULL,
  `micro_so` decimal(12,2) DEFAULT NULL,
  `micro_tm` decimal(12,2) DEFAULT NULL,
  `micro_be` decimal(12,2) DEFAULT NULL,
  `micro_co` decimal(12,2) DEFAULT NULL,
  `micro_rp` decimal(12,2) DEFAULT NULL,
  `micro_nr` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`id_due_history`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `due_history`
--

LOCK TABLES `due_history` WRITE;
/*!40000 ALTER TABLE `due_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `due_history` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:29
