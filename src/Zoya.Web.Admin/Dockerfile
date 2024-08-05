FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Zoya.Web.Admin/Zoya.Web.Admin.csproj", "src/Zoya.Web.Admin/"]
RUN dotnet restore "./src/Zoya.Web.Admin/Zoya.Web.Admin.csproj"
COPY . .
WORKDIR "/src/Zoya.Web.Admin"
RUN dotnet build "./Zoya.Web.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Zoya.Web.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zoya.Web.Admin.dll"]