# MartianRobots

Web Api build using .net core 5, the persistence is done using MySql-EF and deployed in Docker.
It is running now my private server on 2 docker containers, one for the DB and one for the API.

[MartianRobots API](http://nikomac.duckdns.org:5000/swagger)

## How to run

You may deploy it locally using **Docker** or with a more traditional approach using **ISS**.

You will need to use a migration file to create the DB in any other server you need.

 1. Change the  `ConnectionStrings` it is defined in `appsettings.json` inside `MartianRobots.Api` project, to your desired DB
 2. Open the `Package Manager Console` and set the default project to `MartianRobots.Repository`
 3. Execute `update-database` to create all the necessary tables to run this app.

**CAUTION** If deployed locally using Docker remember that if you have the DB locally as well, the docker app will not have access to the DB using `localhost` routes.

The Web Api can be tested using swagger, it contains some examples and descriptions of the endpoints.

    hostname:port/swagger
