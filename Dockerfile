# Usando uma imagem base do .NET 8 SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definindo o diretório de trabalho para compilar o código
WORKDIR /src

# Copiando o arquivo .csproj para o container e restaurando as dependências
COPY ["Calculadora/Calculadora.csproj", "Calculadora/"]
RUN dotnet restore "Calculadora/Calculadora.csproj"

# Copiando os arquivos restantes do projeto e publicando a aplicação
COPY . .
WORKDIR "/src/Calculadora"
RUN dotnet publish "Calculadora.csproj" -c Release -o /app/publish

# Usando uma imagem de runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/runtime:8.0

# Definindo o diretório de trabalho no container
WORKDIR /app

# Copiando os arquivos compilados da imagem de build para a imagem de runtime
COPY --from=build /app/publish .

# Definindo o ponto de entrada (comando a ser executado no container)
ENTRYPOINT ["dotnet", "Calculadora.dll"]
