# Technical Discussion

## Author

Peter Akala

## Software

Operating System: Linux Mint 19.2 Cinnamon

Framework: .NET Core 2.2

Code Editor: Visual Studio Code v1.38.1

## Overview

I have never created a web API endpoint of any kind before so I was unfamiliar with the interface. I read the overview and technical details of .NET Core Web API on Microsoft's documentation site.

Although I sometimes found the documentation to be hard to understand or leaving out certain important details, I was able to figure out how to create all of the different components (Models, Controllers, Interfaces, Services) and setup the necessary routes to implement the endpoints.

Below, I will discuss various aspects of the code I wrote.

## Triangle.cs

The Triangle class was the first Model class I created for the program. I decided to have separate Triangle objects that make up a Triangle Board to make it easier to keep track of position and coordinates. 

The Triangle class is pretty straightforward, consisting of three pairs of coordinates representing the three vertex coordinates for a triangle. I used the same vertex locations as shown in the Cherwell documentation with vertex 1 being at the right angle of the triangle, vertex 2 located top-left, and vertex 3 located at the bottom-right of the triangle.

I declared the vertices of the Triangle class as getter-only auto-implemented properties since I had no reason to ever change the vertex coordinates once they were created.

Another method of the Triangle class includes a FitCoordinates method which checks whether or not given coordinates fit the coordinates of the Triangle object itself and thus determines the position of the triangle.

The last method of the Triangle class was a ToString() method which I never managed to use in early testing because Console.WriteLine() does not output to the terminal when using a netcore webapi project. I plan on learning how to setup logging or some other kind of terminal output as it is always very helpful when coding, especially when doing something new like this project.

## TriangleBoard.cs

The next model class I created was TriangleBoard which holds all of the triangle objects for the triangle board.

The TriangleBoard has one getter-only auto-implemented property consisting of a dictionary with the row and column position as the key and a Triangle object specific to that position as the value.

The constructor for the TriangleBoard runs the algorithm that creates the Triangle objects that make up the board and sets both the row/column position and the vertices for each triangle. I used foreach loops instead of condition-controlled for loops in order to prevent coding mistakes where I allow the loop to go out of bounds of the index.

I assumed that (0,0) on the triangle board is the upper-left most point where A1 is located and (60,60) is the bottom-right most point where F12 is located. I used the standard way of viewing pixels in the "computer world" so the pixel values for the y-axis increase as you move down.

The TriangleBoard class has two primary methods, the CalculateCoordinates method which when given a row-column position, returns the Triangle object located at that position.

The other method is CalculatePosition which returns the row-column position given three vertex coordinates. The CalculatePosition method passes the coordinate arguments to the FitCoordinates method for each Triangle object to determine whether it found the correct triangle.

Lastly, it is important to note that the TriangleBoard class implements the ITriangleBoard interface which I actually created after the TriangleBoard once I understood how to actually implement an endpoint.

## ITriangleBoard.cs

In order to create a web API endpoint you need to create an interface for it so that a controller can use the Models that were also created for use by the endpoint.

Creating this class was pretty simple, I just copied the declarations for the fields and important methods to the interface and removed the unneccessary access modifiers.

## Startup.cs

After creating the models and the interface, I needed to actually add a service to the program in order to create the endpoint. The main documentation on Microsoft's website about endpoints shows an example using a database. I thought using a database for this challenge would be overkill and make things much harder than they needed to be.

I knew that I just wanted to create a single TriangleBoard object that would manage everything required of the program. After doing a lot of reading on the MS site I finally found the link to the documentation on dependency injection which showed me how to setup a Singleton service that would allow my TriangleBoard model to substitute for a database context.

I added one line of code to Startup.cs to allow me to create a Controller class with a single TriangleBoard object as a field.

## TriangleBoardController.cs

TriangleBoardController is the controller for my project. It is the place where a single TriangleBoard object is instantiated and makes its method calls. This controller is also where I actually setup my endpoint routes and URL paths.

The controller class has one field, the single TriangleBoard object which gets passed in from the service I created in Startup.cs. With the TriangleBoard object created, I now just needed to setup the routes and URL paths to perform the work when a request is made to the endpoints.

Once again I needed to thoroughly read the documentation to understand how to define my routes and return the correct results. From the documentation I also learned how to accept and use arguments from the URL.

After managing to get the endpoints working and returning the correct data I moved on to preventing errors and returning consistent data. Before I got to this point, each of the routes would return a different data type as a response. One would return a string, another would return a Triangle object. I prefer returning a JSON object that can be easily parsed to determine what data was received and how to use it.

Reading the documentation I learned about ActionResult and IActionResult which allow me to return any type. I then used the methods Ok and NotFound from the ControllerBase class to create and return JSON objects as well as proper HTTP response status codes. Ok is very easy to use because I just pass it an anonymous object of the data I want to return and Ok makes it into a JSON object.

The last thing I did for the TriangleBoardController was to implement data validation and prevent any errors that would crash the program.

If the TriangleBoard methods are given bad data they will return null, but I don't want to return null as an endpoint response. I want the return to be what one might typically expect with a web app, "Not Found" and a response code. I wrote code that checked for null and then used the NotFound from ControllerBase to return a 404 response status and an error message inside of a JSON object.

To prevent crashing from trying to parse a string into an invalid integer I added TryParse checking and made separate error messages indicating which arguments are incorrect.

My program returns an appropriate error response, an error message in a JSON object and HTTP status code, and does not crash.

## Final Reflection

It was a challenging exercise since I have never done anything with web API endpoints before, but I was able to figure out how everything worked and implement a C# web API endpoint.

The most difficult part of this program was understanding how to actually implement a web API endpoint using .NET Core. I was able to use the documentation and some code examples from Microsoft to figure out how to do this, even though I was using a Singleton and not the database context as shown in the main example.

Now that I have finished the project, I understand the power and benefits of using web API endpoints and it is something that I will definitely be learning more about.