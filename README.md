# Band Tracker Management Tool

#### Short Description
This webapp is an Epicodus student project designed to use C# and SQL to be able to create a database of bands and venues and create links between them.

#### Author(s)
Matthew Reyes
## Description
This project will allow users to add bands and venues to a database and create links between them using many-to-many relationships.  The user has the ability to add bands to various venues, never more than once and the same goes for venues.  You can view a venue or a band page and see their associated bands or venues respecitively.  The user also has the ability to delete either the list of all bands/venues or go into the edit page to delete only particular bands/venues.

## Technologies Usedy

* C#
* Nancy and Razor View Engines
* XUnit
* SQL

## Instructions

* Clone the repository
* Open Microsoft SQL Server Management software and run the included .sql file
* In atom open Startup.cs and each test file and update 'Data Source=DESKTOP-7OLC9FT\\SQLEXPRESS' to your own server name.
* In powershell, navigate to the project directory
* In powershell, enter '>dnu restore' and then '>dnx kestrel'.
* Navigate your web browser to http://localhost:5004

##Test Instructions
* Clone the repository
* Open Microsoft SQL Server Management software and run the included .sql file
* In atom open Startup.cs and each test file and update 'Data Source=DESKTOP-7OLC9FT\\SQLEXPRESS' to your own server name.
* In powershell, navigate to the project directory
* In powershell, enter '>dnu restore' and then '>dnx kestrel'.
* In powershell, enter '> dnx test'
* All Tests should pass.

## Known Bugs
* None

## Contacts
<a mailto:"mreyez@gmail.com">Matthew Reyes</a>


### License

Licensed under the MIT License.

&copy;Matthew Reyes
