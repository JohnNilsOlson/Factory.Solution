# _Dr. Sneuss' Factory_
Epicodus Week 11  
Version 1.0 - August 7, 2020 

## _Project Description_
A practice in many-to-many database relationships.

## _Contributors_
JohnNils Olson

## _Usage_
A webapp for factory managers to track machinery and maintenance staff.

## _Behavior Specifications_
| Behavior | Input | Output |
| ---- | ---- | ---- |
| Program Directs to Splash Page | Project URL | List of All Machines and Technicians |
| Program Directs to List of Machines, Retrieved from Database | Link -> "See all Machines" | Redirect -> Machines - Index |
| Program Directs to Add New Machine | Link -> "Add New Machine" | Redirect -> Machines - Create | 
| User Inputs New Machine Info, Machine Added to Database | Submit | Redirect -> Machines - Index |
| Program Directs to Machine Details | Link -> "Machine Details" | Redirect -> Machines - Details |
| Program Directs to Remove Machine | Link -> "Remove Machine" | Redirect -> Machines - Delete
| User Removes Machine, Machine Removed from Database | Submit | Redirect -> Machines - Index |
| Program Directs to Machine Edit | Link -> "Edit Machine Details" | Redirect -> Machines - Edit |
| User Edits Machine Details, Machine Details Changes Saved to Database | Submit | Redirect -> Machines - Details |
| Program Directs to Add New Technician  | Link -> "Add New Technician" | Redirect -> Technicians - Create |
| User Inputs New Technician Info, Technician Added to Database | Submit | Redirect -> Machines - Details |
| Program Directs to Technician Details | Link -> "Technician Details" | Redirect -> Technicians - Details |
| Program Directs to Remove Technician | Link -> "Remove Technician" | Redirect -> Technicians - Delete
| User Removes Technician, Technician Removed from Database | Submit | Redirect -> Machines - Details |
| Program Directs to Technician Edit | Link -> "Edit Technician Details" | Redirect -> Technician - Edit |
| User Edits Technician Details, Technician Details Changes Saved to Database | Submit | Redirect -> Technicians - Details |
| Program Directs to Add Machine Qualifications | Link -> "Add Machine Qualifications" | Redirect -> Machine - Add Qualifications |
| User Adds Qualifications to Machine, Machine Qualifications Added to Database | Submit | Redirect -> Machine Details |
| Program Directs to Add Technician Qualifications | Link -> "Add Technician Qualifications" | Redirect -> Technician - Add Qualifications |
| User Adds Qualifications to Technician, Technician Qualifications Added to Database | Submit | Redirect -> Technician Details |

## _Technologies Used_
C#  
.NETCore  
Entity Framework Core  
MySql Server

## _Installation Instructions_
* Project Cloning instructions.
  1. Open Git Bash.
  2. Change the current working directory to the location where you would like to clone the repository.
  3. Type "git clone" followed by "(https://github.com/JohnNilsOlson/Factory.Solution)" (without quotes) and hit enter.
  4. Open directory with code editor of choice.
  5. In the terminal, change working directory to ./Factory.
  6. Type "dotnet restore".
  7. Type "dotnet run".

* Project Download instructions.
  1. Visit "(https://github.com/JohnNilsOlson/Factory.Solution)".
  2. Click the green "code" button and download zip file of project.
  3. Extract zip file to directory of choice.
  4. Open project directory in code editor of choice.

* Instructions to Set Up Database with MySql Workbench (Required to Run WebApp).
  1. Open MySql Workbench.
  2. Click on the "administration" tab.
  3. Click on "data import/restore".
  4. In Import Options, check "Import From Self-Contained File".
  5. Navigate to the project directory and select "johnnils_olson.sql" from the root directory.
  6. Under "Default Schema to be Imported To", click the "New" button.
  7. Enter "johnnils_olson" in the pop-up prompt and click "OK".
  8. Click "Start Import".
  9. Click on the "schemas" tab, right-click and selected "Refresh All".

* SQL Schema Query

  DROP DATABASE IF EXISTS `johnnils_olson`;
  CREATE DATABASE `johnnils_olson`;

  USE `johnnils_olson`;

  CREATE TABLE `machines` (
    `MachineId` int NOT NULL AUTO_INCREMENT,
    `MachineName` varchar(255) NOT NULL,
  PRIMARY KEY (`MachineId`)

  CREATE TABLE `technicians` (
    `TechnicianId` int NOT NULL AUTO_INCREMENT,
    `TechnicianName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`TechnicianId`)

  CREATE TABLE `qualifications` (
    `QualificationId` int NOT NULL AUTO_INCREMENT,
    `MachineId` int NOT NULL,
    `TechnicianId` int NOT NULL
  PRIMARY KEY (`QualificationId`)

* Instructions to Run WebApp
  1. In the terminal, change working directory to ./Factory.
  2. Type "dotnet restore".
  3. Type "dotnet run".

## _Bugs_
No known issues.

## _Contact Information_
JohnNils Olson - johnnils@gmail.com  

## _License_
The [MIT] license.
Copyright (c) 2020 JohnNils Olson