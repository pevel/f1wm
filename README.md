## f1wm ![Travis CI build status](https://travis-ci.org/pevel/f1wm.svg?branch=master)

Extracting web API of [f1wm.pl](https://f1wm.pl), piece by piece. That is a rewrite from PHP-based site to .NET core web API.

## setting up local environment

In order to build the application, besides [.NET Core SDK 2.2](https://www.microsoft.com/net/download), you need to install [Ruby](https://www.ruby-lang.org/en/downloads/) on your machine.

In order to run the API locally or run integration tests, you need to setup [User Secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?tabs=visual-studio) first.
User secrets include connection string information. To populate it, run (in F1WM project directory):  
`dotnet user-secrets set ConnectionStrings:DefaultConnectionString "server=<server>;user id=<username>;password=<password>;port=<port>;database=<database>;charset=<charset>"`  
`dotnet user-secrets set ConnectionStrings:IdentityConnectionString "server=<server>;user id=<username>;password=<password>;port=<port>;database=<database>;charset=<charset>"`  
`dotnet user-secrets set JwtIssuer "<jwt_issuer>"`  
`dotnet user-secrets set JwtExpireSeconds "<jwt_expire_seconds>"`  
`dotnet user-secrets set JwtKey "<jwt_key>"`  
Alternatively you can use environment variables with the same keys as User Secrets.
