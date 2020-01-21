-- MySQL Script generated by MySQL Workbench
-- Tue Jan 21 13:44:07 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema blogtest
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema blogtest
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `blogtest` DEFAULT CHARACTER SET utf8 ;
USE `blogtest` ;

-- -----------------------------------------------------
-- Table `blogtest`.`__efmigrationshistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `blogtest`.`__efmigrationshistory` (
  `MigrationId` VARCHAR(95) NOT NULL,
  `ProductVersion` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`MigrationId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `blogtest`.`categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `blogtest`.`categories` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` VARCHAR(10) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `blogtest`.`articles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `blogtest`.`articles` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(100) NULL DEFAULT NULL,
  `Describe` VARCHAR(300) NULL DEFAULT NULL,
  `Read` INT(11) NOT NULL,
  `Like` INT(11) NOT NULL,
  `Comment` INT(11) NOT NULL,
  `Date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `CategoryId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_Articles_CategoryId` (`CategoryId` ASC),
  CONSTRAINT `FK_Articles_Categories_CategoryId`
    FOREIGN KEY (`CategoryId`)
    REFERENCES `blogtest`.`categories` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `blogtest`.`articlecontents`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `blogtest`.`articlecontents` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Content` LONGTEXT NULL DEFAULT NULL,
  `ContentType` VARCHAR(10) NULL DEFAULT NULL,
  `ArticleId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `IX_ArticleContents_ArticleId` (`ArticleId` ASC),
  CONSTRAINT `FK_ArticleContents_Articles_ArticleId`
    FOREIGN KEY (`ArticleId`)
    REFERENCES `blogtest`.`articles` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `blogtest`.`comments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `blogtest`.`comments` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `ArticleId` INT(11) NOT NULL,
  `UserName` VARCHAR(10) NULL DEFAULT NULL,
  `Comment` VARCHAR(300) NULL DEFAULT NULL,
  `Date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  PRIMARY KEY (`Id`),
  INDEX `IX_Comments_ArticleId` (`ArticleId` ASC),
  CONSTRAINT `FK_Comments_Articles_ArticleId`
    FOREIGN KEY (`ArticleId`)
    REFERENCES `blogtest`.`articles` (`Id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

insert into blogtest.categories values(0,'默认分类');
update blogtest.categories set id = 0 where id = 1;