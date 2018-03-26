FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./F1WM/F1WM.csproj ./
RUN dotnet restore

# copy everything else and build
COPY ./F1WM/. ./
RUN dotnet publish -c Release -o bin

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/bin .
ENTRYPOINT ["dotnet", "F1WM.dll"]