FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build-env
WORKDIR /app

# copy everything and run unit tests and build
ARG BRANCH
ENV BRANCH=$BRANCH
COPY . ./
RUN dotnet test F1WM.UnitTests/F1WM.UnitTests.csproj
RUN dotnet publish -c Release -o F1WM/bin F1WM/F1WM.csproj

# build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=build-env /app/F1WM/bin .

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "F1WM.dll"]
