using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
public class AutoExtractTextures : AssetPostprocessor
{
    void OnPostprocessModel(GameObject g)
    {
        ModelImporter modelImporter = assetImporter as ModelImporter;
        if (modelImporter == null) return;

        string assetPath = modelImporter.assetPath;
        string texturePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assetPath), "Textures");

        if (!System.IO.Directory.Exists(texturePath))
        {
            System.IO.Directory.CreateDirectory(texturePath);
        }

        modelImporter.ExtractTextures(texturePath);
        AssetDatabase.Refresh();
    }
}
#endif