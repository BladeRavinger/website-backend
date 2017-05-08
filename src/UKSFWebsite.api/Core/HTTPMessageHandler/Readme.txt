#HTTP Message Handlers

##Authentication use
You can see here:
https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api

In the first section there is mention of setting up custom authentication (the step before authorization). Also linked from this section is the following article:
https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/http-message-handlers

Which explains how to setup a custom HTTP Message Handler. We use a custom HTTP Message Handler to ensure authentication is always handled before any message reaches a controller. 
This allows us to use the built in [Authorize] attribute to protect controllers easily and cleanly.
