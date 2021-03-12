#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProcessoSeletivoTotvs.API/ProcessoSeletivoTotvs.API.csproj", "ProcessoSeletivoTotvs.API/"]
COPY ["ProcessoSeletivoTotvs.Domain/ProcessoSeletivoTotvs.Domain.csproj", "ProcessoSeletivoTotvs.Domain/"]
COPY ["ProcessoSeletivoTotvs.Infra.IOC/ProcessoSeletivoTotvs.Infra.IOC.csproj", "ProcessoSeletivoTotvs.Infra.IOC/"]
COPY ["ProcessoSeletivoTotvs.Application/ProcessoSeletivoTotvs.Application.csproj", "ProcessoSeletivoTotvs.Application/"]
COPY ["ProcessoSeletivoTotvs.Infra.CrossCutting/ProcessoSeletivoTotvs.Infra.CrossCutting.csproj", "ProcessoSeletivoTotvs.Infra.CrossCutting/"]
COPY ["ProcessoSeletivoTotvs.Infra.Data/ProcessoSeletivoTotvs.Infra.Data.csproj", "ProcessoSeletivoTotvs.Infra.Data/"]
RUN dotnet restore "ProcessoSeletivoTotvs.API/ProcessoSeletivoTotvs.API.csproj"
COPY . .
WORKDIR "/src/ProcessoSeletivoTotvs.API"
RUN dotnet build "ProcessoSeletivoTotvs.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProcessoSeletivoTotvs.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProcessoSeletivoTotvs.API.dll"]