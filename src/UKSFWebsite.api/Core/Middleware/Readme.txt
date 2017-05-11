#HTTP Message Handlers

##Authentication use
You can see here:
https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api

~In the first section there is mention of setting up custom authentication (the step before authorization). Also linked from this section is the following article:
https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/http-message-handlers~

This has ended up being more helpful... Message Handlers don't exist/work in .NET Core as far as I can tell. Instead you use 'middleware' as follows:
https://www.exceptionnotfound.net/writing-custom-middleware-in-asp-net-core-1-0/

See also:
https://andrewlock.net/introduction-to-authentication-with-asp-net-core/
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity
https://docs.microsoft.com/en-us/aspnet/core/migration/http-modules <-- Explains MessageHandlers as middleware

Which explains how to setup a custom HTTP Message Handler. We use a custom HTTP Message Handler to ensure authentication is always handled before any message reaches a controller. 
This allows us to use the built in [Authorize] attribute to protect controllers easily and cleanly.
