FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet build -c Release

FROM build AS publish
WORKDIR /src
RUN dotnet publish "MangoBlog.csproj" -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY ./key.json /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MangoBlog.dll"]