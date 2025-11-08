FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copy the whole repository into the build context so project-to-project references
# (e.g. ../Zoya.Application) are available during dotnet restore.
COPY . /src
WORKDIR /src
RUN dotnet restore "src/Zoya.Api/Zoya.Api.csproj"
RUN dotnet build "src/Zoya.Api/Zoya.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:GenerateDocumentationFile=true


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/Zoya.Api/Zoya.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:GenerateDocumentationFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zoya.Api.dll"]