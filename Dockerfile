#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .

COPY ["hotel-booking-mvc/hotel-booking-mvc.csproj", "hotel-booking-mvc/"]
COPY ["hotel-booking-services/hotel-booking-services.csproj", "hotel-booking-services/"]
COPY ["hotel-booking-model/hotel-booking-model.csproj", "hotel-booking-model/"]
RUN dotnet restore "hotel-booking-mvc/hotel-booking-mvc.csproj"
COPY . .

WORKDIR /src/hotel-booking-mvc
RUN dotnet build

FROM build AS publish
WORKDIR /src/hotel-booking-mvc
RUN dotnet publish -c Release -o /src/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /src/publish .

#ENTRYPOINT ["dotnet", "hotel-booking-mvc.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet hotel-booking-mvc.dll