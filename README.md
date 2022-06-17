# AirportApplication #
A web application using ASP.NET Core and Entity Framework

<h3>What is the AirportApplication?</h3>

<p>
    AirportApplication is a web application simulating a system of booking a flight in an airport.
</p>

<h3>What is the Tech Stack?</h3>

<ul>
    <li>Rider as a IDE</li>
    <li>ASP.NET Core for backend and frontend</li>
    <li>Entity Framework as an ORM</li>
    <li>SQLite as a database</li>
    <li>StarUML for class diagram design</li>
    <li>Swagger for API documentation</li>
</ul>

<h3>What are the models?</h3>

<p>
    Project consists of 5 models:
</p>

<ul>
    <li>Country</li>
    <li>City</li>
    <li>Airport</li>
    <li>Seat</li>
    <li>Flight</li>
</ul>

<h3>What views are included?</h3>

<p>
    Project contains the following views:
</p>

<p>
    For any model there is a:
</p>

<ul>
    <li>Create view, corresponding to HTTP POST method</li>
    <li>Delete view, corresponding to HTTP DELETE method</li>
    <li>Details view, corresponding to HTTP GET method executed on specific ID of a resource</li>
    <li>Edit view, corresponding to HTTP PUT method executed on specific ID of a resource</li>
    <li>Index view, corresponding to HTTP GET method. This view also allows redirecting to any of the above views</li>
</ul>
<p>
    Aside from these views there are also more general views, such as:
</p>

<ul>
    <li>Main Page</li>
    <li>Privacy Policy</li>
    <li>General documentation</li>
    <li>API documentation</li>
    <li>Login</li>
    <li>Registration</li>
</ul>

<h3>What is the user allowed to do?</h3>

<p>
    There are 2 types of users: normal and administrative.
</p>

<p>
    A normal user can:
</p>

<ul>
    <li>Book a flight</li>
    <li>View privacy policy</li>
    <li>See general (equivalent to this README file) and API documentation</li>
    <li>Login to an elevated, privileged account</li>
</ul>

<p>
    An administrative user must be logged in and can do everything a normal user can, as well as perform any CRUD operation on any of the models involved.
</p>

<h3>Class Diagram:</h3>
<img alt="Class Diagram" height="461" src="C:\Users\Piotr\RiderProjects\AirportApplication\AirportApplication\wwwroot\images\ClassDiagram.jpg" width="387"/>