# Star Wars MQLT Travel Calculator

## Introduction

As part of this code challenge you will be using an API available here: [swapi](https://swapi.co/)

We want to know for all SW star ships, to cover a given distance, how many stops for resupply are required.
The application will take as input a distance in mega lights (MGLT).
The output should be a collection of all the star ships and the total amount of stops required to make the distance between the planets.

All other application details are at your own discretion.

Sample output for 1000000 input:

```console
Enter the Distance to travel : 1000000
Y-wing: 74
Millennium Falcon: 9
Rebel Transport: 11
```

## Requirements

The completed Console Application code should be submitted along with

* Accompanying documentation
* Tests I
* Instructions on the usage of the application.

## Getting Started

Code was written in .NET Core 3.1, using [Autofac](https://github.com/autofac/Autofac) for Dependency Injection.
I wrote a suite of unit tests to verify my changes, I used [Moq](https://github.com/moq/moq) to allow mocking of dependencies such as the API calls.
I have a code coverage of 100% when excluding the Rest Service and the program.cs from the analysis (See bottom of ReadMe for screenshots).

## Explanation

Reviewing the [swapi](https://swapi.co/) I found the contract to retrieve all star ships per the requirement. The result was in the below format.

* **starships**
```json
{
	"count": 37,
	"next": "https://swapi.co/api/starships/?page=2",
	"previous": null,
	"results": [
		{
			"name": "Executor",
			"model": "Executor-class star dreadnought",
			"manufacturer": "Kuat Drive Yards, Fondor Shipyards",
			"cost_in_credits": "1143350000",
			"length": "19000",
			"max_atmosphering_speed": "n/a",
			"crew": "279144",
			"passengers": "38000",
			"cargo_capacity": "250000000",
			"consumables": "6 years",
			"hyperdrive_rating": "2.0",
			"MGLT": "40",
			"starship_class": "Star dreadnought",
			"pilots": [],
			"films": [
				"https://swapi.co/api/films/2/",
				"https://swapi.co/api/films/3/"
			],
			"created": "2014-12-15T12:31:42.547000Z",
			"edited": "2017-04-19T10:56:06.685592Z",
			"url": "https://swapi.co/api/starships/15/"
		}
	]}
```

From the above I discovered the following things
* Count represented the total amount of ships I could recieve
* next was a link to the next page
* The response was a pagination response and I would need to make multipe calls to get all results using the next link.
* The results contains a list of star ships, it maxes out at ten per page
* I would need the name, cargo_capacity and MGLT to calculate the amount of jumps
* That cargo_capacity and MGLT could be "unknown" so I would have to be able to handle this

 ## Calculations

