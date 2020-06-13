#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["FlowersMallApi/FlowersMallApi.csproj", "FlowersMallApi/"]
#RUN dotnet restore "FlowersMallApi/FlowersMallApi.csproj"
#COPY . .
#WORKDIR "/src/FlowersMallApi"
#RUN dotnet build "FlowersMallApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "FlowersMallApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
COPY . .
ENTRYPOINT ["dotnet", "FlowersMallApi.dll"]