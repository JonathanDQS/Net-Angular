## Important BE

The tables needed for the database were generated automatically thanks to the migrations made possible by the `Entity Framework`.

Therefore to run this project you need a SQL Server instance running in `localhost` with a DB instance name `JDQS` and password `yourStrong(!)Password` as stated in the `appsetting.json` file. 

If you prefer another configuration please modify the connection string as needed.

When you are happy with your configurations please run the `update-database` command in the Package Manager Console of Visual Studio once you have the NuGet packages for this project already installed.

## Important FE

Remember to connect to the appropriate BE by replacing the `CONFIGURATION` properties in the `constants.ts` file
