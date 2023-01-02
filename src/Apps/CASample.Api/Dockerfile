#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/CASample.Api/CASample.Api.csproj", "src/Apps/CASample.Api/"]
COPY ["src/Common/CASample.Infrastructure/CASample.Infrastructure.csproj", "src/Common/CASample.Api.Infrastructure/"]
COPY ["src/Common/CASample.Application/CASample.Application.csproj", "src/Common/CASample.Api.Application/"]
COPY ["src/Common/CASample.Domain/CASample.Domain.csproj", "src/Common/CASample.Api.Domain/"]
RUN dotnet restore "src/Apps/CASample.Api/CASample.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/CASample.Api"
RUN dotnet build "CASample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CASample.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CASample.Api.dll"]