-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 12, 2019 at 08:13 PM
-- Server version: 10.1.28-MariaDB
-- PHP Version: 5.6.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ahvaandhesed_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `events_tbl`
--

CREATE TABLE `events_tbl` (
  `event_id` int(11) NOT NULL,
  `event_desc` varchar(40) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `start_date` datetime NOT NULL,
  `end_date` datetime NOT NULL,
  `color` varchar(20) COLLATE utf8mb4_unicode_520_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `events_tbl`
--

INSERT INTO `events_tbl` (`event_id`, `event_desc`, `start_date`, `end_date`, `color`) VALUES
(1, 'אירוע חדש', '2019-01-23 12:00:00', '2019-01-27 00:00:00', '#039'),
(2, 'איזשהו אירוע', '2019-01-23 00:00:00', '2019-01-25 00:00:00', '#039');

-- --------------------------------------------------------

--
-- Table structure for table `family_tbl`
--

CREATE TABLE `family_tbl` (
  `family_Id` int(11) NOT NULL,
  `first_Name` varchar(10) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `last_Name` varchar(10) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `street` varchar(20) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `house_Num` varchar(10) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `floor` int(10) NOT NULL,
  `phone` varchar(13) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `people_Number` int(10) NOT NULL,
  `notes` varchar(100) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `how_Did_You_Hear` varchar(30) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `reason_For_Referral` varchar(30) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `join_Date` date NOT NULL,
  `family_Type` varchar(20) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `basket_Type` varchar(20) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `house` tinyint(1) NOT NULL,
  `car` tinyint(1) NOT NULL,
  `debt` tinyint(1) NOT NULL,
  `pay_Checks` tinyint(1) NOT NULL,
  `bituah_Leumi` tinyint(1) NOT NULL,
  `bank_Account` tinyint(1) NOT NULL,
  `credit_card` tinyint(1) NOT NULL,
  `copy_Id` tinyint(1) NOT NULL,
  `rent_Contract` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `family_tbl`
--

INSERT INTO `family_tbl` (`family_Id`, `first_Name`, `last_Name`, `street`, `house_Num`, `floor`, `phone`, `people_Number`, `notes`, `how_Did_You_Hear`, `reason_For_Referral`, `join_Date`, `family_Type`, `basket_Type`, `house`, `car`, `debt`, `pay_Checks`, `bituah_Leumi`, `bank_Account`, `credit_card`, `copy_Id`, `rent_Contract`) VALUES
(1, 'פרטי', 'משפחה', 'רחוב', 'מספר בית', 2, '11', 5, 'הערות', '1', '1', '2019-01-02', '1', '1', 1, 1, 0, 0, 0, 0, 0, 1, 1),
(433, 'שמואל', 'לוי', 'חרוב', ' 3גשד', 3, '0', 432, '', '', '', '2019-02-12', 'revaha', 'פירות וירקות', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(434, 'שם פרטי', 'שם משפחה', 'רחוב', '43', 4, '0', 3, '', '', '', '2019-02-18', 'revaha', 'פירות וירקות', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(435, 'שם פרטי', 'שם משפחה', 'רחוב', '4', 4, '0', 2, '', '', '', '2019-02-04', 'revaha', 'רגיל', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(436, 'פרטי', 'שם משפחה', 'רחוב', '2', 2, '0', 2, '', '', '', '2019-02-04', 'פרטי', 'רגיל', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(445, 'ירדן', 'אוחנה', 'חרצית', '516', 3, '0522768719', 5, 'אף פעם', 'ח', 'ר', '2019-02-20', 'פרטי', 'פירות וירקות', 1, 1, 0, 0, 0, 0, 0, 0, 0),
(446, 'בד', 'גדש', 'רחוב', '43', 43, '1234567890', 4, 'הערות', 'ח', 'ס', '1991-07-29', 'פרטי', 'פירות וירקות', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(447, 'שינוי', 'שינוישוב', 'בסז', '4', 4, '4444444444', 4, 'גשדגשד', 'גדשדש', 'גדשגדש', '0001-01-03', 'פרטי', 'רגיל', 1, 1, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `file_tbl`
--

CREATE TABLE `file_tbl` (
  `file_id` int(11) NOT NULL,
  `file_name` varchar(50) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `full_file` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

-- --------------------------------------------------------

--
-- Table structure for table `login_tbl`
--

CREATE TABLE `login_tbl` (
  `user_id` int(11) NOT NULL,
  `user_name` varchar(15) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `password` varchar(15) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `email` varchar(20) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `confirmPassword` varchar(15) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `UserType` varchar(10) COLLATE utf8mb4_unicode_520_ci NOT NULL DEFAULT 'Admin'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `login_tbl`
--

INSERT INTO `login_tbl` (`user_id`, `user_name`, `password`, `email`, `confirmPassword`, `UserType`) VALUES
(51, 'ניסיון ירדן', '555555', 'gfs@walla.com', '', 'Admin'),
(52, 'גד', '222222', 'tt@re', '', 'Admin'),
(53, 'ניסיון בתקווה א', '7777777', 'f@3', '', 'Admin'),
(54, 'עדכגדכד', '444444', 'gfs@walla.com', '', 'Admin'),
(55, 'ewq', '345678', 'f@3', '', 'Admin'),
(58, 'ניסיון חדש', '5555555555', 'f@3', '', 'Admin'),
(59, 'ניסיון חדש', '5555555555', 'f@3', '', 'Admin'),
(60, 'כגד', '111111111', 'avi@dsa', '111111111', 'Admin'),
(61, 'כגד', '111111111', 'avi@dsa', '111111111', 'Admin'),
(64, 'dsdsa', '3333333333', 'f@3dasdsadsa.dad', '3333333333', 'Admin'),
(67, 'fds', '123456', 'f@3', '123456', 'Admin'),
(68, 'fds', '123456', 'f@3', '123456', 'Admin'),
(69, 'fdsfd', '123456', 'f@13', '123456', 'Admin'),
(70, 'ירדן האלופה', '2222222222', '12@ss', '2222222222', 'Admin'),
(72, 'אני', '123456', 'yarde@1', '123456', 'Admin'),
(73, 'שלומציון', '22334455', 'f@332', '22334455', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `order_tbl`
--

CREATE TABLE `order_tbl` (
  `order_id` int(11) NOT NULL,
  `order_type_id` int(11) NOT NULL,
  `order_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `received_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `received` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

-- --------------------------------------------------------

--
-- Table structure for table `order_type_tbl`
--

CREATE TABLE `order_type_tbl` (
  `order_type_id` int(11) NOT NULL,
  `order_type_name` varchar(50) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `supplier_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `order_type_tbl`
--

INSERT INTO `order_type_tbl` (`order_type_id`, `order_type_name`, `supplier_id`) VALUES
(65, 'גבינות', 9),
(66, 'בשרים', 13),
(67, 'לחמים', 13);

-- --------------------------------------------------------

--
-- Table structure for table `product_in_order_type_tbl`
--

CREATE TABLE `product_in_order_type_tbl` (
  `order_type_id` int(11) NOT NULL,
  `product` varchar(50) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `amount` int(11) NOT NULL,
  `comments` varchar(100) COLLATE utf8mb4_unicode_520_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `product_in_order_type_tbl`
--

INSERT INTO `product_in_order_type_tbl` (`order_type_id`, `product`, `amount`, `comments`) VALUES
(65, 'גבינה לבנה', 1, ''),
(66, 'טלה', 1, ''),
(67, 'לחם מקמח מלא', 1, '');

-- --------------------------------------------------------

--
-- Table structure for table `product_tbl`
--

CREATE TABLE `product_tbl` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(30) COLLATE utf8mb4_unicode_520_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

-- --------------------------------------------------------

--
-- Table structure for table `supplier_tbl`
--

CREATE TABLE `supplier_tbl` (
  `ID` int(11) NOT NULL,
  `company_name` varchar(50) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `phone` varchar(15) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `fax` varchar(15) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `contact_person` varchar(50) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `contact_phone` varchar(15) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `goods_type` varchar(50) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `supplier_type` varchar(10) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `address` varchar(30) COLLATE utf8mb4_unicode_520_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `supplier_tbl`
--

INSERT INTO `supplier_tbl` (`ID`, `company_name`, `phone`, `fax`, `contact_person`, `contact_phone`, `goods_type`, `supplier_type`, `address`) VALUES
(1, 'f', 'f', 'sw', '1', '1', 'w', 'תורם', ''),
(2, 'f', 'f', 'sw', '1', '1', 'w', 'תורם', ''),
(3, '', '', '', '', 'ג', '', '', ''),
(6, 'ע', '522768719', '4', 'כ', '522768719', 'ע', 'רגיל', ''),
(8, 'grdf', '66', '55', 'fd', '5', 'gd', 'רגיל', ''),
(9, 'שופרסל', '1', '1', 'אמנון', '555', 'יבשים', 'רגיל', ''),
(10, 'רמי לוי שיווק השקמה בעמ', '0', '1', 'יסמין', '555', 'פירות וירקות', 'תורם', ''),
(13, 'יוחננוף בעם', '5227687194', '4444444444444', 'יוחננוף', '5422768719', 'אוכל מוכן', 'רגיל', ''),
(16, 'חצי חינם', '0879879789', '534323423', 'אמנון', '4568543456', 'קופסאות שימורים', 'רגיל', ''),
(17, 'גד', '6555555555', '55555555555', 'כגד', '5555555555', 'כדגגדכ', 'רגיל', ''),
(18, 'dsa', '444444444444', '432324324', 'fasd', '44444444', 'בשרים', 'תורם', 'xdsfdsfds');

-- --------------------------------------------------------

--
-- Table structure for table `task_tbl`
--

CREATE TABLE `task_tbl` (
  `task_id` int(11) NOT NULL,
  `task_desc` varchar(100) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `task_status` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `task_tbl`
--

INSERT INTO `task_tbl` (`task_id`, `task_desc`, `task_status`) VALUES
(5, 'משימה 1', 0),
(6, 'משימה 2', 0),
(7, 'משימה 3', 0),
(8, 'משימה 4', 0);

-- --------------------------------------------------------

--
-- Table structure for table `volunteers_tbl`
--

CREATE TABLE `volunteers_tbl` (
  `volunteer_id` int(11) NOT NULL,
  `volunteer_fname` varchar(20) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `volunteer_lname` varchar(20) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `phone` varchar(13) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `birth_date` date NOT NULL,
  `volunteer_type` varchar(14) COLLATE utf8mb4_unicode_520_ci NOT NULL,
  `IdNum` varchar(9) COLLATE utf8mb4_unicode_520_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_520_ci;

--
-- Dumping data for table `volunteers_tbl`
--

INSERT INTO `volunteers_tbl` (`volunteer_id`, `volunteer_fname`, `volunteer_lname`, `phone`, `birth_date`, `volunteer_type`, `IdNum`) VALUES
(1, 'משה', 'יצחק', '1', '2000-12-19', '', ''),
(3, 'מנשה', 'אוחיון', '1', '2001-01-01', 'חגים', ''),
(4, 'אופיר', 'שלום', '12', '2001-01-01', 'חגים', ''),
(5, 'ניר', 'העמק', '1', '2001-01-01', 'קבוע', ''),
(7, 'ממתתנדב חדש', 'גכש', '2345', '0000-00-00', 'קבוע', ''),
(8, 'אמיר', 'אמיר', '21', '0000-00-00', 'חגים', ''),
(9, 'אמיר', 'אמיר', '21', '0000-00-00', 'חגים', ''),
(15, 'ירדן', 'גכש', '4343242345', '0000-00-00', 'חגים', ''),
(17, 'ממתתנדב חדש', 'גכש', '66666612', '0000-00-00', 'חגים', ''),
(18, 'ירדן', 'אוחנה', '5555555555', '2019-01-01', 'קבוע', ''),
(22, 'עינב', 'עינב', '5555555544', '2019-02-12', 'קבוע', ''),
(24, 'אבי', 'גל', '4444444444', '2019-02-05', 'חגים', ''),
(26, 'שם פרטי', 'שם משפחה', '4444444444', '2019-02-28', 'קבוע', ''),
(27, 'ירדן', 'אוחנה', '0522768719', '1991-07-28', 'קבוע', ''),
(28, 'שולה', 'כהן', '09090909090', '0000-00-00', 'חגים', ''),
(29, 'שולה', 'בזבגד', '09090909090', '0000-00-00', 'חגים', ''),
(30, 'מתנדב שם פרטי', 'מתנדב שם משפחה', '5555555555', '1991-07-28', 'קבוע', ''),
(33, 'אני', 'אני', '0522768719', '1991-07-27', 'קבוע', '767676767');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `events_tbl`
--
ALTER TABLE `events_tbl`
  ADD PRIMARY KEY (`event_id`);

--
-- Indexes for table `family_tbl`
--
ALTER TABLE `family_tbl`
  ADD PRIMARY KEY (`family_Id`);

--
-- Indexes for table `file_tbl`
--
ALTER TABLE `file_tbl`
  ADD PRIMARY KEY (`file_id`);

--
-- Indexes for table `login_tbl`
--
ALTER TABLE `login_tbl`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `order_tbl`
--
ALTER TABLE `order_tbl`
  ADD PRIMARY KEY (`order_id`,`order_type_id`),
  ADD KEY `order_type_id` (`order_type_id`);

--
-- Indexes for table `order_type_tbl`
--
ALTER TABLE `order_type_tbl`
  ADD PRIMARY KEY (`order_type_id`);

--
-- Indexes for table `product_in_order_type_tbl`
--
ALTER TABLE `product_in_order_type_tbl`
  ADD PRIMARY KEY (`order_type_id`,`product`);

--
-- Indexes for table `product_tbl`
--
ALTER TABLE `product_tbl`
  ADD PRIMARY KEY (`product_id`);

--
-- Indexes for table `supplier_tbl`
--
ALTER TABLE `supplier_tbl`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `task_tbl`
--
ALTER TABLE `task_tbl`
  ADD PRIMARY KEY (`task_id`);

--
-- Indexes for table `volunteers_tbl`
--
ALTER TABLE `volunteers_tbl`
  ADD PRIMARY KEY (`volunteer_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `events_tbl`
--
ALTER TABLE `events_tbl`
  MODIFY `event_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `family_tbl`
--
ALTER TABLE `family_tbl`
  MODIFY `family_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=448;

--
-- AUTO_INCREMENT for table `file_tbl`
--
ALTER TABLE `file_tbl`
  MODIFY `file_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login_tbl`
--
ALTER TABLE `login_tbl`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=74;

--
-- AUTO_INCREMENT for table `order_tbl`
--
ALTER TABLE `order_tbl`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `order_type_tbl`
--
ALTER TABLE `order_type_tbl`
  MODIFY `order_type_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=68;

--
-- AUTO_INCREMENT for table `product_tbl`
--
ALTER TABLE `product_tbl`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier_tbl`
--
ALTER TABLE `supplier_tbl`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `task_tbl`
--
ALTER TABLE `task_tbl`
  MODIFY `task_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `volunteers_tbl`
--
ALTER TABLE `volunteers_tbl`
  MODIFY `volunteer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `order_tbl`
--
ALTER TABLE `order_tbl`
  ADD CONSTRAINT `order_tbl_ibfk_1` FOREIGN KEY (`order_type_id`) REFERENCES `order_type_tbl` (`order_type_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `product_in_order_type_tbl`
--
ALTER TABLE `product_in_order_type_tbl`
  ADD CONSTRAINT `product_in_order_type_tbl_ibfk_1` FOREIGN KEY (`order_type_id`) REFERENCES `order_type_tbl` (`order_type_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
