SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `NetSistema` ;
CREATE SCHEMA IF NOT EXISTS `NetSistema` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
USE `NetSistema` ;

-- -----------------------------------------------------
-- Table `NetSistema`.`Cliente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NetSistema`.`Cliente` ;

CREATE  TABLE IF NOT EXISTS `NetSistema`.`Cliente` (
  `idCliente` INT NOT NULL AUTO_INCREMENT ,
  `Nome` VARCHAR(45) NOT NULL ,
  `Logradouro` VARCHAR(45) NULL ,
  `numero` VARCHAR(45) NULL ,
  `complemento` VARCHAR(45) NULL ,
  `bairro` VARCHAR(45) NULL ,
  `cidade` VARCHAR(45) NULL ,
  `uf` VARCHAR(2) NULL ,
  `cep` VARCHAR(45) NULL ,
  `telefone` VARCHAR(45) NULL ,
  `cpjcnpj` VARCHAR(45) NULL ,
  `TipoPessoa` CHAR(1) NULL ,
  PRIMARY KEY (`idCliente`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `NetSistema`.`Pacotes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NetSistema`.`Pacotes` ;

CREATE  TABLE IF NOT EXISTS `NetSistema`.`Pacotes` (
  `idPacotes` INT NOT NULL AUTO_INCREMENT ,
  `NomePacote` VARCHAR(45) NULL ,
  `DescPacote` VARCHAR(100) NULL ,
  `ValorPacote` DECIMAL(10,2) NULL ,
  PRIMARY KEY (`idPacotes`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `NetSistema`.`Venda`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NetSistema`.`Venda` ;

CREATE  TABLE IF NOT EXISTS `NetSistema`.`Venda` (
  `idVenda` INT NOT NULL AUTO_INCREMENT ,
  `idCliente` INT NULL ,
  `idPacote` INT NULL ,
  `DataVenda` DATETIME NULL ,
  `DataVencimentoFatura` DATETIME NULL ,
  `ValorVenda` DECIMAL(10,2) NULL ,
  `Status` CHAR(1) NULL ,
  `Observacao` VARCHAR(100) NULL ,
  PRIMARY KEY (`idVenda`) ,
  INDEX `IdCliente_idx` (`idCliente` ASC) ,
  INDEX `idPacote_idx` (`idPacote` ASC) ,
  CONSTRAINT `IdCliente`
    FOREIGN KEY (`idCliente` )
    REFERENCES `NetSistema`.`Cliente` (`idCliente` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idPacote`
    FOREIGN KEY (`idPacote` )
    REFERENCES `NetSistema`.`Pacotes` (`idPacotes` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `NetSistema`.`Funcionario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NetSistema`.`Funcionario` ;

CREATE  TABLE IF NOT EXISTS `NetSistema`.`Funcionario` (
  `idFuncionario` INT NOT NULL AUTO_INCREMENT ,
  `Nome` VARCHAR(45) NULL ,
  PRIMARY KEY (`idFuncionario`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `NetSistema`.`Horario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NetSistema`.`Horario` ;

CREATE  TABLE IF NOT EXISTS `NetSistema`.`Horario` (
  `idHorario` INT NOT NULL AUTO_INCREMENT ,
  `Horario_desc` VARCHAR(40) NULL ,
  PRIMARY KEY (`idHorario`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `NetSistema`.`Agendamento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NetSistema`.`Agendamento` ;

CREATE  TABLE IF NOT EXISTS `NetSistema`.`Agendamento` (
  `idAgendamento` INT NOT NULL AUTO_INCREMENT ,
  `idVenda` INT NULL ,
  `idFuncionario` INT NULL ,
  `DataAgendamento` DATETIME NULL ,
  `idHorario` INT NULL ,
  PRIMARY KEY (`idAgendamento`) ,
  INDEX `Venda_idx` (`idVenda` ASC) ,
  INDEX `Funcionario_idx` (`idFuncionario` ASC) ,
  INDEX `Horario_idx` (`idHorario` ASC) ,
  CONSTRAINT `Venda`
    FOREIGN KEY (`idVenda` )
    REFERENCES `NetSistema`.`Venda` (`idVenda` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Funcionario`
    FOREIGN KEY (`idFuncionario` )
    REFERENCES `NetSistema`.`Funcionario` (`idFuncionario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Horario`
    FOREIGN KEY (`idHorario` )
    REFERENCES `NetSistema`.`Horario` (`idHorario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
