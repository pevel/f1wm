FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app
ARG connectionString

# copy csproj and restore as distinct layers
COPY ./F1WM.csproj ./
RUN dotnet restore

# copy everything else, populate appsettings and build
COPY . ./
RUN ./scripts/add_connection_string.sh "$connectionString"
RUN dotnet publish -c Release -o bin

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/bin .

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "F1WM.dll"]