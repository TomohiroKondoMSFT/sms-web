# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/SmsWeb/SmsWeb.csproj", "src/SmsWeb/"]
RUN dotnet restore "src/SmsWeb/SmsWeb.csproj"
COPY . .
WORKDIR "/src/src/SmsWeb"
RUN dotnet publish "SmsWeb.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmsWeb.dll"]
