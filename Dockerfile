FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /app
CMD mkdir Ducktor
COPY src/. ./Ducktor/
WORKDIR /app/Ducktor
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime
WORKDIR /app
COPY --from=build /app/Ducktor/out ./
ENTRYPOINT ["dotnet", "Ducktor.dll"]