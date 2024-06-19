CREATE DATABASE IF NOT EXISTS workshop;
USE workshop;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Animals` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Animals` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetRoles` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUsers` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `UserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 NULL,
    `EmailConfirmed` tinyint(1) NOT NULL,
    `PasswordHash` longtext CHARACTER SET utf8mb4 NULL,
    `SecurityStamp` longtext CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumber` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumberConfirmed` tinyint(1) NOT NULL,
    `TwoFactorEnabled` tinyint(1) NOT NULL,
    `LockoutEnd` datetime(6) NULL,
    `LockoutEnabled` tinyint(1) NOT NULL,
    `AccessFailedCount` int NOT NULL,
    CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Races` (
    `RaceId` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
    `AnimalId` int NOT NULL,
    CONSTRAINT `PK_Races` PRIMARY KEY (`RaceId`),
    CONSTRAINT `FK_Races_Animals_AnimalId` FOREIGN KEY (`AnimalId`) REFERENCES `Animals` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderDisplayName` longtext CHARACTER SET utf8mb4 NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserRoles` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserTokens` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Value` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

INSERT INTO `Animals` (`Id`, `Description`, `Name`)
VALUES (1, 'animal naif à quatre pattes, bon renifleur', 'Chien'),
(2, 'monstre avec des griffes à quatre pattes, 7 vies', 'Chat');

INSERT INTO `Races` (`RaceId`, `AnimalId`, `Description`, `Name`)
VALUES (1, 1, 'Le Labrador Retriever est une race de chien de taille moyenne à grande, connue pour son tempérament doux et amical. Ils sont intelligents, faciles à dresser, et excellents avec les enfants, ce qui en fait des animaux de compagnie idéaux. Les Labradors ont un pelage court et dense, souvent noir, jaune ou chocolat.', 'Labrador Retriever'),
(2, 1, ' Le Chihuahua est l''une des plus petites races de chiens au monde. Ils sont alertes, vifs et très loyaux envers leurs propriétaires. Les Chihuahuas peuvent avoir un pelage court ou long et sont souvent de couleurs variées. Leur petite taille les rend adaptés à la vie en appartement, mais ils ont besoin de socialisation pour éviter le comportement territorial.', 'Chihuahua'),
(3, 1, 'Le Border Collie est un chien de berger extrêmement intelligent et énergique. Ils sont connus pour leur capacité à apprendre rapidement et exceller dans les activités d''agilité et de travail sur le terrain. Leur pelage peut être lisse ou ondulé, généralement noir et blanc, bien que d''autres couleurs existent.', 'Border Collie'),
(4, 1, 'Le Bulldog Anglais est une race de chien de taille moyenne, connue pour son apparence robuste et ses plis caractéristiques. Ils sont généralement calmes, courageux et affectueux. Leur pelage est court et peut être de diverses couleurs, y compris le blanc, le fauve et le bringé. Les Bulldogs ont besoin de soins particuliers en raison de leurs problèmes de santé potentiels liés à leur morphologie.', 'Bulldog Anglais'),
(5, 1, 'Le Caniche est une race de chien très intelligente et élégante, disponible en trois tailles : standard, miniature et toy. Ils sont connus pour leur pelage bouclé, hypoallergénique, qui nécessite un toilettage régulier. Les Caniches sont vifs, faciles à dresser et excellents dans les compétitions d''agilité et d''obéissance.', 'Caniche (Poodle)'),
(6, 2, 'Le Siamois est une race de chat élégante et sociable, connue pour ses yeux bleus perçants et son pelage court de couleur crème avec des points foncés sur les oreilles, le museau, les pattes et la queue. Ils sont très vocaux, intelligents et aiment être au centre de l''attention.', 'Siamois'),
(7, 2, 'Le Maine Coon est l''une des plus grandes races de chats domestiques. Ils sont connus pour leur taille imposante, leur queue touffue et leur pelage long et soyeux. Les Maine Coons sont affectueux, joueurs et s''entendent bien avec les enfants et autres animaux.', 'Maine Coon'),
(8, 2, 'Le Bengal est une race de chat énergique et athlétique, célèbre pour son pelage tacheté ou marbré rappelant celui d''un léopard. Ils sont intelligents, curieux et aiment grimper et jouer dans l''eau. Les Bengals sont très actifs et nécessitent beaucoup de stimulation.', 'Bengal'),
(9, 2, 'Le Persan est une race de chat domestique réputée pour son visage plat et son pelage long et soyeux. Ils sont généralement calmes, affectueux et préfèrent la vie en intérieur. Les Persans nécessitent un entretien régulier de leur fourrure pour éviter les nœuds et les enchevêtrements.', 'Persan'),
(10, 2, 'Le Sphynx est une race de chat sans poils, connue pour son apparence unique et son caractère affectueux. Ils sont énergiques, curieux et aiment se blottir contre leurs propriétaires pour se réchauffer. Le Sphynx nécessite des bains réguliers pour garder sa peau propre et en bonne santé.', 'Sphynx');

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

CREATE INDEX `IX_Races_AnimalId` ON `Races` (`AnimalId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240619100354_init', '8.0.6');

COMMIT;



