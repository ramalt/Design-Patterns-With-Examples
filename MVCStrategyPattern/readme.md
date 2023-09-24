
  # Strategy Pattern With Different Database Operations

  ![schema](/Assets/apptrail.gif "app")

 This repository contains implementing the strategy design pattern approach 
 to save data with different database options in an application.

 ## Details

This application presents manage the products with MVC.  User must authenticate to see their products list. Uses **Entity Framework Identity** for authentication and authorization. 
- Users database selection setting,(**SQLServer, MongoDB** etc.) keep in the database as **UserClaims**. 
- Product management actions  are made according user databaseType settings. 
- For Example, User chooses SQLServer in settings page and create, update, delete operations made for this SQServer database. 
- If user selects another database from the settings menu, he can only perform operations for that database. **Strategy pattern** allows the user chose databvse choose.

## shema

![schema](/Assets/schema.png "schema")


## Technologies and approaches
- **Entity Framework ORM** for manage contexts.
- **Entity Framework Identity** for user **JWT** authhentication and authorization.
- **Repository Pattern** absctraction to seperated logic actions.
- **Strategy Pattern** for different database selection setting for user with different operations.


