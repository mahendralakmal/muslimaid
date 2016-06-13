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
-- Table structure for table `center_details`
--

DROP TABLE IF EXISTS `center_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `center_details` (
  `auto_id` int(11) NOT NULL AUTO_INCREMENT,
  `idcenter_details` int(11) DEFAULT NULL,
  `center_name` varchar(45) DEFAULT NULL,
  `city_code` varchar(10) DEFAULT NULL,
  `villages` varchar(45) DEFAULT NULL,
  `leader_name` varchar(100) DEFAULT NULL,
  `conta_no` varchar(10) DEFAULT NULL,
  `create_userID` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  `center_day` varchar(10) DEFAULT NULL,
  `Latitude` varchar(45) NOT NULL DEFAULT '0.00000000',
  `Longitude` varchar(45) NOT NULL DEFAULT '0.00000000',
  `exective` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`auto_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `center_details`
--

LOCK TABLES `center_details` WRITE;
/*!40000 ALTER TABLE `center_details` DISABLE KEYS */;
INSERT INTO `center_details` VALUES (1,1,'Palliyawatta','CO','Wijerama','Niranjala Dilrukshi','0715200200','123456789V','123.231.124.4','2016-04-18 12:23:51','FR','0.00000000','0.00000000','01'),(2,2,'Arangala','CO','Wijerama','K.A.A. Kumara','0113047022','123456789V','123.231.124.4','2016-04-18 12:42:57','TU','6.91423','79.851164','01'),(3,3,'Madapatha','CO','Wijerama','Chandraleka','0715871942','123456789V','123.231.124.4','2016-04-20 10:48:51','FR','0.00000000','0.00000000','01'),(4,4,'Thekotuwa','CO','Wijerama','Nandani','0728533969','123456789V','123.231.124.4','2016-04-26 10:10:23','TH','0.00000000','0.00000000','01'),(5,5,'Nugegoda','CO','Akarawita','Nimesha Dheepthi','0716511847','902554203V','127.0.0.1','2016-05-04 16:41:21','MO','0.00000000','0.00000000','01'),(8,6,'Kesbewa','CO','Wijerama','Priyanthika','0755082971','123456789V','123.231.124.4','2016-05-05 16:32:03','WE','0.00000000','0.00000000','02'),(9,1,'Thalapathpitiya - South','PL','Nugegoda','Bethmage Niluka Dilrukshi Perera','0711111111','123456789V','123.231.124.4','2016-05-10 10:33:16','WE','0.00000000','0.00000000','01'),(10,2,'Sayuru','PL','Moratuwa','Gayani Niluka','0771594576','123456789V','123.231.124.4','2016-05-11 10:06:04','TU','0.00000000','0.00000000','02'),(11,3,'Sayuri','PL','Moratuwa','Gayani Niluka','0771594576','123456789V','123.231.124.4','2016-05-11 10:12:15','TU','0.00000000','0.00000000','02'),(12,4,'Sayuruu','PL','Moratuwa','G. Niluka','0777444555','123456789V','123.231.124.4','2016-05-11 10:15:28','TU','0.00000000','0.00000000','02'),(13,1,'Sandasiripura','KD','Kaduwela - Sandasiripura','Priyanka Niroshani Jayasooriya','0773826372','123456789V','123.231.124.4','2016-05-19 11:53:36','FR','Kaduwela ','Kaduwela','01'),(14,2,'Yakala','KD','Yakala','N.K.G. Sureni Bhagya Rathnayake','0773458000','123456789V','123.231.124.4','2016-05-20 13:48:34','MO','Kaduwela ','Kaduwela','01'),(15,3,'Nelum Pedesa','KD','Nelum Pedesa','H. Priyadfarshani','0726487607','123456789V','123.231.124.4','2016-05-23 16:02:21','TU','Kaduwela ','Kaduwela','02'),(16,5,'Palliyawatta','PL','Madapatha','Niranjala Dilrukshi','0715693222','123456789V','123.231.124.4','2016-05-27 14:16:37','FR','0.00','0.00','03'),(17,4,'Yakala','KD','Kaduwela','N.K.G. Sureni Bhagya Rathnayake','0773458000','123456789V','123.231.124.4','2016-05-27 14:33:02','MO','0.00','0.00','01'),(18,5,'Arangala','KD','Arangala','K.A.Ajantha Perera','0113047022','123456789V','123.231.124.4','2016-06-02 09:21:00','TU','6.8865162','79.9595401','04'),(19,6,'Shanthalokagama','KD','Athurugiriya','N.Shahara Yahiya','0717412118','123456789V','123.231.124.4','2016-06-02 09:47:06','TH','6.9220035','79.9704531','06'),(20,7,'Sethsirigama','KD','Akarawita','N.S.Jayasinghe','0712479876','123456789V','123.231.124.4','2016-06-03 08:47:53','TH','6.8913839','79.9858804','01'),(21,8,'Sethsirigama','KD','Athurugiriya','N.S.Jayasinghe','0712489633','123456789V','123.231.124.4','2016-06-03 08:50:02','TH','6.8913839','79.9858804','01'),(22,6,'Sayuru','PL','Molpe','M. Gayani Niluka Fernando','0771594576','123456789V','123.231.124.4','2016-06-03 11:53:51','TU','6.7923502','79.8964345','02'),(23,7,'Sudarshi','PL','Sudarshi - Polgaovita','Polwattage Chandrani Gomes','0713048573','123456789V','123.231.124.4','2016-06-06 08:54:26','TH','6.7932951','79.9476237','02'),(24,9,'Walgama','KD','Walgama','Kalupathirannehelage Pathma Malkanthi','0772943494','123456789V','123.231.124.4','2016-06-06 14:27:51','TU','6.8648314','79.9937622','01'),(25,1,'Kahatapitiya','AV','Kahatapitiya','Wiyalagodage Sujeewa Wiyalagoda','0716291922','123456789V','123.231.124.4','2016-06-07 09:30:24','TU','7.396672,7','8736446,17','01');
/*!40000 ALTER TABLE `center_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-13 19:39:05
