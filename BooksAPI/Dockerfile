#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BooksAPI/BooksAPI.csproj", "BooksAPI/"]
RUN dotnet restore "BooksAPI/BooksAPI.csproj"
COPY . .
WORKDIR "/src/BooksAPI"
RUN dotnet build "BooksAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BooksAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BooksAPI.dll"]