# Trainee Tracker Application

The Trainee Tracker Application is an ASP.NET MVC application that allows trainees to create, read, update, and delete their tracker entries. Trainers can view all entries from all trainees, but they are restricted from creating, editing, or deleting entries. Additionally, an admin user has the authority to access a list of all users. We plan to extend the functionality of the admin role to be able to manage users and their roles.
<br></br>

## Installation
1. Clone the repository: git clone https://github.com/fuzzylogician27/traineetrackerwebapp.git

2. Open the project in Visual Studio.

3. Build the solution to restore the NuGet packages.
<br></br>

## Configuration
1. Open the Web.config file in the root directory.

2. Modify the connection string to point to your database.

3. Adjust other configuration settings as required.
<br></br>

## Database Setup
1. Scaffold the database using a Model First Migration
2. Add any initial data using a SQL Query
<br></br>

## Usage
1. Launch the application in Visual Studio or deploy it to a web server.
2. Setup your initial Admin users so they can modify the roles of other users
3. Log in using your credentials.
<br></br>

## Trainee Functionality
- Create Entry: Trainees can create new tracker entries by providing relevant information such as date, time, description, and any other required fields.

- Read Entry: Trainees can view their own tracker entries, displaying the details of each entry, including date, time, description, and other relevant information.

- Update Entry: Trainees can modify their existing tracker entries, updating the information as needed.

- Delete Entry: Trainees can delete their own tracker entries if they are no longer required.

- Filter Entries: Trainees can filter their entries based on the title of each entry.
<br></br>

## Trainer Functionality
- Read Entry: Trainers can view all tracker entries from all trainees, but they cannot create, edit, or delete entries.

- Filter Entries: Trainers can filter their trainees entries based on the title of each entry.
<br></br>

## Admin Functionality
- User Management: Admin users have access to an admin page, where they can view a list of all users registered in the system. 

- *Change User Role (Coming soon): We intend for the admin to be able to edit the roles of other users.*
<br></br>

## Service Layer
The Trainee Tracker Application follows a layered architecture and incorporates a service layer to encapsulate business logic and promote separation of concerns. It contains the core application logic, such as validation, data manipulation, and complex operations. By implementing a service layer, the application achieves better modularity, maintainability, and testability. The service layer allows for easier reuse of business logic across different controllers and promotes a more structured and organized codebase.
<br></br>

## Dependency Injection Container
The Trainee Tracker Application uses a dependency injection (DI) container to manage the dependencies between its components. DI containers  inject dependencies from outside sources rather than creating them internally. This promotes modularity, testability, and flexibility. The application uses a DI container to inject the IService, IMapper and TraineeTrackerContext to wherever they are needed.
<br></br>

## Technologies Used
### ASP.NET MVC

### C#

### Entity Framework

### SQL Server

### HTML & CSS
<br>

## Acknowledgements
We would like to thank the following resources and contributors:

ASP.NET MVC Documentation

Entity Framework Documentation

Stack Overflow community for providing answers to various questions.

Thanks to Peter and Nish for teaching, supporting and guiding throughout the lessons and project

## Credit
This project was developed by Tech211 Team 2.
Thank you for your collective efforts in producing this application.

Thank you Patrick for your work in implementing the service layer and IService, working on the login/register functionality and helping to make the isReviewed functionality work correctly.

Thank you Jacob for your work implementing the controller, your research on cshtml files for the create function and for your work ensuring the controller is well tested using Moq.

Thank you Vlad for your work creating the View Models, your implementation of access roles and your work on the implementation of the controller.

Thank you Andrew for your work implementing the SeedData class, implementing the controller, your help in ensuring the controller was well tested and for your work on the login/register functionality.

Thank you Talal for your research on cshtml files and for implementing the dropdown function in create. Also for your work implementing the controller, and for implementing the filter function.

Thank you Ahmed for your work on the service layer, and for your work on the login/register functionality. Also for your work in reviewing the code and helping to debug.

Thank you Danielle for your work on the SeedData class, your help on implementing the service layer and your help in ensuring the controller is tested.

Thank you to all the devs for the initial setup of the project, the styling of the application and for helping to solve exceptions.

