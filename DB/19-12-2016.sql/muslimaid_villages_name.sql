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
-- Table structure for table `villages_name`
--

DROP TABLE IF EXISTS `villages_name`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `villages_name` (
  `idvillages_name` int(11) NOT NULL AUTO_INCREMENT,
  `city_code` varchar(45) DEFAULT NULL,
  `villages_name` varchar(45) DEFAULT NULL,
  `create_user_nic` varchar(10) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idvillages_name`)
) ENGINE=InnoDB AUTO_INCREMENT=333 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `villages_name`
--

LOCK TABLES `villages_name` WRITE;
/*!40000 ALTER TABLE `villages_name` DISABLE KEYS */;
INSERT INTO `villages_name` VALUES (1,'CO','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(2,'CO','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(3,'CO','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(4,'CO','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(5,'CO','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(6,'CO','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(7,'CO','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(8,'CO','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(9,'CO','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(10,'CO','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(11,'CO','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(12,'CO','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(13,'CO','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(14,'CO','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(15,'CO','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(16,'CO','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(17,'CO','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(18,'CO','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(19,'CO','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(20,'CO','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(21,'CO','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(22,'CO','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(23,'CO','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(24,'CO','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(25,'CO','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(26,'CO','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(27,'CO','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(28,'CO','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(29,'CO','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(30,'CO','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(31,'CO','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(32,'CO','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(33,'CO','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(34,'CO','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(35,'CO','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(36,'CO','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(37,'CO','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(38,'CO','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(39,'CO','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(40,'CO','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(41,'CO','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(42,'CO','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(43,'CO','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(44,'CO','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(45,'CO','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(46,'CO','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(47,'CO','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(48,'CO','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(49,'CO','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(50,'CO','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(51,'CO','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(52,'CO','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(53,'CO','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(54,'CO','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(55,'CO','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(56,'CO','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(57,'CO','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(58,'CO','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(59,'CO','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(60,'CO','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(61,'CO','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(62,'CO','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(63,'CO','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(64,'CO','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(65,'CO','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(66,'CO','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(67,'CO','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(68,'CO','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(69,'CO','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(70,'CO','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(71,'CO','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(72,'CO','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(73,'CO','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(74,'CO','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(75,'CO','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(76,'CO','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(77,'CO','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(78,'CO','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(79,'CO','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(80,'CO','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(81,'WP','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(82,'WP','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(83,'WP','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(84,'WP','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(85,'WP','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(86,'WP','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(87,'WP','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(88,'WP','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(89,'WP','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(90,'WP','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(91,'WP','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(92,'WP','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(93,'WP','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(94,'WP','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(95,'WP','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(96,'WP','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(97,'WP','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(98,'WP','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(99,'WP','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(100,'WP','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(101,'WP','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(102,'WP','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(103,'WP','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(104,'WP','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(105,'WP','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(106,'WP','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(107,'WP','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(108,'WP','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(109,'WP','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(110,'WP','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(111,'WP','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(112,'WP','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(113,'WP','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(114,'WP','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(115,'WP','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(116,'WP','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(117,'WP','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(118,'WP','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(119,'WP','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(120,'WP','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(121,'WP','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(122,'WP','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(123,'WP','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(124,'WP','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(125,'WP','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(126,'WP','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(127,'WP','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(128,'WP','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(129,'WP','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(130,'WP','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(131,'WP','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(132,'WP','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(133,'WP','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(134,'WP','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(135,'WP','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(136,'WP','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(137,'WP','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(138,'WP','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(139,'WP','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(140,'WP','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(141,'WP','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(142,'WP','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(143,'WP','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(144,'WP','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(145,'WP','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(146,'WP','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(147,'WP','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(148,'WP','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(149,'WP','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(150,'WP','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(151,'WP','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(152,'WP','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(153,'WP','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(154,'WP','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(155,'WP','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(156,'WP','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(157,'WP','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(158,'WP','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(159,'WP','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(160,'WP','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(161,'KD','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(162,'KD','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(163,'KD','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(164,'KD','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(165,'KD','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(166,'KD','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(167,'KD','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(168,'KD','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(169,'KD','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(170,'KD','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(171,'KD','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(172,'KD','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(173,'KD','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(174,'KD','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(175,'KD','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(176,'KD','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(177,'KD','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(178,'KD','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(179,'KD','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(180,'KD','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(181,'KD','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(182,'KD','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(183,'KD','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(184,'KD','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(185,'KD','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(186,'KD','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(187,'KD','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(188,'KD','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(189,'KD','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(190,'KD','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(191,'KD','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(192,'KD','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(193,'KD','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(194,'KD','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(195,'KD','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(196,'KD','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(197,'KD','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(198,'KD','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(199,'KD','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(200,'KD','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(201,'KD','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(202,'KD','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(203,'KD','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(204,'KD','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(205,'KD','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(206,'KD','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(207,'KD','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(208,'KD','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(209,'KD','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(210,'KD','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(211,'KD','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(212,'KD','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(213,'KD','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(214,'KD','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(215,'KD','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(216,'KD','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(217,'KD','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(218,'KD','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(219,'KD','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(220,'KD','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(221,'KD','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(222,'KD','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(223,'KD','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(224,'KD','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(225,'KD','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(226,'KD','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(227,'KD','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(228,'KD','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(229,'KD','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(230,'KD','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(231,'KD','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(232,'KD','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(233,'KD','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(234,'KD','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(235,'KD','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(236,'KD','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(237,'KD','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(238,'KD','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(239,'KD','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(240,'KD','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(241,'PL','Akarawita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(242,'PL','Angoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(243,'PL','Arangala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(244,'PL','Athurugiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(245,'PL','Avissawella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(246,'PL','Bambalapitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(247,'PL','Batawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(248,'PL','Battaramulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(249,'PL','Batugampola','123456789V','123.231.124.4','2016-04-27 10:30:54'),(250,'PL','Bope','123456789V','123.231.124.4','2016-04-27 10:30:54'),(251,'PL','Boralesgamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(252,'PL','Borella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(253,'PL','Colombo 01','123456789V','123.231.124.4','2016-04-27 10:30:54'),(254,'PL','Colombo 02','123456789V','123.231.124.4','2016-04-27 10:30:54'),(255,'PL','Colombo 03','123456789V','123.231.124.4','2016-04-27 10:30:54'),(256,'PL','Colombo 04','123456789V','123.231.124.4','2016-04-27 10:30:54'),(257,'PL','Colombo 05','123456789V','123.231.124.4','2016-04-27 10:30:54'),(258,'PL','Colombo 06','123456789V','123.231.124.4','2016-04-27 10:30:54'),(259,'PL','Colombo 07','123456789V','123.231.124.4','2016-04-27 10:30:54'),(260,'PL','Colombo 08','123456789V','123.231.124.4','2016-04-27 10:30:54'),(261,'PL','Colombo 09','123456789V','123.231.124.4','2016-04-27 10:30:54'),(262,'PL','Colombo 10','123456789V','123.231.124.4','2016-04-27 10:30:54'),(263,'PL','Colombo 11','123456789V','123.231.124.4','2016-04-27 10:30:54'),(264,'PL','Colombo 12','123456789V','123.231.124.4','2016-04-27 10:30:54'),(265,'PL','Colombo 13','123456789V','123.231.124.4','2016-04-27 10:30:54'),(266,'PL','Colombo 14','123456789V','123.231.124.4','2016-04-27 10:30:54'),(267,'PL','Colombo 15','123456789V','123.231.124.4','2016-04-27 10:30:54'),(268,'PL','Dedigamuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(269,'PL','Dehiwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(270,'PL','Deltara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(271,'PL','Embuldeniya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(272,'PL','Gongodawila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(273,'PL','Habarakada','123456789V','123.231.124.4','2016-04-27 10:30:54'),(274,'PL','Handapangoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(275,'PL','Hanwella','123456789V','123.231.124.4','2016-04-27 10:30:54'),(276,'PL','Hewainna','123456789V','123.231.124.4','2016-04-27 10:30:54'),(277,'PL','Hiripitya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(278,'PL','Hokandara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(279,'PL','Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(280,'PL','Horagala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(281,'PL','Kaduwela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(282,'PL','Kahawala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(283,'PL','Kalatuwawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(284,'PL','Kalubowila','123456789V','123.231.124.4','2016-04-27 10:30:54'),(285,'PL','Kiriwattuduwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(286,'PL','Kohuwala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(287,'PL','Kolonnawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(288,'PL','Kosgama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(289,'PL','Kotahena','123456789V','123.231.124.4','2016-04-27 10:30:54'),(290,'PL','Kotikawatta','123456789V','123.231.124.4','2016-04-27 10:30:54'),(291,'PL','Kottawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(292,'PL','Madapatha','123456789V','123.231.124.4','2016-04-27 10:30:54'),(293,'PL','Maharagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(294,'PL','Malabe','123456789V','123.231.124.4','2016-04-27 10:30:54'),(295,'PL','Meegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(296,'PL','Moratuwa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(297,'PL','Mount Lavinia','123456789V','123.231.124.4','2016-04-27 10:30:54'),(298,'PL','Mullegama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(299,'PL','Mulleriyawa','123456789V','123.231.124.4','2016-04-27 10:30:54'),(300,'PL','Mutwal','123456789V','123.231.124.4','2016-04-27 10:30:54'),(301,'PL','Napawela','123456789V','123.231.124.4','2016-04-27 10:30:54'),(302,'PL','Narahenpita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(303,'PL','Nugegoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(304,'PL','Padukka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(305,'PL','Pannipitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(306,'PL','Piliyandala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(307,'PL','Pita Kotte','123456789V','123.231.124.4','2016-04-27 10:30:54'),(308,'PL','Pitipana Homagama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(309,'PL','Polgasowita','123456789V','123.231.124.4','2016-04-27 10:30:54'),(310,'PL','Puwakpitiya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(311,'PL','Rajagiriya','123456789V','123.231.124.4','2016-04-27 10:30:54'),(312,'PL','Ranala','123456789V','123.231.124.4','2016-04-27 10:30:54'),(313,'PL','Ratmalana','123456789V','123.231.124.4','2016-04-27 10:30:54'),(314,'PL','Siddamulla','123456789V','123.231.124.4','2016-04-27 10:30:54'),(315,'PL','Sri Jayewardenepura','123456789V','123.231.124.4','2016-04-27 10:30:54'),(316,'PL','Talawatugoda','123456789V','123.231.124.4','2016-04-27 10:30:54'),(317,'PL','Tummodara','123456789V','123.231.124.4','2016-04-27 10:30:54'),(318,'PL','Waga','123456789V','123.231.124.4','2016-04-27 10:30:54'),(319,'PL','Watareka','123456789V','123.231.124.4','2016-04-27 10:30:54'),(320,'PL','Wijerama','123456789V','123.231.124.4','2016-04-27 10:30:54'),(321,'PL','Thalapathpitiya - South','123456789V','123.231.124.4','2016-05-10 10:29:38'),(322,'KD','Kaduwela - Sandasiripura','123456789V','123.231.124.4','2016-05-19 11:48:46'),(323,'KD','Yakala','123456789V','123.231.124.4','2016-05-20 13:47:02'),(324,'KD','Nelum Pedesa','123456789V','123.231.124.4','2016-05-23 16:00:54'),(325,'PL','Molpe','123456789V','123.231.124.4','2016-06-03 11:48:58'),(326,'PL','Sudarshi - Polgaovita','123456789V','123.231.124.4','2016-06-06 08:51:02'),(327,'PL','Honnanthara south','123456789V','123.231.124.4','2016-06-06 11:12:10'),(328,'WP','Kahatapitiya','123456789V','123.231.124.4','2016-06-06 13:22:40'),(329,'KD','Walgama','123456789V','123.231.124.4','2016-06-06 14:22:25'),(330,'AV','Kahatapitiya','123456789V','123.231.124.4','2016-06-07 09:27:45'),(331,'AV','Kotahara Kanda','123456789V','112.134.157.74','2016-06-07 09:44:26'),(332,'CO','Katubedda','902554203V','127.0.0.1','2016-07-25 12:12:07');
/*!40000 ALTER TABLE `villages_name` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:40
