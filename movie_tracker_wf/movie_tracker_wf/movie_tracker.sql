/*************************************************
Script: movie_tracker.sql
Author: Brian Minaji
Date: August 7, 2019
Description: Create movie_tracker database objects
**************************************************/

-- Setting NOCOUNT ON suppresses completion messages for each INSERT
SET NOCOUNT ON

-- Make the master database the current database
USE master

-- If database movie_tracker exists, drop it
IF EXISTS (SELECT  * FROM sysdatabases WHERE name = 'movie_tracker')
  DROP DATABASE movie_tracker;
GO

-- Create the movie_tracker database
CREATE DATABASE movie_tracker;
GO

-- Make the movie_tracker database the current database
USE movie_tracker;

-- Create genres table
CREATE TABLE genres (
  genre_id INT PRIMARY KEY IDENTITY,
  genre_description VARCHAR(25));

-- Create movies table
CREATE TABLE movies (
	movie_id INT PRIMARY KEY IDENTITY,
	title VARCHAR(255),
	date_seen DATE,
	genre_id INT FOREIGN KEY REFERENCES genres (genre_id),
	rating INT);
GO

-- Insert genres records
INSERT INTO genres VALUES('Action');
INSERT INTO genres VALUES('Adventure');
INSERT INTO genres VALUES('Animation');
INSERT INTO genres VALUES('Biography');
INSERT INTO genres VALUES('Comedy');
INSERT INTO genres VALUES('Crime');
INSERT INTO genres VALUES('Documentary');
INSERT INTO genres VALUES('Drama');
INSERT INTO genres VALUES('Family');
INSERT INTO genres VALUES('Fantasy');
INSERT INTO genres VALUES('Film Noir');
INSERT INTO genres VALUES('History');
INSERT INTO genres VALUES('Horror');
INSERT INTO genres VALUES('Music');
INSERT INTO genres VALUES('Musical');
INSERT INTO genres VALUES('Mystery');
INSERT INTO genres VALUES('Romance');
INSERT INTO genres VALUES('Sci-Fi');
INSERT INTO genres VALUES('Short Film');
INSERT INTO genres VALUES('Sport');
INSERT INTO genres VALUES('Superhero');
INSERT INTO genres VALUES('Thriller');
INSERT INTO genres VALUES('War');
INSERT INTO genres VALUES('Western');
GO

-- Verify inserts
CREATE TABLE verify (
  table_name varchar(30), 
  actual INT, 
  expected INT);
GO

INSERT INTO verify VALUES('genres', (SELECT COUNT(*) FROM genres), 24);
INSERT INTO verify VALUES('movies', (SELECT COUNT(*) FROM movies), 0);
PRINT 'Verification';
SELECT table_name, actual, expected, expected - actual discrepancy FROM verify;
DROP TABLE verify;
GO