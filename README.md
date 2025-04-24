# SaqibAPIs

- Open in the latest version of Visual Studio Community 2022. 
- API project should be set as Startup project
- Check API -> appsettings.json. Connectionstrings -> SqlServer. Change it according to your Sql server.
- Application - AI Chat - Gpt4SllApiCaller.cs file. parameters like url, model, max tokens and temperature, change as required.

# Requirements

- Sql server instance and database
- Gpt4all with API support - default http://localhost:4891/v1/chat/completions. This should match with Gpt4all

# Create Database 

- Open Project and then Package Manager Console from Visual Studio
- Run command "update-database". Project already has migration.

- Another way is to restore from backup

# How to run locally

- Open project in Visual Studio 2022 and run directly from VS.

# Use API without client app

- Run the project from Visual Studio.
- Open an API browser/tester tool like Postman.
- Add a new request like below

- url: https://localhost:7181/api/chat
- request type: post
- body - raw - json format e.g.

{
    "personId": 11,
    "message": "can you tell me which subjects he should study in next semester?"
}

