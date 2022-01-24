
FROM mcr.microsoft.com/dotnet/sdk:6.0.101

WORKDIR /vsdbg

RUN apt-get update && apt-get install -y --no-install-recommends unzip gss-ntlmssp \
    && rm -rf /var/lib/apt/lists/* \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

ENV DOTNET_USE_POLLING_FILE_WATCHER true

WORKDIR /app

ENTRYPOINT dotnet watch run --urls=http://+:9006 --project ./GraphQL/GraphQL.csproj