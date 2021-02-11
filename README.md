# To-do's Application

## About:
This is a simple "To do" notes app, with folder to group those, and, hopefully, user login.
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
To be able to run this, you only need to install .NET 5.0 SDK, which is available for Windows, Mac OS and several Linux distrosthen, then, all other the dependencies will be installed automatically:
https://dotnet.microsoft.com/download/dotnet/5.0

### How to run:
To run the program, there is a bash script available on the root folder, it will install Entity Framework, the ORM that i used, create the database and start the program. So on the respective folder, run: 
```
bash script.sh
```

If you are on Windows, or the script doesn't work, you can manually run:
```
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```

## Important:
If when you run the app when running the program in linux or docker, you receive an error similar to:
##### "The author primary signature's timestamp found a chain building issue: UntrustedRoot"
 
 This is because Microsoft's "NuGet" Framework certificate has expired at the end of Januray 2021 and it has not been renewed yet. There are several workarounds on the internet (see: https://github.com/NuGet/Announcements/issues/49), but the only real solution is to wait for a renewed certificate from the NuGet team. Sorry.

### How does it work:
I programmed this project using OOP. There are only 3 classes, User, Folder and Item:
<img align="center" src="https://user-images.githubusercontent.com/51339020/107588725-2b1cfb80-6be3-11eb-9fd3-85ddf99de6d7.png" />

When you first enter, you will be greeted and ask to register.
<img align="center" src="https://user-images.githubusercontent.com/51339020/107589228-4b998580-6be4-11eb-8f5c-8ad831f1e4a1.png" />

You need to create a User, with username and password,
<img align="center" src="https://user-images.githubusercontent.com/51339020/107589230-4c321c00-6be4-11eb-8334-d65f4b8354f4.png" />

then you a redirected to your folders,
<img align="center" src="https://user-images.githubusercontent.com/51339020/107589220-463c3b00-6be4-11eb-9963-cdcc7bde14d8.png" />

Every Folder created will be related to the User, and every item created, related with the Folder. When you delete a folder, all the items in it will be deleted as well.

To see the items of a folder, you click on the folder, there you will see the folder's items
<img align="center" src="https://user-images.githubusercontent.com/51339020/107589218-450b0e00-6be4-11eb-923e-5c1dbe8b971e.png" />

You can edit item names, and mark them as completed, but you cant do either of those with the folders.
<img align="center" src="https://user-images.githubusercontent.com/51339020/107589693-530d5e80-6be5-11eb-84f3-4de2beaa51c7.png" />
<img align="center" src="https://user-images.githubusercontent.com/51339020/107589206-41778700-6be4-11eb-8249-4a217e6221a9.png" />
