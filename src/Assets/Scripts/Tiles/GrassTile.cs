using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Piso de grama
/// </summary>
public class GrassTile : Tile {

    /// <summary>
    /// Conjunto de sprites deste tile
    /// </summary>
    [SerializeField]
    private Sprite[] grassSprites;

    /// <summary>
    /// Sprite que será exibida no TilePallete
    /// </summary>
    [SerializeField]
    private Sprite preview;

    /// <summary>
    /// Método chamado toda vez que um tile é adicionado.
    /// </summary>
    /// <param name="position">Posição do tile atual</param>
    /// <param name="tilemap">TileMap ao qual está trabalhando</param>
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                var nPos = new Vector3Int(position.x + x, position.y + y, position.z);

                if (HasGrass(tilemap, nPos))
                    tilemap.RefreshTile(nPos);
            }
        }
    }

    /// <summary>
    /// Verifica se o tile numa certa posição é do tipo <see cref="GrassTile"/>
    /// </summary>
    /// <param name="tilemap">Tilemap atual</param>
    /// <param name="position">Posição do tile</param>
    /// <returns></returns>
    public bool HasGrass(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

    /// <summary>
    /// Obtém e atualiza o piso atual.
    /// </summary>
    /// <param name="position">Posição atual do piso</param>
    /// <param name="tilemap">Tilemap atual</param>
    /// <param name="tileData"></param>
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        var composition = string.Empty;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (HasGrass(tilemap, new Vector3Int(position.x + x, position.y + y, position.z)))
                    composition += 'G';
                else
                    composition += 'E';
            }
        }

        tileData.sprite = grassSprites[1];

        if (composition[1].Equals('E')
        && composition[3].Equals('G')
        && composition[5].Equals('E')
        && composition[7].Equals('G'))
            tileData.sprite = grassSprites[0];

        if (composition[1].Equals('G')
        && composition[3].Equals('G')
        && composition[5].Equals('E')
        && composition[7].Equals('E'))
            tileData.sprite = grassSprites[2];

        if (composition[1].Equals('E')
        && composition[3].Equals('E')
        && composition[5].Equals('G')
        && composition[7].Equals('G'))
            tileData.sprite = grassSprites[3];

        if (composition[1].Equals('G')
        && composition[3].Equals('E')
        && composition[5].Equals('G')
        && composition[7].Equals('G'))
            tileData.sprite = grassSprites[4];

        if (composition[1].Equals('G')
        && composition[3].Equals('E')
        && composition[5].Equals('G')
        && composition[7].Equals('E'))
            tileData.sprite = grassSprites[6];

    }

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
