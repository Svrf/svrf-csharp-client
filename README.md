# Svrf.Client - the C# library for the SVRF API

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

<a name="dependencies"></a>
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.2.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
```

<a name="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Svrf.Client.Api;
using Svrf.Client.Client;
using Svrf.Client.Model;
```
<a name="packaging"></a>
## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out Svrf.Client.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.

<a name="getting-started"></a>
## Getting Started

```csharp
using System;
using System.Diagnostics;
using Svrf.Client.Api;
using Svrf.Client.Client;
using Svrf.Client.Model;

namespace Example
{
    public class Example
    {
        public void main()
        {

            var apiInstance = new AuthenticateApi();
            var body = new Body(); // Body | 

            try
            {
                // Authenticate application
                AuthResponse result = apiInstance.AppAuthenticatePost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticateApi.AppAuthenticatePost: " + e.Message );
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://api.svrf.com/v1*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AuthenticateApi* | [**AppAuthenticatePost**](docs/AuthenticateApi.md#appauthenticatepost) | **POST** /app/authenticate | Authenticate application
*MediaApi* | [**VrIdGet**](docs/MediaApi.md#vridget) | **GET** /vr/{id} | Media by ID Endpoint
*MediaApi* | [**VrSearchGet**](docs/MediaApi.md#vrsearchget) | **GET** /vr/search | Search Endpoint
*MediaApi* | [**VrTrendingGet**](docs/MediaApi.md#vrtrendingget) | **GET** /vr/trending | Trending Endpoint


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.APIKey](docs/APIKey.md)
 - [Model.Body](docs/Body.md)
 - [Model.ErrorResponse](docs/ErrorResponse.md)
 - [Model.Media](docs/Media.md)
 - [Model.MediaFiles](docs/MediaFiles.md)
 - [Model.MediaImages](docs/MediaImages.md)
 - [Model.MediaStereo](docs/MediaStereo.md)
 - [Model.MediaVideos](docs/MediaVideos.md)
 - [Model.SuccessResponse](docs/SuccessResponse.md)
 - [Model.AuthResponse](docs/AuthResponse.md)
 - [Model.RateLimitResponse](docs/RateLimitResponse.md)
 - [Model.SearchMediaResponse](docs/SearchMediaResponse.md)
 - [Model.SingleMediaResponse](docs/SingleMediaResponse.md)
 - [Model.TrendingResponse](docs/TrendingResponse.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="XAppToken"></a>
### XAppToken

- **Type**: API key
- **API key parameter name**: x-app-token
- **Location**: HTTP header

