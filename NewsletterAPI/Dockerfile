FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore NewsletterAPI.csproj
RUN dotnet publish NewsletterAPI.csproj -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /runtime-app
COPY --from=build-env /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "NewsletterAPI.dll"]

