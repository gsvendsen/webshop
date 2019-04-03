-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Apr 03, 2019 at 08:26 PM
-- Server version: 5.7.23
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `webshop`
--

-- --------------------------------------------------------

--
-- Table structure for table `Cartitems`
--

CREATE TABLE `Cartitems` (
  `id` int(11) NOT NULL,
  `cart_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Carts`
--

CREATE TABLE `Carts` (
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Carts`
--

INSERT INTO `Carts` (`id`) VALUES
(1);

-- --------------------------------------------------------

--
-- Table structure for table `Orderitems`
--

CREATE TABLE `Orderitems` (
  `id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_name` text NOT NULL,
  `product_quantity` int(11) NOT NULL,
  `product_price` float NOT NULL,
  `product_description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Orders`
--

CREATE TABLE `Orders` (
  `id` int(11) NOT NULL,
  `customer_name` text NOT NULL,
  `customer_address` text NOT NULL,
  `customer_phone` text NOT NULL,
  `order_date` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `Products`
--

CREATE TABLE `Products` (
  `id` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Description` text NOT NULL,
  `Price` float NOT NULL,
  `Image` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Products`
--

INSERT INTO `Products` (`id`, `Name`, `Description`, `Price`, `Image`) VALUES
(1, 'Black T-Shirt', '100% Cotton T-Shirt Unisex', 10, 'https://lp.weekday.com/app003prod?set=source[01_0410605_001_001],type[ECOMLOOK],device[hdpi],quality[80],ImageVersion[2018084]&call=url[file:/product/main]'),
(2, 'White T-Shirt', '100% Cotton T-Shirt Unisex', 10, 'https://lp.weekday.com/app003prod?set=source[01_0410570_026_001],type[ECOMLOOK],device[hdpi],quality[80],ImageVersion[2018084]&call=url[file:/product/main]'),
(3, 'Black Coach Jacket', '70% Nylon 30% Cotton Coach Jacket Unisex', 25, 'https://lp.weekday.com/app003prod?set=source[01_0703205_001_001],type[ECOMLOOK],device[hdpi],quality[80],ImageVersion[2019092]&call=url[file:/product/main]'),
(5, 'Hill Wind Joggers', 'The Hill Wind Joggers are a pair of tracksuit pants in a crinkled material.', 40, 'https://lp.weekday.com/app003prod?set=source[01_0713098_002_001],type[ECOMLOOK],device[hdpi],quality[80],ImageVersion[2019092]&call=url[file:/product/main]'),
(6, 'Marcus Track Pants', 'The Marcus Track Pants by FILA stand out with their colour blocking in the brand\'s iconic colours.', 45, 'https://lp.weekday.com/app003prod?set=source[01_0668502_001_001],type[ECOMLOOK],device[hdpi],quality[80],ImageVersion[2018072]&call=url[file:/product/main]');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Cartitems`
--
ALTER TABLE `Cartitems`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Carts`
--
ALTER TABLE `Carts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Orderitems`
--
ALTER TABLE `Orderitems`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Orders`
--
ALTER TABLE `Orders`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Products`
--
ALTER TABLE `Products`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Cartitems`
--
ALTER TABLE `Cartitems`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=98;

--
-- AUTO_INCREMENT for table `Carts`
--
ALTER TABLE `Carts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `Orderitems`
--
ALTER TABLE `Orderitems`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;

--
-- AUTO_INCREMENT for table `Orders`
--
ALTER TABLE `Orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT for table `Products`
--
ALTER TABLE `Products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
