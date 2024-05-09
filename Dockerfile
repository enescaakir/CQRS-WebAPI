#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CQRS-WebAPI/CQRS-WebAPI.csproj", "CQRS-WebAPI/"]
COPY ["CQRS-BLL/CQRS-BLL.csproj", "CQRS-BLL/"]
COPY ["CQRS-DAL/CQRS-DAL.csproj", "CQRS-DAL/"]
COPY ["CQRS-Core/CQRS-Core.csproj", "CQRS-Core/"]

RUN dotnet restore "CQRS-WebAPI/CQRS-WebAPI.csproj"
COPY . .
WORKDIR "/src/CQRS-WebAPI"
RUN dotnet build "CQRS-WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRS-WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRS-WebAPI.dll"]

ENV ASPNETCORE_ENVIRONMENT="Development"