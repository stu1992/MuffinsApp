# ProfilesApp

A quick and dirty demonstration of some basic resful enpoints and a many-to-many db schema

very minimal error correction, a lot of dirty string literals on the repository layer and some of the models are a bit suss but otherwise I think it works ok for a few hours to get a proof of concept
ignore the react app completely. It's no longer meaningful on this branch

run a mysql instance with a user name of "root" and a passowrd of "password"

create database userprofiles;

create table users(
userId int NOT NULL primary key AUTO_INCREMENT,
firstName TEXT NOT NULL,
lastName TEXT NOT NULL,
email TEXT NOT NULL
);

create table profiles(
profileId int NOT NULL primary key AUTO_INCREMENT,
profileName TEXT NOT NULL,
profileDescription TEXT NOT NULL
);

create table userProfiles(
id int NOT NULL primary key AUTO_INCREMENT,
userId int NOT NULL,
profileId int NOT NULL,
CONSTRAINT FK_userId FOREIGN KEY (userId)
REFERENCES users(userId),
CONSTRAINT FK_profileId FOREIGN KEY (profileId)
REFERENCES profiles(profileId)
);

