# GlobalX.ChatBots.MicrosoftTeams

<p align="center">
    <a href="https://www.nuget.org/packages/GlobalX.ChatBots.MicrosoftTeams">
    	<img src="https://flat.badgen.net/nuget/v/globalx.chatbots.microsoftteams" alt="GlobalX.ChatBots.MicrosoftTeams nuget package" />
    </a>
    <a href="https://travis-ci.org/GlobalX/GlobalX.ChatBots.MicrosoftTeams">
    	<img src="https://flat.badgen.net/travis/GlobalX/GlobalX.ChatBots.MicrosoftTeams" alt="GlobalX.ChatBots.MicrosoftTeams on Travis CI" />
    </a>
    <a href="https://codecov.io/gh/GlobalX/GlobalX.ChatBots.MicrosoftTeams">
    	<img src="https://flat.badgen.net/codecov/c/github/globalx/globalx.chatbots.microsoftteams" alt="GlobalX.ChatBots.MicrosoftTeams on Codecov" />
    </a>
    <img src="https://flat.badgen.net/github/commits/globalx/globalx.chatbots.microsoftteams" alt="commits" />
    <img src="https://flat.badgen.net/github/contributors/globalx/globalx.chatbots.microsoftteams" alt="contributors" />
    <img src="https://flat.badgen.net/badge/commitizen/friendly/green" alt="commitizen friendly" />
</p>

A .NET Core library containing implementations of core interfaces of
[GlobalX.ChatBots.Core](https://github.com/GlobalX/GlobalX.ChatBots.Core) for
Microsoft Teams.

## Getting started

### Configuration

In order to use this bot, some configuration is required. This can either be done
through appsettings.json, or at the time of configuring the bot.

#### Example Configuration

```json
// In appsettings.json
{
    "GlobalX.ChatBots.MicrosoftTeams": {
        // TODO
    }
}
```

### Using Dependency Injection

In the `ConfigureServices` method of your `Startup.cs` file, add the following:

```cs
using GlobalX.ChatBots.MicrosoftTeams;

public IServiceProvider ConfigureServices(IServiceCollection services)
{
    // Add other service registrations here
    services.ConfigureMicrosoftTeamsBot(Configuration);
    return services;
}
```

If you have not provided your configuration inside appsettings.json, you may do so
when you configure the bot:

```cs
using GlobalX.ChatBots.MicrosoftTeams;
using GlobalX.ChatBots.MicrosoftTeams.Configuration;

public IServiceProvider ConfigureServices(IServiceCollection services)
{
    // Add other service registrations here
    var settings = new MicrosoftTeamsSettings
    {
        // TODO
    };

    services.ConfigureMicrosoftTeamsBot(settings);
}
```

To start the webhooks, put the following in your `Configure` method.

```cs
public void Configure (IApplicationBuilder app, IHostingEnvironment env)
{
    // other configuration code here
    app.ApplicationServices.GetService<IWebhookHelper>().Webhooks.RegisterWebhooksAsync();
}
```

### Without Dependency Injection

You can get a microsoft teams implementation of the library by calling the
`MicrosoftTeamsChatHelperFactory.CreateMicrosoftTeamsChatHelper` method.

```cs
using GlobalX.ChatBots.Core;
using GlobalX.ChatBots.MicrosoftTeams;
using GlobalX.ChatBots.MicrosoftTeams.Configuration;

// Some code here

var settings = new MicrosoftTeamsSettings
{
    // TODO
};

MicrosoftTeamsChatHelper microsoftTeamsChatHelper = MicrosoftTeamsChatHelperFactory.CreateMicrosoftTeamsChatHelper(settings);
microsoftTeamsChatHelper.Webhooks.RegisterWebhooksAsync();
```
