# SVRF.Client.Model.MediaFiles
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Glb** | **string** | This is the binary glTF format that should be used by clients if the Media is a 3D object. This is the preferred format to use on end-user devices. | [optional] 
**GlbDraco** | **string** | This is the binary glTF format, with additional DRACO compression, that should be used by clients if the Media is a 3D object. Your renderer must support the KHR_draco_mesh_compression extension to use this model. | [optional] 
**Gltf** | **Dictionary&lt;string, string&gt;** | A map of file names to urls where those files are hosted. The file names are relative and their name heirarchy should be respected when saving them locally. | [optional] 
**Images** | [**MediaImages**](MediaImages.md) |  | [optional] 
**Stereo** | [**MediaStereo**](MediaStereo.md) |  | [optional] 
**Videos** | [**MediaVideos**](MediaVideos.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

