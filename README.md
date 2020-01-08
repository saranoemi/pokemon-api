# Pokemon API

Pokemon API is a consumption-only RESTful API. Given a Pokemon name, the API returns its Shakespearean description.   

## Instructions

### Getting started

The API has been developed using Visual Studio 2019 and targeting .NET Core 3.1.

To start using it, download the _Portable_ folder and run the executable _Pokemon.API.exe_. 
The content of this folder has been created publishing the application with the command:

    dotnet publish -c Release -r win-x64 --self-contained

This tells the .NET Core SDK that we want to release as self contained, and it’s for Windows. It means that everything that the app requires to run is deployed right there in the _Portable_ folder rather than having to install the .NET Core runtime on the target machine.

While the host application is running, you can consume the API calling the endpoint:

    http://localhost:5000/pokemon/{name}

A simple way to play with the API is through the Swagger UI, which allows you to visualize and interact with the API’s resources directly in your browser.

### Acknowledgements

The Pokemon descriptions are obtained by querying the Pokéapi API: https://pokeapi.co/.

The Shakespearean translation comes from the API: https://funtranslations.com/api/shakespeare.

### Usage examples

#### Example a

    http://localhost:5000/Pokemon/pikachu

Expected output:

    CODE: 200
	RESPONSE BODY: 
	
	{
		"name": "pikachu",
		"description": "Its nature is to store up electricity. Forests whence aeries of Pikachu liveth art dangerous,  since the trees art so oft did strike by lightning."
	}

#### Example b

    http://localhost:5000/Pokemon/blablabla

Expected output:

    CODE: 404
	RESPONSE BODY: Not Found

## My implementation

Since the purpose of the project was to provide a ready to production solution, during the development I tried to keep in mind some characteristics of a good architecture:

- It is simple or at least only as complex as it is necessary. 
- It is understandable and flexible, in the sense that it is easy to adapt the system to meet changing requirements.
- It is testable and maintanable.

The **Pokemon.API** project contains the API and all the core functionalities, such as the object model representing the JSON object to be returned, the data transfer objects to get the response from the external APIs, as well as the required services. Given the simplicity of the application, I found convenient to keep everything in a single project, dividing the logical components into different sub folders. In a more complicated system, it may be convenient instead having separate projects for the services and the DTOs.

The application makes extensive use of the dependency injection (DI) software design pattern, which is a technique for achieving Inversion of Control (IoC) between classes and their dependencies. ASP.NET supports the dependency injection pattern via the registration of the app's services in the _Startup_ class. This provides several benefits, such as we can replace an implementation without affecting the abstraction that it depends upon and we can test the application mocking the dependencies.

Integration tests for the API and unit tests both for the API and the services have been implemented in the project **Pokemon.Tests**.


