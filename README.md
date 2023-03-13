# ambient-weather-backend
backend server for making requests to ambientweather api, and logging to database, querying db, etc

# installation/config
## install
```
$ cd ~
$ git clone https://github.com/nullcoalescence/ambient-weather-backend
```

## config
### dev environment
- create a json file outside of project directory and apply correct file permissions to prevent viewing
- file should look like:
```
{
	"application_key": "",
	"api_key": "",
	"mac_address": ""
}
```
- fill in values
- edit `Constants.cs` to point to this json file
- compile project

### prod environment
- set environment variables for
	- `application_key`
	- `api_key`
	- `mac_address`
- @todo: need more info here

## build
```
$ cd ~/ambient-weather-backend
$ dotnet build
```

## todo
- move some configuration (such as AmbientWeatherConfig file for dev environments) to .appsettings file
- hosting instructions (target docker might be the best here for linux hosts?)
- lots of other stuff
	- add powershell scripts for making quick requests
	- better logging
	- log to db
	- add postman collection to repo

## documentation
https://ambientweather.docs.apiary.io/