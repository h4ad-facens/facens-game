using Motherload.Core.Tiles;
using UnityEditor;
using UnityEngine;

namespace Motherload.Core.editor
{
    /// <summary>
    /// Atalho para criar objetos do tipo <see cref="GrassTile"/>
    /// </summary>
    public class GrassTileUtility
    {
        #if UNITY_EDITOR

            [MenuItem("Assets/Create/Tiles/GrassTile")]
            public static void CreateGroundTile()
            {
                var path = EditorUtility.SaveFilePanelInProject("Save GrassTile", "New GrassTile", "asset", "Save grasstile", "Assets/Sprites/Assets");

                if (string.IsNullOrEmpty(path))
                    return;

                AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<GrassTile>(), path);
            }

        #endif

    }
}