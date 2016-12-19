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
-- Table structure for table `family_relationship_details`
--

DROP TABLE IF EXISTS `family_relationship_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `family_relationship_details` (
  `frd_ID` int(11) NOT NULL AUTO_INCREMENT,
  `contract_code` varchar(15) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `relationship` varchar(45) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `occupation` varchar(45) DEFAULT NULL,
  `income` decimal(10,2) DEFAULT NULL,
  `create_user_nic` varchar(12) DEFAULT NULL,
  `user_ip` varchar(45) DEFAULT NULL,
  `date_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`frd_ID`,`contract_code`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `family_relationship_details`
--

LOCK TABLES `family_relationship_details` WRITE;
/*!40000 ALTER TABLE `family_relationship_details` DISABLE KEYS */;
INSERT INTO `family_relationship_details` VALUES (1,'CO/CS/000004','Dileka','son',14,'student',0.00,'123456789V','127.0.0.1','2016-08-29 09:50:49'),(2,'CO/CS/000004','divya','doughter',12,'student',0.00,'123456789V','127.0.0.1','2016-08-29 09:50:49'),(3,'CO/CS/000004','Dileka','son',14,'student',0.00,'123456789V','127.0.0.1','2016-08-29 09:54:19'),(4,'CO/CS/000004','divya','doughter',12,'student',0.00,'123456789V','127.0.0.1','2016-08-29 09:54:19'),(5,'CO/CS/000004','QWERTY JL','SON',12,'Student',0.00,'123456789V','127.0.0.1','2016-12-02 12:39:37'),(6,'CO/CS/000004','QWERTY Jb','Doughter',5,'Student',0.00,'123456789V','127.0.0.1','2016-12-02 12:39:37');
/*!40000 ALTER TABLE `family_relationship_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-20  1:38:34
