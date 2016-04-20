#HttpTest for Rsc.HttpClient

This is a little test application for the Rsc.HttpClient library.
It consists of a console application that spins up a number of threads and then makes multiple simultaneous Http requests to a second application, a simple nodejs application.

##To run using Docker

If you have it installed alread, the easiest way of running this is to use docker-compose:-

```bash
$ docker-compose up
```

##To run from Visual or Xamarin Studio

1. You will need nodejs installed, or have some other web server listening on port 3000.

To run the node app:-

```bash
$ cd node
$ npm install
$ node app.js
```

2. Edit the _url field of the WebRequester.cs class to be "http://localhost:3000".

3. Build and run the HttpTest.sln as you would normally do.

##Is it working?

The expected output is to see request numbers in the HttpTest console.
In the node application, it will print out each unique correlation id as it comes.
