# SVRF.Client.Api.AuthenticateApi

All URIs are relative to *https://api.svrf.com/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AppAuthenticatePost**](AuthenticateApi.md#appauthenticatepost) | **POST** /app/authenticate | Authenticate application


<a name="appauthenticatepost"></a>
# **AppAuthenticatePost**
> AuthResponse AppAuthenticatePost (Body body)

Authenticate application

Authenticate an application's SVRF API Key to retrieve an access token to the SVRF API.

### Example
```csharp
using System;
using System.Diagnostics;
using SVRF.Client.Api;
using SVRF.Client.Client;
using SVRF.Client.Model;

namespace Example
{
    public class AppAuthenticatePostExample
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

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Body**](Body.md)|  | 

### Return type

[**AuthResponse**](AuthResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

