#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HR-Management-WebAPI/HR-Management-WebAPI.csproj", "HR-Management-WebAPI/"]
RUN dotnet restore "HR-Management-WebAPI/HR-Management-WebAPI.csproj"
COPY . .
WORKDIR "/src/HR-Management-WebAPI"
RUN dotnet build "HR-Management-WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HR-Management-WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HR-Management-WebAPI.dll"]