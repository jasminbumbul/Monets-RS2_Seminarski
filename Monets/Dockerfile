#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Monets/Monets.csproj", "Monets/"]
RUN dotnet restore "Monets/Monets.csproj"
COPY . .
WORKDIR "/src/Monets"
RUN dotnet build "Monets.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monets.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monets.dll"]