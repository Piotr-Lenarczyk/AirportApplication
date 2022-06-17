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
    <li>Create view, corresponding to HTTP POST method<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Create.png"></img></li>
    <li>Delete view, corresponding to HTTP DELETE method<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Remove.png"></img></li>
    <li>Details view, corresponding to HTTP GET method executed on specific ID of a resource<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Details.png"></img></li>
    <li>Edit view, corresponding to HTTP PUT method executed on specific ID of a resource<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Edit.png"></img></li>
    <li>Index view, corresponding to HTTP GET method. This view also allows redirecting to any of the above views<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Index.png"></img></li>
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
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/MainNormal.png"></img>

<p>
    An administrative user must be logged in and can do everything a normal user can, as well as perform any CRUD operation on any of the models involved.
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/MainAdmin.png"></img>

<h3>Login view</h3>
<p>
    Login view is accessible to any normal user and, upon successful logging in, allows them to elevate their privileges:
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Login.png"></img>

<h3>Registration view</h3>
<p>
    Registration view allow the user to create a new account:
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Register.png"></img>
<p>
    Note that registration form is validated and requires to fulfill following requirements:
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/RegisterFail.png"></img>

<h3>Booking view</h3>
<p>
    Booking view allows the user to book a flight with a specific type of seat. This view is accessible via Flight Index view.
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/Book.png"></img>
<p>
    If the application finds a fitting seat, it will mark it as taken and return details to the user.
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/BookSuccess.png"></img>
<p>
    However, if there is no seat with user-specific designation, the application will not allow the user to book the seat and require to book another flight or seat type:
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/BookFail.png"></img>

<h3>API documentation view</h3>
<p>
    API documentation view is generated with the help of <a href="https://swagger.io/tools/swagger-ui/">Swagger UI</a> and allows testing of any HTTP method on any model.
</p>
<img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/API.png"></img>
<p>
    Specifically, it allows:
</p>
<ul>
    <li>HTTP GET<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/GET.png"></img></li>
    <li>HTTP POST<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/POST.png"></img></li>
    <li>HTTP GET on a single resource<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/GET{id}.png"></img></li>
    <li>HTTP PATCH<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/PATCH.png"></img></li>
    <li>HTTP PUT<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/PUT.png"></img></li>
    <li>HTTP DELETE<br>
        <img src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/DELETE.png"></img></li>
</ul>

<h3>Class Diagram:</h3>
<img alt="Class Diagram" height="461" src="https://github.com/Piotr-Lenarczyk/AirportApplication/blob/main/AirportApplication/wwwroot/images/ClassDiagram.jpg" width="387"/>
