# SQL - Miniproject

## Overview

This application is used for reporting the amount of time that a user has worked on a project(s).

## Functionality

The main functionality of this program is to make a daily report of the amount of hours that has been spent by working on one or more projects.
All of the functions used by a user are: **register** time, **create** & **edit** existing data. Data which are able to be edited are project and person names. In addition you can also edit the worked time that has already been registered (incase of wrongful input).

## Structure

The program consist of different files which all have been separated from eachother to establish a good foundation. This helped me to build all of the functionality and logic easier because the base structure was created from the start.
All the files the program depend upon are:

- Program.cs - (Main file)
- PostgresDataAccess.cs (Communication to database)
- PersonModel.cs (Class of database _person_ table)
- ProjectModel.cs (Class of database _project_ table)
- ProjectPersonModel.cs (Class of database _project_person_ table)
- App.config (Connection string to database)

The Main file (Program.cs) consist of a menu system, and the three major functionalities which the application is built upon (register, create and edit data). All of the queries which are sent to the PostgreSQL database are stored in the PostgresDataAccess file. Classes has been made for each database table. App.config is not added to this repository for safety reasons.

## Tools

All of the tools used during the development of this program:

#### Integrated Development Environment (IDE)

- Visual Studio

#### Relational Database Management System (RDBMS)

- PostgreSQL

#### Database Client

- DbGate

#### Dependencies / Packages

- Dapper
- Npgsql
- Dotnet / runtime

#### Languages

- C#
- SQL
