FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 8080
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["IssueML/IssueML.csproj", "IssueML/"]
RUN dotnet restore "IssueML/IssueML.csproj"
COPY . .
WORKDIR "/src/IssueML"
RUN dotnet build "IssueML.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IssueML.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IssueML.dll"]