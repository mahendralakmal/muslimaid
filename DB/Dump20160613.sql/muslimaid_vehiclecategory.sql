-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: muslimaid
-- ------------------------------------------------------
-- Server version	5.6.12-log

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
-- Table structure for table `vehiclecategory`
--

DROP TABLE IF EXISTS `vehiclecategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehiclecategory` (
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Unique number for category',
  `CategoryName` varchar(100) DEFAULT NULL COMMENT 'Category name',
  `Description` varchar(750) DEFAULT NULL COMMENT 'Description for the vehicle category',
  PRIMARY KEY (`CategoryID`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehiclecategory`
--

LOCK TABLES `vehiclecategory` WRITE;
/*!40000 ALTER TABLE `vehiclecategory` DISABLE KEYS */;
INSERT INTO `vehiclecategory` VALUES (1,'Car',''),(2,'Motor Bike',''),(3,'Van',''),(4,'Pick up',''),(5,'Double cab',''),(6,'SUV',''),(7,'Mini Van',''),(8,'Truck',''),(9,'Coach',''),(10,'Bus',''),(11,'Motor Lorry',''),(12,'Motor Boat',''),(13,'Cab',NULL),(14,'Three Wheeler',NULL),(15,'Jeep',NULL);
/*!40000 ALTER TABLE `vehiclecategory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-13 19:39:13
