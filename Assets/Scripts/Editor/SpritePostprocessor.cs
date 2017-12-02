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
            importer.spriteImportMode = SpriteImportMode.Multiple;
            importer.spritePixelsPerUnit = 8;
            importer.wrapMode = TextureWrapMode.Clamp;
            importer.mipmapEnabled = false;
            importer.filterMode = FilterMode.Point;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
			
        }
		
    }

}
