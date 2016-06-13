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
-- Table structure for table `micro_exective_root`
--

DROP TABLE IF EXISTS `micro_exective_root`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `micro_exective_root` (
  `idrbf_exective_root` int(11) NOT NULL AUTO_INCREMENT,
  `exe_id` varchar(2) DEFAULT NULL,
  `exe_name` varchar(100) DEFAULT NULL,
  `branch_code` varchar(10) DEFAULT NULL,
  `create_user_id` varchar(10) DEFAULT NULL,
  `create_ip` varchar(45) DEFAULT NULL,
  `create_date_time` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idrbf_exective_root`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `micro_exective_root`
--

LOCK TABLES `micro_exective_root` WRITE;
/*!40000 ALTER TABLE `micro_exective_root` DISABLE KEYS */;
INSERT INTO `micro_exective_root` VALUES (2,'01','Pradeep Ranjeewa','CO','123456789V','123.231.124.4','2016-04-26 10:08:19'),(3,'02','K. Mahanama','CO','123456789V','123.231.124.4','2016-05-05 16:29:59'),(4,'01','K. mahanama','PL','123456789V','123.231.124.4','2016-05-10 10:29:08'),(5,'02','Lahiru Pathum Rosa','PL','123456789V','123.231.124.4','2016-05-11 10:03:19'),(6,'01','Lasindu Thanushka','KD','123456789V','123.231.124.4','2016-05-19 11:46:04'),(7,'02','Thanuja Dhananjaya','KD','123456789V','123.231.124.4','2016-05-23 16:00:12'),(8,'03','E.Lakshan Melvin','PL','123456789V','123.231.124.4','2016-05-27 14:13:57'),(9,'03','Lasindu Thanushka','KD','123456789V','123.231.124.4','2016-05-27 14:30:27'),(10,'04','H.R.S.A. Kumara','KD','123456789V','123.231.124.4','2016-06-02 08:59:58'),(11,'05','K.A.Ajantha Perera','KD','123456789V','123.231.124.4','2016-06-02 09:16:49'),(12,'06','H.R.S.A. Kumara','KD','123456789V','123.231.124.4','2016-06-02 09:17:57'),(13,'07','H.R.S.A.Kumara','KD','123456789V','123.231.124.4','2016-06-02 09:22:37'),(14,'08','H.R.S.A.Kumara','KD','123456789V','123.231.124.4','2016-06-02 09:32:28'),(15,'01','H.W.D.B.Gunathilaka','WP','123456789V','112.134.226.38','2016-06-02 12:09:23'),(16,'04','S.L.P. Rosa','PL','123456789V','123.231.124.4','2016-06-03 11:46:12'),(17,'01','H.W.D.B.Gunathilake','AV','123456789V','123.231.124.4','2016-06-07 09:27:26'),(18,'02','Pradeep','AV','123456789V','112.134.157.74','2016-06-07 09:29:35'),(19,'03','R.I.S.Rajapaksha','AV','123456789V','112.134.157.74','2016-06-07 09:32:57'),(20,'02','A.P.Kumara','AV','123456789V','112.134.157.74','2016-06-07 09:33:57');
/*!40000 ALTER TABLE `micro_exective_root` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-13 19:39:01
