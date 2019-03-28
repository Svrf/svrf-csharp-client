# SVRF.Client.Model.Media
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Adult** | **bool?** | Whether the Media is adult content | [optional] [default to false]
**Authors** | **List&lt;string&gt;** | The Media&#39;s authors. This should be displayed when possible. | [optional] 
**Canonical** | **string** | The canonical page this Media can be found at via SVRF. | [optional] 
**Description** | **string** | A description of the Media | [optional] 
**Duration** | **decimal?** | The duration of the Media in seconds. | [optional] 
**EmbedHtml** | **string** | An &#x60;&lt;iframe&gt;&#x60; tag that embeds a player that plays the Media. | [optional] 
**EmbedUrl** | **string** | A player that can be embedded using an &#x60;&lt;iframe&gt;&#x60; tag to play the Media. | [optional] 
**Files** | [**MediaFiles**](MediaFiles.md) |  | [optional] 
**Height** | **decimal?** | The height, in pixels, of the Media&#39;s source | [optional] 
**Id** | **string** | The unique ID of this Media | [optional] 
**Metadata** | [**MediaMetadata**](MediaMetadata.md) |  | [optional] 
**Site** | **string** | The site that this Media came from. This should be displayed when possible. | [optional] 
**Title** | **string** | The title of the Media, suitable for displaying | [optional] 
**Type** | **MediaType** |  | [optional] 
**Url** | **string** | The original page this Media is located at. | [optional] 
**Width** | **decimal?** | The width, in pixels, of the Media&#39;s source | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

