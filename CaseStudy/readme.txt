This web app was designed in Visual Studio 2019 using the ASP.NET 3.0 Framework.

This application requires the following packages from the NuGet package manager:
> Microsoft Entity Framework Core
> Microsoft.EntityFrameworkCore.SqlServer
> Microsoft.EntityFrameworkCore.Tools
These packages should automatically download once the project is opened.

Once the project is opened use the Package Manager Console through tools>NuGet Package Manager
Enter the following commands into the console:

EntityFrameworkCore\Add-Migration InitialCreate -Context AppUserContext
EntityFrameworkCore\Add-Migration InitialCreate -Context CardContext

EntityFrameworkCore\Update-Database -Context AppUserContext
EntityFrameworkCore\Update-Database -Context CardContext



Once the application is launched the user will be sent to the home page and can select the large 'CreditCard App'
link. Once there they can fill out the webform to see which credit cards they are eligible for.
If they are over 18 their data will be saved to the users database.

From there they can view more information about each of the cards available to them.

Using the 'Admin Panel' shortcut will take the user to a frontend of the users database which they can then 
modify if desired.

There are two sql databases that handle the data within this application, one for user data and one for credit card
data.

