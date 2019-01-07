FROM microsoft/dotnet:2.2-sdk-bionic AS build-env
WORKDIR /app

# copy everything and run unit tests and build
ARG BRANCH
ENV BRANCH=$BRANCH
COPY . ./
RUN dotnet test F1WM.UnitTests/F1WM.UnitTests.csproj
RUN dotnet publish -c Release -o bin F1WM/F1WM.csproj

# build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/F1WM/bin .

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "F1WM.dll"]