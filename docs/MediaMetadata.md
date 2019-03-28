# SVRF.Client.Model.MediaMetadata
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**HasBlendShapes** | **bool?** | For 3D Media, denotes that this model contains blend shapes, but having to calculate and apply weights to them is not required. These are models like glasses, hats, and billboards that do not react to face movement. | [optional] 
**IsFaceFilter** | **bool?** | For 3D Media, denotes that this model can be applied as a Face Filter overlay on a video of a face. | [optional] 
**RequiresBlendShapes** | **bool?** | For 3D Media, denotes that calculating and applying blend shape weights to this model is _required_ for the correct experience. If your platform cannot detect and calculate blend shape weights you MUST NOT present these models to your users. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

