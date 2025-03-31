# Usando uma imagem base do .NET 8 SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definindo o diretório de trabalho
WORKDIR /src

# Copiando o arquivo .csproj e restaurando dependências
COPY ["Calculadora/Calculadora.csproj", "Calculadora/"]
RUN dotnet restore "Calculadora/Calculadora.csproj"

# Copiando o restante dos arquivos do projeto e construindo
COPY . .
WORKDIR "/src/Calculadora"
RUN dotnet publish "Calculadora.csproj" -c Release -o /app/publish

# Definindo a imagem de runtime, baseada em .NET 8
FROM mcr.microsoft.com/dotnet/runtime:8.0

# Definindo o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copiando os arquivos compilados para o contêiner
COPY --from=build /app/publish .

# Definindo o ponto de entrada (comando a ser executado no contêiner)
ENTRYPOINT ["dotnet", "Calculadora.dll"]
