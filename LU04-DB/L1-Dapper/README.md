# Dapper

- [Slideshow](slideshow/slides.html)
- [SQLite Docs](https://sqlite.org/)
- [Dapper Docs](https://www.learndapper.com/)

## Create the Example

Todays Example is a simple console app.
So we can focus on the Dapper.
Tomorrow we will build a full API.

```bash
dotnet new console -n DapperExample
cd DapperExample
dotnet add package Microsoft.Data.Sqlite
dotnet add package Dapper
```

## Finishing the Example

- Create the Model
- Build out Program.cs
- Look at the `.db` file

## Test SQLite Queries

In a web browser you can use [this](https://sqliteonline.com/) to test SQLite queries.

## Viewing the Database

1. You can use the [DB Browser for SQLite](https://sqlitebrowser.org/) to view the database file.
2. Or you can use [this](https://marketplace.visualstudio.com/items?itemName=qwtel.sqlite-viewer) vscode extension to view the database file.
3. Or in JetBrains Rider there is a built-in database viewer. Just click on the `.db` file and it will open the database viewer.
