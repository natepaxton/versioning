# Function and Stored Procedure Versioning Strategy

[Creating a new function or stored procedure](#creating-a-new-function-or-stored-procedure)  
[Creating a new version of an existing function or stored procedure](#creating-a-new-version-of-an-existing-function-or-stored-procedure)  
[Pitfalls](#pitfalls)

### Creating a new function or stored procedure

1.  Create a folder for housing SQL scripts in your project, if one does not exist.
        In this example, the folder is StoredProcedures
2.  Add a folder to hold the versions of your new script.  In this example, the folder
    is WidgetsQuery
3. Within the folder for your script, create your procedure file with appended with _V00.
4. Copy your V00 file and paste it into the same folder, removing the V00 and replacing it
   with Master
5. Use ```dotnet ef migrations add``` to add a migrator to the project.
6. Within the Up method of the migrator, use the SqlHelper method to find and execute
   the V00 script.  No down method will be necessary:
   ```
   public partial class WidgetsQuery : Migration
   {
       /// <inheritdoc />
       protected override void Up(MigrationBuilder migrationBuilder)
       {
           var sql = SqlHelpers.GetEmbeddedResource("usp_WidgetsQuery_V00.sql");
           migrationBuilder.Sql(sql);
       }

       /// <inheritdoc />
       protected override void Down(MigrationBuilder migrationBuilder)
       {
           return;
       }
   }
   ```
7. If it isn't already present, add an ```ItemGroup``` in ```.csproj``` to include the SQL scripts:
   ```
   <ItemGroup>
     <EmbeddedResource Include="StoredProcedures\*\*.sql" />
   </ItemGroup>
   ```
8. Use ```dotnet ef database update``` to run migrations
9. Check in all files, including both Master and V00.

### Creating a new version of an existing function or stored procedure
   *Copy and paste can make short work of many steps in this workflow*
   
1.  Within the folder for the function being updated, copy the most recent version and paste
    it into the same folder, renaming to the version you want to create.
2. Within the newly created query file, update the comment section to reflect the changes to be made:
   ```
   ------------------------------------------------------------------------------------------------------------------------
   --usp_WidgetsQuery
   --06/10/2025 - NPaxton - Created Initial stored procedure
   --06/10/2025 - NPaxton - Added Shape to query return
   --06/10/2025 - NPaxton - Added IsActive where clause
   --06/11/2025 - NPaxton - Added Id to query return
   ------------------------------------------------------------------------------------------------------------------------
   ```
3.  Make changes to the logic in the SQL script and test locally
4. When satisfied with changes, select all of the new version and copy.  Paste the new version
   into the current Master file, overwriting the existing content.
5. Use ```dotnet ef add migration``` to add a migrator to the project
6. Within the migrator, use the SqlHelper method to find and execute the new version in the ```Up``` method
   and do the same for the current version in the ```Down``` method: 
   ```
   public partial class WidgetsQueryShape : Migration
   {
       /// <inheritdoc />
       protected override void Up(MigrationBuilder migrationBuilder)
       {
           var sql = SqlHelpers.GetEmbeddedResource("usp_WidgetsQuery_V01.sql");
           migrationBuilder.Sql(sql);
       }

       /// <inheritdoc />
       protected override void Down(MigrationBuilder migrationBuilder)
       {
           var sql = SqlHelpers.GetEmbeddedResource("usp_WidgetsQuery_V00.sql");
           migrationBuilder.Sql(sql);
       }
   }
   ```
7.  Use ```dotnet ef database update``` to run migrations locally
8. Check in all files.  During PR, the Master file can now be used to see the diff between
   versions for easier review.

### Pitfalls
- The SqlHelper method will look for file names containing the provided string.  You must include the 
  version number in the search string to avoid returning a different version of the procedure
- You will forget to update the master at some point.