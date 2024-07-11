FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestApi/TestApi.csproj", "src/TestApi/"]
RUN dotnet restore "src/TestApi/TestApi.csproj"
COPY . .
WORKDIR "/src/src/TestApi"
RUN dotnet build "TestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApi.dll"]
