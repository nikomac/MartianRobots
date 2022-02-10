# MartianRobots

Web Api build using .net core 5, the persistence is done using MySql-EF and deployed in Docker.
It is running now my private server using an external DB from a free hosting site (so please be gentle with the limited connection it offers).
[MartianRobots API](martianrobots.nikomac.duckdns.org/swagger)
## How to run

You may deploy it locally using **Docker** or with a more traditional approach using **ISS**.

If **needed** you can use a migration file to create the DB in any other server you need.

 1. Change the  `ConnectionStrings` it is defined in `appsettings.json` inside `MartianRobots.Api` project
 2. Open the `Package Manager Console` and set the default project to `MartianRobots.Repository`
 3. Execute `update-database` to create all the necessary tables to run this app.

**CAUTION** If deployed locally using Docker remember it and you have the DB locally as well, the docker app will not have access to the DB using `localhost` routes.

The Web Api can be tested using swagger, it contains some examples and descriptions of the endpoints.
Or using this example to run the a mission:

    curl -X POST "hostname:port/Mission" -H  "accept: */*" -H  "Content-Type: application/json" -d "\"5 3\1 1 E\RFRFRFRF\3 2 N\FRRFLLFFRRFLL\0 3 W\LLFFFRFLFL\""
