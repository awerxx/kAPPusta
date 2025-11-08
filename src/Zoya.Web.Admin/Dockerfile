FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
WORKDIR /src
# Copy the whole repository into the build context so project-to-project references
# are available during dotnet restore.
COPY . /src
WORKDIR /src
# Use repo-relative path to the project file
RUN dotnet restore "src/Zoya.Web.Admin/Zoya.Web.Admin.csproj"
RUN dotnet build "src/Zoya.Web.Admin/Zoya.Web.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:GenerateDocumentationFile=true

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/Zoya.Web.Admin/Zoya.Web.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:GenerateDocumentationFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zoya.Web.Admin.dll"]