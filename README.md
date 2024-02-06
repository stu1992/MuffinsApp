# MuffinsApp
a basic back and front end to list your favorite muffins.

This is a react front end and asp.net core web api back end conencting to a mysql database. It's an example of a very simple project to demonstrate a full stack architecture while the data being processed is simple, I've tried to decouple much of the business logic so that as changes are made, errors are minimized and concerns are isolated.

# What it does
the back end provides a put and get endpoint to get a list of muffin types and persist it alphabetically, The get endpoint is used by the react app to display as a list

# Things i didn't do
+ the mysql back end was hacked together and has passwords in code as plain text.
+ It also assumes a certain configuration is already up and available.
+ I didn't bother with a lot of error correction or injecting dependancies
+ 
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

# How to run it
for the react app
```
npm install
npm start
```
for the api
open and run in visual studio

for the database
run a mysql instance with a user name of "root" and a passowrd of "password"
add a database "muffins" and a table "types" with a "type" varchar
