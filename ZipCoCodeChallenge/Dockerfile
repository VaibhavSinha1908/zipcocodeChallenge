#Get Base SDK image from MS
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build-env
WORKDIR /ZipCoCodeChallenge

#copy the project file and restore any dependencies.
COPY *.csproj ./
RUN dotnet restore

#copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out


#Generate Runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /ZipCoCodeChallenge
EXPOSE 80
COPY --from=build-env /ZipCoCodeChallenge/out .
ENTRYPOINT ["dotnet", "ZipCoCodeChallenge.dll"]