using UnityEngine;
using UnityEditor;
using System.Collections;

public class SpritePostprocessor : AssetPostprocessor
{

    void OnPreprocessTexture()
    {
        if (assetImporter.assetPath.Contains("Sprites"))
        {
            TextureImporter importer = assetImporter as TextureImporter;
            importer.anisoLevel = 0;
			importer.wrapMode = TextureWrapMode.Clamp;
			importer.spriteImportMode = SpriteImportMode.Multiple;
			if (assetImporter.assetPath.Contains("Tiles")) {
				importer.wrapMode = TextureWrapMode.Repeat;
				importer.spriteImportMode = SpriteImportMode.Single;
			}
			importer.spritePixelsPerUnit = 8;
            importer.mipmapEnabled = false;
            importer.filterMode = FilterMode.Point;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
			
        }
		
    }

}
