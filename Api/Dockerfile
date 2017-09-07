# For more info see: http://aka.ms/VSContainerToolingDockerfiles

# base image
# Add your release image configuration here, such as any dependencies
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

# image used to complile the project, and it's dependencies 
# output used for the production image
FROM microsoft/aspnetcore-build:2.0 AS builder
ARG BuildConfiguration=Release
WORKDIR /src
COPY *.sln ./
# copy any additional referenced projects for compilation in this builder image
COPY Api/Api.csproj Api/
RUN dotnet restore
COPY . .
WORKDIR /src/Api
RUN dotnet publish -c $BuildConfiguration -o /app
ENTRYPOINT ["dotnet", "Api.dll"]

# Create an optimized image, from base, using the output from the builder image
FROM base AS production
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "Api.dll"]
