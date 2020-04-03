FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MangoBlog.csproj", "MangoBlog/"]
RUN dotnet restore "MangoBlog/MangoBlog.csproj"
COPY . .
WORKDIR "/src/MangoBlog"
RUN dotnet build "MangoBlog.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MangoBlog.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY ./key.json /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MangoBlog.dll"]