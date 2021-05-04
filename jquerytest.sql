/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 80021
 Source Host           : localhost:3306
 Source Schema         : jquerytest

 Target Server Type    : MySQL
 Target Server Version : 80021
 File Encoding         : 65001

 Date: 02/04/2021 16:47:29
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for admin
-- ----------------------------
DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `登录名称` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `密码` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `联系电话` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `添加时间` datetime(6) NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 14 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of admin
-- ----------------------------
INSERT INTO `admin` VALUES (1, 'a', 'asd', '12121212121', '2021-04-01 13:27:17.972674');
INSERT INTO `admin` VALUES (12, 'aa', '12', '12', '2021-04-01 14:37:00.910804');
INSERT INTO `admin` VALUES (13, 'a1', '12', '12', '2021-04-01 14:37:39.892553');

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `产品名称` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `产品类型` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `库存数量` int(0) NOT NULL DEFAULT 0,
  `单位名称` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of product
-- ----------------------------
INSERT INTO `product` VALUES (1, 'cky012', '男', 26, 'ckyBuilder2');
INSERT INTO `product` VALUES (2, 'cky01', '男', 40, 'ckyBuilder');
INSERT INTO `product` VALUES (3, 'cky0001', '女', 50, 'ckyBuilder');
INSERT INTO `product` VALUES (4, 'cky1000', '男', 13, 'ckyBuilder');
INSERT INTO `product` VALUES (5, 'cky1012', '2', 136, 'ckyBuilder');
INSERT INTO `product` VALUES (6, 'cky1100', '男', 3, '51');
INSERT INTO `product` VALUES (7, 'cky111', '男', 32, '111');
INSERT INTO `product` VALUES (8, 'cky0000', '女', 9328, '000');
INSERT INTO `product` VALUES (9, 'wzp000', '男', 9998, 'cky’s');
INSERT INTO `product` VALUES (10, 'gcm001', '女', 2, '11111111111');
INSERT INTO `product` VALUES (16, 'gcm111', '5423', 41233, '12342');
INSERT INTO `product` VALUES (17, 'gcm110', '1112', 1112, 'gcm1102');
INSERT INTO `product` VALUES (18, 'gcm010', '010', 23, '010');
INSERT INTO `product` VALUES (20, 'gcm101', '101', 111, '111111');
INSERT INTO `product` VALUES (21, 'abc0001', '12', 123, '22');
INSERT INTO `product` VALUES (22, 'newbee', 'bee', 0, 'newbeecom');
INSERT INTO `product` VALUES (23, 'beeee', 'beeee', 4, 'newbeecom');

-- ----------------------------
-- Table structure for sale
-- ----------------------------
DROP TABLE IF EXISTS `sale`;
CREATE TABLE `sale`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `公司名称` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `销售时间` datetime(6) NULL,
  `销售人员` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `送货地址` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sale
-- ----------------------------
INSERT INTO `sale` VALUES (1, 'ckyCompany', '2021-04-01 16:59:39.976931', 'cky', 'cky da lou');

-- ----------------------------
-- Table structure for saledetail
-- ----------------------------
DROP TABLE IF EXISTS `saledetail`;
CREATE TABLE `saledetail`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `产品名称` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `主表Id` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `销售数量` int(0) NOT NULL DEFAULT 0,
  `单位名称` varchar(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`, `主表Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of saledetail
-- ----------------------------
INSERT INTO `saledetail` VALUES (1, '1', '1', 12, 'ckyCompany');

SET FOREIGN_KEY_CHECKS = 1;
