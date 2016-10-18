# Community Tools
This is a sample application using Angular2 RC3 and WebAPI2 in a microservice pattern. This project is used as a learning platform for me to exercise new skills and techniques, and play with new technology.

## How To Use
So.... this is my attempt at using a Micro Service pattern. Will try and explain the requirements below

### Database maintenance
Use the "CommunityTools.Database.MigrationTool" project, changing the app.config connection string to your own database. You will notice this uses a different database per microservice. That is not necessary, customise to your liking. The pattern should be easy to follow. I find it easiest to run in debug mode after changing the connection string to the appropriate database server. The ".sql" files need to be embedded resources, just follow the naming pattern as they will run in order. It will only ever run the script once, table "SchemaVersions" records scripts run in each databsae.

### Services
An IIS container will be required for each of the service end points. These currently are:
* CommunityTools.Service.Forums
* CommunityTools.Service.Users

### Proxy
An IIS container will be required for the Proxy "CommunityTools.Proxy". You will need to update the "CommunityTools.Common" project "ApiEndPoints.cs" to tell the proxy the url's for each of the service end points. Config transforms are setup so you can deploy to different targets and have this transform if required.

### Web
This is an Angular2 app using WebPack. To play locally, you will need node installed. you should just be able to:
* Edit the src/app/config/appSettings.ts file replacing the proxy urls with the ones setup above.
* npm install
* npm run start
* Browse to http://localhost:4000

Bit to it, but it is kinda cool. Very basic so far. Some other features:

* Has oAuth2 authentication using FlexProvider
* Uses AutoFac DI
* Uses Repository pattern with Entity Framework code first model
* Uses AutoMapper