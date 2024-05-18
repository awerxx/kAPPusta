FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /

COPY . ./dupa
RUN ls -l ./dupa
# COPY ./Directory.Build.props ./
# COPY ["src/Zoya.Web/Zoya.Web.csproj", "src/Zoya.Web/"]
# RUN dotnet restore "src/Zoya.Web/Zoya.Web.csproj"
# COPY . .
# WORKDIR "/src/Zoya.Web"
# RUN dotnet build "Zoya.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# FROM build AS publish
# ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish "Zoya.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Zoya.Web.dll"]