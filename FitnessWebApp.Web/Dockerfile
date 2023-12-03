#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FitnessWebApp.Web/FitnessWebApp.Web.csproj", "FitnessWebApp.Web/"]
COPY ["FitnessWebApp.Common/FitnessWebApp.Common.csproj", "FitnessWebApp.Common/"]
COPY ["FitnessWebApp.Models/FitnessWebApp.Data.Models.csproj", "FitnessWebApp.Models/"]
COPY ["FitnessWebApp.Services/FitnessWebApp.Services.csproj", "FitnessWebApp.Services/"]
COPY ["FitnessWebApp.Web.ViewModels/FitnessWebApp.Web.ViewModels.csproj", "FitnessWebApp.Web.ViewModels/"]
COPY ["FitnessWebApp.Web.Extentions/FitnessWebApp.Web.Infrastructure.csproj", "FitnessWebApp.Web.Extentions/"]
RUN dotnet restore "FitnessWebApp.Web/FitnessWebApp.Web.csproj"
COPY . .
WORKDIR "/src/FitnessWebApp.Web"
RUN dotnet build "FitnessWebApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitnessWebApp.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessWebApp.Web.dll"]