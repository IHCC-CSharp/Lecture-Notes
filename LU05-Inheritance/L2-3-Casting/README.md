## Casting

## Creating the Project

```bash
# Create folder and sln
mkdir SwitchingObjectTypes
cd SwitchingObjectTypes
dotnet new sln
dotnet new gitignore

# Create projects and add to solution
dotnet new console -o EmployeeConsole
dotnet new classlib -o EmployeeLibrary
dotnet sln add EmployeeConsole # It might auto add the class library, if not add it manually
dotnet sln add EmployeeLibrary

# Add reference Class Library to Console App
dotnet add EmployeeConsole reference EmployeeLibrary
```

## Midterm Review

- [Please Reference the Midterm Study Guide](../../Review/Study-Guide/Study-Guide.md)
- [Please Reference the Cheat Sheet](../../Review/CheatSheet/CheatSheet.md)
