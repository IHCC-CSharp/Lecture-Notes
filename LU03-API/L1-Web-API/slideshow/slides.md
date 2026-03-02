---
marp: true
theme: gaia
class: invert
paginate: true
backgroundColor: #1e1e1e
---

# Web APIs in C#

By: Luke Matheis

---

## Defining the Web API

An API is a middleman that allows two applications to talk to each other over a network.

* Request: A client asks for something (URL + Method).
* Processing: C# receives the request and runs logic.
* Data: The app fetches or saves information.
* Response: The app sends back a status and data (JSON).

---

## HTTP

We use specific methods to tell the server what we want to do.

* GET: Retrieve a resource.
* POST: Create a new resource.
* PUT: Update an existing resource.
* DELETE: Remove a resource.

These methods map directly to the actions we take inside our C# code.

---

## Entity Framework (EF)?

EF is the standard Object-Relational Mapper (ORM) for .NET.

* Hides the complexity of the database from the developer.
  * You always pay the price of abstraction
* You write C# code (LINQ), and EF generates the SQL for you.
* It manages database "migrations" and tracks changes to objects automatically.

---

## Why are we NOT using EF

* Magic is bad for learning. We want to understand how the database works.
* You can only really appreciate the power of EF after you understand the underlying SQL.
* Sorry but you all need more practice writing SQL.

---

## Dapper

Dapper is known as a **Micro**-ORM. It doesn't try to hide the database.

* You write the SQL yourself.
* Dapper simply maps the results of that SQL to C# objects.
* It is much faster and requires significantly fewer lines of code to set up.

---

## Minimal API

In modern C#, we define the API in a flat, linear way.

1. Create a Builder: Initialize the web server.
2. Register Services: Tell the app about Dapper and SQLite.
3. Map Routes: Connect a URL (like /items) to a block of C# code.
4. Run: Start listening for requests.

---
