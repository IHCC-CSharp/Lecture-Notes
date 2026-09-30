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

- Show students number of questions.
- Show students the number of points and percentage of their total grade the final is.
- Explain that coding is a skill that can not be crammed for in an afternoon of staying.
    - If **you** practiced coding doing the labs this test will be easy.
    - If you **outsourced your coding skills to AI**, this test will be difficult.
- [Please Reference the Cheat Sheet](https://www.dotnetperls.com/category_c)

## Demo

If we have class time show off the Demo.

<!-- TODO: Create full stack example with a in memory database with a front end. -->
<!-- Something fun not CRUD -->
