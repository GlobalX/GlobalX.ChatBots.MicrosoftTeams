dotnet test src/GlobalX.ChatBots.WebexTeams.Tests/GlobalX.ChatBots.WebexTeams.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat="opencover"
curl -Os https://uploader.codecov.io/latest/linux/codecov
chmod +x codecov
./codecov -f src/GlobalX.ChatBots.MicrosoftTeams.Tests/coverage.opencover.xml
