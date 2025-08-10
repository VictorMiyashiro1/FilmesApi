# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# (Não fixe porta aqui; o Render injeta a variável PORT)

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /out

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /out .
# Troque "SeuProjeto" pelo nome do seu .csproj (AssemblyName)
ENTRYPOINT ["dotnet", "Filmes.Api.dll"]