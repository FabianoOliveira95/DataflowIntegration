# Dataflow Integration

This project contains the development of two applications that communicate synchronously using technologies such as SignalR and HTTP Requests. 

## Features

- Application 1 is a Windows Forms programm that enables users to send and receive text messages from a web application running locally.
- Application 2 is a ASP NET Core web application that enables users to receive text messages from Application 1 and send messages to multiple Application 1's instances that runs locally.

## Technologies

- Application 1
  - Windows Forms.
  - .NET 7.0.
  - SignalR for synchronous communication between client and server.
- Application 2
  - ASPNET Core MVC.
  - .NET 7.0.
  - SignalR.
- Unit Tests
  - .NET 7.0 
  - xUnit
  - SignalR.
 
## Setup

- Clone the repository: https://github.com/FabianoOliveira95/DataflowIntegration
- Use Microsoft Visual Studio 2022 to open the project.
- Install .NET 7.0 if it is not already installed

## Run Applications

- Set the Application2 project as the Startup Project in Visual Studio and click button Run.
- Run one or more instances of Application 1 on the path: DataflowIntegration\Application1\bin\Release\net7.0-windows\Application1.exe
