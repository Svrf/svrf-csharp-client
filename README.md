# SVRF.Client - the C# client library for the SVRF API

For more information, please visit [https://github.com/svrf/svrf-api](https://github.com/svrf/svrf-api)

## Getting Started

SVRF's API allows you to supercharge your project or app with the first and largest search engine for immersive experiences. We make it simple for any developer to incorporate highly immersive experiences with all kinds of applications: virtual reality, augmented reality, mixed reality, mobile, and web.

The SVRF API Documentation is available at <https://developers.svrf.com>.

## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

## Installation
```
Install-Package SVRF.Client
```

Then you can use the namespaces:
```csharp
using SVRF.Client.Api;
using SVRF.Client.Client;
using SVRF.Client.Model;
```

## Getting Started

```csharp
using System;
using System.Diagnostics;
using SVRF.Client.Api;
using SVRF.Client.Client;
using SVRF.Client.Model;

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
                AuthResponse result = apiInstance.Authenticate(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticateApi.Authenticate: " + e.Message );
            }

        }
    }
}
```

## Documentation for API Endpoints

All URIs are relative to *https://api.svrf.com/v1*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AuthenticateApi* | [**Authenticate**](docs/AuthenticateApi.md#authenticate) | **POST** /app/authenticate | Authenticate application
*MediaApi* | [**GetById**](docs/MediaApi.md#getbyid) | **GET** /vr/{id} | Media by ID Endpoint
*MediaApi* | [**GetTrending**](docs/MediaApi.md#gettrending) | **GET** /vr/trending | Trending Endpoint
*MediaApi* | [**Search**](docs/MediaApi.md#search) | **GET** /vr/search | Search Endpoint


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


## Documentation for Authorization


### XAppToken

- **Type**: API key
- **API key parameter name**: x-app-token
- **Location**: HTTP header

