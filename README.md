# Running the SmartELK Project

## Prerequisites:

* .NET 8.0 SDK
* Docker
* Visual Studio 2022 or Rider (recommended)

## Solution Structure:

The solution consists of four projects:

  1. SmartELK.API: The main API project.
  2. SmartELK.Domain: Contains domain logic.
  3. SmartELK.Infrastructure: Handles data access and migrations.
  4. SmartELK.Test: Contains unit tests for the solution.

## Steps:

1. Clone the Project:
    * Clone the SmartELK project from the repository to your local machine.
    * Open the project in your preferred editor, preferably Rider or Visual Studio 2022.
      
2. Build the Project:
    * Build the project in your editor to ensure all dependencies are resolved.
      
3. Run Docker Compose:
    * Navigate to the root directory of the project in your command line interface.
    * Run the following command to set up Elasticsearch and PostgreSQL servers using Docker Compose:Copy code  docker-compose up
  
4. Check SmartELKSearch Service:
    * Ensure that the SmartELKSearch service is building successfully without any errors.
      
5. Execute EF Core Database Migration:
    * Open a command line interface and navigate to the SmartELK.API directory or set up the project as the startup project in your editor.
    * Run the following command to execute EF Core database migration files:cssCopy code  dotnet ef database update --project SmartELK.Infrastructure/SmartELK.Infrastructure.csproj --startup-project SmartELK.API/SmartELK.API.csproj --context SmartELK.Infrastructure.Database.ProductsContext --configuration Debug --verbose 20240604160729_Initial
       
    * Ensure that the migration process completes successfully without any errors.
      
6. Run Sync Job:
    * The sync job is automatically started when you run the SmartELK.API project.
    * Ensure that the SmartELK.API project is set as the startup project in your IDE.
    * Start the SmartELK.API project either from your editor or by running the following command in the command line interface:arduinoCopy code  dotnet run --project SmartELK.API/SmartELK.API.csproj
      
7. Access Swagger UI:
    * Once the SmartELK.API project is running, you can access the Swagger UI to interact with the API endpoints.
    * Open a web browser and navigate to the following URL:bashCopy code  http://localhost:5128/swagger/index.html  
    * Swagger UI provides a beautiful interface to test the API endpoints. You can explore the available endpoints, submit requests, and view responses directly within the browser.
  
    * Sample Request:
  
   curl -X 'GET' \
  'http://localhost:5128/Product/search?query=Authentic&category=Confections&minPrice=28&maxPrice=45' \
  -H 'accept: */*'

