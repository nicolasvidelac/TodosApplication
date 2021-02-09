# Todo's Application

## About:
This is a simple "To do" notes app, with folder to group those, and if i made it, user login.
This exist because it was requested for a job interview.

### Languages and Tools:
<img align="left" alt="Visual Studio Code" width="26px" src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/visual-studio-code/visual-studio-code.png" />
<img align="left" alt="Visual Studio" width="40px" src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fdevblogs.microsoft.com%2Fvisualstudio%2Fwp-content%2Fuploads%2Fsites%2F4%2F2019%2F01%2Fvisualstudio-1.png&f=1&nofb=1" />
<img align="left" alt="Angular" width="26px" src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/angular/angular.png" />
<img align="left" alt=".NET" width="26px" src="https://raw.githubusercontent.com/github/explore/93d8a67084f94b2a444e510199a6e7622e5b09a3/topics/dotnet/dotnet.png" />
<img align="left" alt="SQL" width="40px" src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fbanner2.cleanpng.com%2F20180526%2Foqt%2Fkisspng-microsoft-sql-server-mysql-database-logo-5b098c6ebad6d7.7316225815273524307653.jpg&f=1&nofb=1" />
<img align="left" alt="Git" width="26px" src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/git/git.png" />
<img align="left" alt="GitHub" width="26px" src="https://raw.githubusercontent.com/github/explore/78df643247d429f6cc873026c0622819ad797942/topics/github/github.png" /> 

<br />

## Requirements:
To be able to run this, you need to install .NET 5.0 SDK, which is available for Windows, Mac OS and several Linux distros:
https://dotnet.microsoft.com/download/dotnet/5.0

### How to run:
To run the program, there is a bash script available on the root folder, it will install Entity Framework, the ORM that i used, create the database and start the program. So on the respective folder, run: 
```
bash script.sh
```

If you are on Windows, you can manually run:
```
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```
