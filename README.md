# Repartidor-Oficial-

[Link to the program's branch](https://github.com/lDiego257/Repartidor-Oficial-/tree/master)
1086745

It i's needed to have __NETCOREAPP3.1__.

## A guide:

The program has it´s own executable on ..\Repartidor\bin\Debug\netcoreapp3.1\Repartidor.exe, but in case you want to create the executable by yourself, you'll be needing the OBJ folder and the program.cs, grupo.cs, repartidor.csproj. In that case you go to the folder where u have the alredy mentioned files through the command line and execute DOTNET RUN, and you'll be getting the executable on this directory ...\Repartidor\bin\Debug\netcoreapp3.1 or \Repartidor\bin\Debug\Release\netcoreapp3.1 .
The program is created to recieve 3 parameters to its args:
1. First parameter: a directory path to a text file with a list of students.
2. Second parameter: a directory path to a text file with a list of topics.
3. the amount of groups that you want to be made.

as a instance: 

### >Repartidor.exe ejemplo.txt ejemplo2.txt 3

__Careful__ you cannot have more groups thant topic, or more groups than students
