using Motherload.Core.Tiles;
using UnityEditor;
using UnityEngine;

namespace Motherload.Core.editor
{
    /// <summary>
    /// Atalho para criar objetos do tipo <see cref="GroundTile"/>
    /// </summary>
    public class GroundTileUtility
    {
        #if UNITY_EDITOR

        [MenuItem("Assets/Create/Tiles/GroundTile")]
        public static void CreateGroundTile()
        {
            var path = EditorUtility.SaveFilePanelInProject("Save GroundTile", "New GroundTile", "asset", "Save groundtile", "Assets/Sprites/Assets");

            if (string.IsNullOrEmpty(path))
                return;

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<GroundTile>(), path);
        }

        #endif
    }
}