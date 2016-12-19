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
-- Table structure for table `vehiclemake`
--

DROP TABLE IF EXISTS `vehiclemake`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehiclemake` (
  `MakeID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Unique number for vehicle brand',
  `MakeName` varchar(100) DEFAULT NULL COMMENT 'Name of the vehicle brand',
  `Description` varchar(750) DEFAULT NULL COMMENT 'Description for the vehicle brand',
  PRIMARY KEY (`MakeID`)
) ENGINE=MyISAM AUTO_INCREMENT=46 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehiclemake`
--

LOCK TABLES `vehiclemake` WRITE;
/*!40000 ALTER TABLE `vehiclemake` DISABLE KEYS */;
INSERT INTO `vehiclemake` VALUES (1,'Alfa Romeo',''),(2,'Audi',''),(3,'Austin',''),(4,'BMW',''),(5,'Bajaj',''),(6,'Benz',''),(7,'CAL',''),(8,'Ceygra',''),(9,'Crysler',''),(10,'Daewoo',''),(11,'Daihatsu',''),(12,'Ducati',''),(13,'Electra',''),(14,'Fiat',''),(15,'Ford',''),(16,'Hero Honda',''),(17,'Honda',''),(18,'Honda',''),(19,'Hyundai',''),(20,'Isuzu',''),(21,'Kawasaki',''),(22,'Kia',''),(23,'Kinetic',''),(24,'Maruti',''),(25,'Mazda',''),(26,'Micro',''),(27,'Mitsubishi',''),(28,'Nissan',''),(29,'Perodua',''),(30,'Proton',''),(31,'Ssangyong',''),(32,'Suzuki',''),(33,'Suzuki',''),(34,'TVS',''),(35,'Toyota',''),(36,'Volkswagen',''),(37,'Yamaha',''),(38,'Tata',''),(39,'Land Rover',NULL),(40,'Leyland',NULL),(41,'Chevrolet',NULL),(42,'Peugeot',NULL),(43,'Others',NULL),(44,'Chery',NULL),(45,'SUBARU',NULL);
/*!40000 ALTER TABLE `vehiclemake` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:32
