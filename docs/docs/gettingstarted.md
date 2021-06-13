# Getting Started

Coming Soon!

## App Settings

Before building or installing GymOS, you will need to ensure that the 
appsettings.json files are setup correctly. 

The server project has a general appsettings.json as well as 
appsettings.Development.json, appsettings.Test.json, and 
appsettings.Production.json. The structure of the file is as follows:

```
{
    "AllowedHosts": "STRING",
    "ConnectionStrings": {
        "DefaultConnection": "STRING"
    },
    "IdentityServer": {
        "Key": {
            "Type": "STRING"
        },
        "Clients": {
            "GymOS.Client": {
                "Profile": "STRING"
            }
        }
    },
    "Logging": {
        "LogLevel": {
            "Default": "STRING",
            "Microsoft": "STRING",
            "Microsoft.Hosting.Lifetime": "STRING"
        }
    },
    "ServerSettings": {
        "EmailServiceSettings": {
            "BaseUrl": "STRING",
            "ApiKey": "STRING",
            "ListId": "STRING"
        },
        "DefaultUser": {
            "Email": "STRING",
            "Password": "STRING",
            "Role": "STRING"
        },
        "DefaultRoles": ["STRING","STRING",...]
    }
}
```

Settings that are shared between environments can go into appsettings.json, 
while settings that are specific to their environment should go into the 
respective appsettings.ENVIRONMENT.json file. 

In order to utilize a specific appsettings file, you must set the 
ASPNETCORE_ENVIRONMENT environment variable to Development, Test, or Production.

Below is a description and example of each setting:

- **AllowedHosts**: Coming soon!
- **ConnectionStrings**: Coming soon!
    - **DefaultConnection**: Coming soon!
- **IdentityServer**: Coming soon!
    - **Key**: Coming soon!
        - **Type**: Coming soon!
    - **Clients**: Coming soon!
- **Logging**: Coming soon!
    - **LogLevel**: Coming soon!
- **ServerSettings**: Coming soon!
    - **EmailServiceSettings**: Coming soon!
        - **BaseUr**: Coming soon!
        - **ApiKey**: Coming soon!
        - **ListId**: Coming soon!
    - **DefaultUser**: Coming soon!
        - **Email**: Coming soon!
        - **Password**: Coming soon!
        - **Role**: Coming soon!
    - **DefaultRoles**: Coming soon!

## Build

You have two options when building GymOS: Visual Studio and the command line.
Regardless of which you choose, you will need to have the following software
installed: 

- Visual Studio C# Build Tools
- .Net 5 SDK

### Visual Studio

Coming Soon!

### Command Line

Coming Soon!

## Installation

Coming Soon!

### Environment 1

Coming Soon!

### Environment 2

Coming Soon!