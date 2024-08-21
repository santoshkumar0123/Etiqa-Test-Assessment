"# Etiqa-Test-Assessment" 
Developed the RESTful API to register/delete/update/get for an user
using the http verbs @GET, @POST @PUT, @DELETE
Used sql server RDBMS for the retrival and storing the data for CRUD operation
Used API Key to secure the endpoint. Can be used also JWT Token for authentication on valid user and secure the endpoint by validating the token.
Created Repository Folder to implement the interface for the User List, Register New User, Update user and Delete User
Repository Interface are registered with Dependency Injection
Implemented Code First Approach. Created the User model class and EF Core will create the databse.
Created ApiResponse class to show the return result from the endpoint call
Created PaginatedList class to handle the pagination logic.
Since I don't have any hosting environment like AWS, Heroku. But I know how to deploy in IIS server.
