FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY GradoCeroV1/ .
RUN dotnet publish GradoCeroV1.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE $PORT
ENTRYPOINT ["dotnet", "GradoCeroV1.dll"]