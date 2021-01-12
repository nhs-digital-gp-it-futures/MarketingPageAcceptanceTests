FROM mcr.microsoft.com/dotnet/dotnet/sdk:5.0-alpine
ENV MSBUILDSINGLELOADCONTEXT=1
WORKDIR /app
COPY ./src ./entrypoint.sh ./
RUN apk add --no-cache bash && apk add curl
RUN dotnet publish -c Release -o out
ENTRYPOINT ["/bin/bash", "entrypoint.sh"]