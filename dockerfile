FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY src/BankingApi.csproj ./
RUN dotnet restore BankingApi.csproj
COPY src/ ./
RUN dotnet publish BankingApi.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "BankingApi.dll"]
