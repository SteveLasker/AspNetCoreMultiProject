# For more info see: http://aka.ms/VSContainerToolingDockerfiles
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS builder
ARG BuildConfiguration=Release
WORKDIR /src
COPY *.sln ./
COPY Web/Web.csproj Web/
RUN dotnet restore
COPY . .
WORKDIR /src/Web
RUN dotnet build -c $BuildConfiguration -o /app

FROM builder AS test
WORKDIR /src/Web.test
RUN dotnet test 

FROM builder AS publish
ARG BuildConfiguration=Release
RUN dotnet publish -c $BuildConfiguration -o /app

FROM base AS production
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Web.dll"]
