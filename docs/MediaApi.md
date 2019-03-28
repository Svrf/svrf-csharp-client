# SVRF.Client.Api.MediaApi

All URIs are relative to *https://api.svrf.com/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetById**](MediaApi.md#getbyid) | **GET** /vr/{id} | Media by ID Endpoint
[**GetTrending**](MediaApi.md#gettrending) | **GET** /vr/trending | Trending Endpoint
[**Search**](MediaApi.md#search) | **GET** /vr/search | Search Endpoint


<a name="getbyid"></a>
# **GetById**
> SingleMediaResponse GetById (string id)

Media by ID Endpoint

Fetch media by its ID.

### Example
```csharp
using System;
using System.Diagnostics;
using SVRF.Client.Api;
using SVRF.Client.Client;
using SVRF.Client.Model;

namespace Example
{
    public class GetByIdExample
    {
        public void main()
        {
            // Configure API key authorization: XAppToken
            Configuration.Default.AddApiKey("x-app-token", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("x-app-token", "Bearer");

            var apiInstance = new MediaApi();
            var id = id_example;  // string | ID of Media

            try
            {
                // Media by ID Endpoint
                SingleMediaResponse result = apiInstance.GetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MediaApi.GetById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| ID of Media | 

### Return type

[**SingleMediaResponse**](SingleMediaResponse.md)

### Authorization

[XAppToken](../README.md#XAppToken)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettrending"></a>
# **GetTrending**
> TrendingResponse GetTrending (List<MediaType> type = null, string stereoscopicType = null, string category = null, int? size = null, int? minimumWidth = null, int? pageNum = null, bool? isFaceFilter = null, bool? hasBlendShapes = null, bool? requiresBlendShapes = null)

Trending Endpoint

The SVRF Trending Endpoint provides your app or project with the hottest immersive content curated by real humans. The experiences returned mirror the [SVRF homepage](https://www.svrf.com), from timely cultural content to trending pop-culture references. The trending experiences are updated regularly to ensure users always get fresh updates of immersive content.

### Example
```csharp
using System;
using System.Diagnostics;
using SVRF.Client.Api;
using SVRF.Client.Client;
using SVRF.Client.Model;

namespace Example
{
    public class GetTrendingExample
    {
        public void main()
        {
            // Configure API key authorization: XAppToken
            Configuration.Default.AddApiKey("x-app-token", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("x-app-token", "Bearer");

            var apiInstance = new MediaApi();
            var type = new List<MediaType>(); // List<MediaType> | The type(s) of Media to be returned (comma separated). (optional) 
            var stereoscopicType = stereoscopicType_example;  // string | Search only for Media with a particular stereoscopic type. (optional) 
            var category = category_example;  // string | Search only for Media with a particular category. (optional) 
            var size = 56;  // int? | The number of results per page. (optional)  (default to 10)
            var minimumWidth = 56;  // int? | The minimum width for video and photo Media, in pixels. (optional) 
            var pageNum = 56;  // int? | Pagination control to fetch the next page of results, if applicable. (optional) 
            var isFaceFilter = true;  // bool? | Search only for Face Filters. (optional) 
            var hasBlendShapes = true;  // bool? | Search only for Media that has blend shapes. (optional) 
            var requiresBlendShapes = true;  // bool? | Search only for Media that requires blend shapes. (optional) 

            try
            {
                // Trending Endpoint
                TrendingResponse result = apiInstance.GetTrending(type, stereoscopicType, category, size, minimumWidth, pageNum, isFaceFilter, hasBlendShapes, requiresBlendShapes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MediaApi.GetTrending: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **type** | [**List&lt;MediaType&gt;**](MediaType.md)| The type(s) of Media to be returned (comma separated). | [optional] 
 **stereoscopicType** | **string**| Search only for Media with a particular stereoscopic type. | [optional] 
 **category** | **string**| Search only for Media with a particular category. | [optional] 
 **size** | **int?**| The number of results per page. | [optional] [default to 10]
 **minimumWidth** | **int?**| The minimum width for video and photo Media, in pixels. | [optional] 
 **pageNum** | **int?**| Pagination control to fetch the next page of results, if applicable. | [optional] 
 **isFaceFilter** | **bool?**| Search only for Face Filters. | [optional] 
 **hasBlendShapes** | **bool?**| Search only for Media that has blend shapes. | [optional] 
 **requiresBlendShapes** | **bool?**| Search only for Media that requires blend shapes. | [optional] 

### Return type

[**TrendingResponse**](TrendingResponse.md)

### Authorization

[XAppToken](../README.md#XAppToken)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="search"></a>
# **Search**
> SearchMediaResponse Search (string q, List<MediaType> type = null, string stereoscopicType = null, string category = null, int? size = null, int? minimumWidth = null, int? pageNum = null, bool? isFaceFilter = null, bool? hasBlendShapes = null, bool? requiresBlendShapes = null)

Search Endpoint

The SVRF Search Endpoint brings the power of immersive search found on [SVRF.com](https://www.svrf.com) to your app or project. SVRF's search engine enables your users to instantly find the immersive experience they're seeking. Content is sorted by the SVRF rating system, ensuring that the highest quality content and most prevalent search results are returned. 

### Example
```csharp
using System;
using System.Diagnostics;
using SVRF.Client.Api;
using SVRF.Client.Client;
using SVRF.Client.Model;

namespace Example
{
    public class SearchExample
    {
        public void main()
        {
            // Configure API key authorization: XAppToken
            Configuration.Default.AddApiKey("x-app-token", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("x-app-token", "Bearer");

            var apiInstance = new MediaApi();
            var q = q_example;  // string | Url-encoded search query.
            var type = new List<MediaType>(); // List<MediaType> | The type(s) of Media to be returned (comma separated). (optional) 
            var stereoscopicType = stereoscopicType_example;  // string | Search only for Media with a particular stereoscopic type. (optional) 
            var category = category_example;  // string | Search only for Media with a particular category. (optional) 
            var size = 56;  // int? | The number of results to return per-page, from 1 to 100. (optional)  (default to 10)
            var minimumWidth = 56;  // int? | The minimum width for video and photo Media, in pixels. (optional) 
            var pageNum = 56;  // int? | Pagination control to fetch the next page of results, if applicable. (optional) 
            var isFaceFilter = true;  // bool? | Search only for Face Filters. (optional) 
            var hasBlendShapes = true;  // bool? | Search only for Media that has blend shapes. (optional) 
            var requiresBlendShapes = true;  // bool? | Search only for Media that requires blend shapes. (optional) 

            try
            {
                // Search Endpoint
                SearchMediaResponse result = apiInstance.Search(q, type, stereoscopicType, category, size, minimumWidth, pageNum, isFaceFilter, hasBlendShapes, requiresBlendShapes);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MediaApi.Search: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **q** | **string**| Url-encoded search query. | 
 **type** | [**List&lt;MediaType&gt;**](MediaType.md)| The type(s) of Media to be returned (comma separated). | [optional] 
 **stereoscopicType** | **string**| Search only for Media with a particular stereoscopic type. | [optional] 
 **category** | **string**| Search only for Media with a particular category. | [optional] 
 **size** | **int?**| The number of results to return per-page, from 1 to 100. | [optional] [default to 10]
 **minimumWidth** | **int?**| The minimum width for video and photo Media, in pixels. | [optional] 
 **pageNum** | **int?**| Pagination control to fetch the next page of results, if applicable. | [optional] 
 **isFaceFilter** | **bool?**| Search only for Face Filters. | [optional] 
 **hasBlendShapes** | **bool?**| Search only for Media that has blend shapes. | [optional] 
 **requiresBlendShapes** | **bool?**| Search only for Media that requires blend shapes. | [optional] 

### Return type

[**SearchMediaResponse**](SearchMediaResponse.md)

### Authorization

[XAppToken](../README.md#XAppToken)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

