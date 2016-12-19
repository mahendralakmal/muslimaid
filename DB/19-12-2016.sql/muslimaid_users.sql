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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `idusers` int(11) NOT NULL AUTO_INCREMENT,
  `nic` varchar(10) NOT NULL,
  `user_password` varchar(10) DEFAULT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `user_type` varchar(20) DEFAULT NULL,
  `designation` varchar(45) DEFAULT NULL,
  `deleted` varchar(1) DEFAULT NULL,
  `current_status` varchar(1) DEFAULT NULL,
  `created_on` varchar(45) DEFAULT NULL,
  `last_accessed_on` varchar(45) DEFAULT NULL,
  `last_accessed_ip` varchar(45) DEFAULT NULL,
  `created_user_nic` varchar(10) DEFAULT NULL,
  `photo_path` varchar(100) DEFAULT NULL,
  `user_address` varchar(255) DEFAULT NULL,
  `date_of_birth` varchar(45) DEFAULT NULL,
  `user_title` varchar(10) DEFAULT NULL,
  `module_name` varchar(45) DEFAULT NULL,
  `branch_code` varchar(4) DEFAULT NULL,
  `company_code` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`idusers`,`nic`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'902554203V','cG1AMTI=','Kosala','Fernando','Top Managment','Admin','N','L','2016-06-12 11:01:21','2016-06-12 11:01:21','124.43.24.31',NULL,'User_Photos\\kosala.png',NULL,'1990-09-11','Mr.','A','CO','PCA'),(2,'123456789V','MTIzNDU=','Test','Test','Top Managment','Admin','N','L','2016-06-12 11:01:21','2016-06-12 11:01:21','127.0.0.1','902554203V','User_Photos\\blank.png','test','2005-01-01','Mr.','A','CO','PCA');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:37
