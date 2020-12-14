# ThisNetWorks.OrchardCore.CKEditor
CKEditor 5 classic build with media plugins for Orchard Core.

## Features

- Html Field and Html Body Part editor modes for CKEditor 5.
- Reusable plugin / editor toolbar configurations.

## Getting Started

- Install the [ThisNetWorks.OrchardCore.CKEditor](https://www.nuget.org/packages/ThisNetWorks.OrchardCore.CKEditor) module to your Orchard Core Host project.
- Enable the CKEditors feature.
- Change the editor mode for either an Html Field, or Html Body Part, in the `Content Definitions` to `CKEditor`.
- Select either the `Default Configuration` or a custom configuration.

## Samples

There is a sample project which includes custom configurations for the CKEditor toolbar.

To install run the `CK Editor Sample` recipe.

CK Editor Configurations are found in the _Configuration -> CKEditor Configurations_ menu.

These include toolbar styling options, and an example of how to apply styling to `TheAdmin` theme.

## Configurations

Different toolbar configurations are available.
Please refer to the [CKEditor 5 configuration documentation](https://ckeditor.com/docs/ckeditor5/latest/builds/guides/integration/configuration.html)

## Notes

This project is a light wrapper around `CKEditor5` to provide alternates to the default editors, and access to the media library.

For further customization of builds, alternate editors, etc, please refer to the [CKEditor 5 documentation](https://ckeditor.com/docs/ckeditor5/latest/)

## Versions

Currently built against 

- Orchard Core Version `1.0.0-rc2-15621`
- CKEditor Classic Build Version `23.0.0`

## License

[ThisNetworks.OrchardCore.CKEditor](https://github.com/ThisNetWorks/ThisNetWorks.OrchardCore.CKEditor/blob/master/LICENSE) licensed under the terms of the BSD-3-Clause License.

[CKEditor5 Classic Build](https://github.com/ckeditor/ckeditor5/blob/master/LICENSE.md) redistributed under the the terms of GNU General Public License Version 2 or later. For full details about the license, please check the LICENSE.md file or https://ckeditor.com/legal/ckeditor-oss-license.
