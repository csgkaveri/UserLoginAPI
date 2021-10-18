#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CSG.Kaveri.UserLogin/CSG.Kaveri.UserLoginAPI.csproj", "CSG.Kaveri.UserLogin/"]
RUN dotnet restore "CSG.Kaveri.UserLogin/CSG.Kaveri.UserLoginAPI.csproj"
COPY . .
WORKDIR "/src/CSG.Kaveri.UserLogin"
RUN dotnet build "CSG.Kaveri.UserLoginAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSG.Kaveri.UserLoginAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSG.Kaveri.UserLoginAPI.dll"]
