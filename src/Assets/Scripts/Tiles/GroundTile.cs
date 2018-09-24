using Motherload.Core.Enums;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motherload.Core.Tiles
{

    /// <summary>
    /// Tile de chão
    /// </summary>
    public class GroundTile : Tile
    {
        /// <summary>
        /// Conjunto de sprites deste tile
        /// </summary>
        [SerializeField]
        private Sprite[] GroundSprites;

        /// <summary>
        /// Conjunto de sprites de minérios para este tile
        /// </summary>
        [SerializeField]
        private Sprite[] OreSprites;

        /// <summary>
        /// Sprite que será exibida no TilePallete
        /// </summary>
        [SerializeField]
        private Sprite Preview;

        /// <summary>
        /// Diz se é um minério
        /// </summary>
        public OresTypes Type = OresTypes.NORMAL;

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

                    if (HasGround(tilemap, nPos))
                        tilemap.RefreshTile(nPos);
                }
            }
        }

        /// <summary>
        /// Verifica se o tile numa certa posição é do tipo <see cref="GroundTile"/>
        /// </summary>
        /// <param name="tilemap">Tilemap atual</param>
        /// <param name="position">Posição do tile</param>
        /// <returns></returns>
        public bool HasGround(ITilemap tilemap, Vector3Int position)
        {
            return tilemap.GetTile(position) == this;
        }

        /// <summary>
        /// Atualiza a sprite do tile.
        /// </summary>
        /// <param name="position">Posição do tile</param>
        /// <param name="tilemap">Tilemap atual</param>
        /// <param name="tileData">Informações do tile</param>
        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            var composition = string.Empty;

            if (Type != OresTypes.NORMAL)
            {
                tileData.sprite = OreSprites[(int)Type];
                return;
            }

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (HasGround(tilemap, new Vector3Int(position.x + x, position.y + y, position.z)))
                        composition += 'G';
                    else
                        composition += 'E';
                }
            }

            tileData.sprite = GroundSprites[1];

            if (composition[1].Equals('E')
            && composition[3].Equals('G')
            && composition[5].Equals('E')
            && composition[7].Equals('G'))
                tileData.sprite = GroundSprites[0];

            if (composition[1].Equals('G')
            && composition[3].Equals('G')
            && composition[5].Equals('E')
            && composition[7].Equals('E'))
                tileData.sprite = GroundSprites[2];

            if (composition[3].Equals('G')
            && composition[6].Equals('E')
            && composition[7].Equals('G'))
                tileData.sprite = GroundSprites[4];

            if (composition[0].Equals('E')
            && composition[1].Equals('G')
            && composition[3].Equals('G'))
                tileData.sprite = GroundSprites[5];

            if (composition[0].Equals('G')
            && composition[1].Equals('G')
            && composition[2].Equals('E')
            && composition[5].Equals('G'))
                tileData.sprite = GroundSprites[6];


            if (composition[1].Equals('E')
            && composition[3].Equals('G')
            && composition[5].Equals('G'))
                tileData.sprite = GroundSprites[8];

            if (composition == "GGGGGGGGG")
                tileData.sprite = GroundSprites[9];

            if (composition[3].Equals('G')
            && composition[5].Equals('G')
            && composition[7].Equals('E'))
                tileData.sprite = GroundSprites[10];

            if (composition[5].Equals('G')
            && composition[7].Equals('G')
            && composition[8].Equals('E'))
                tileData.sprite = GroundSprites[12];

            if (composition[1].Equals('E')
            && composition[3].Equals('E')
            && composition[5].Equals('G')
            && composition[7].Equals('G'))
                tileData.sprite = GroundSprites[14];

            if (composition[1].Equals('G')
            && composition[3].Equals('E')
            && composition[7].Equals('G'))
                tileData.sprite = GroundSprites[15];

            if (composition[1].Equals('G')
            && composition[3].Equals('E')
            && composition[5].Equals('G')
            && composition[7].Equals('E'))
                tileData.sprite = GroundSprites[16];

            if (composition[1].Equals('G')
            && composition[2].Equals('E')
            && composition[3].Equals('G')
            && composition[5].Equals('G')
            && composition[6].Equals('E')
            && composition[7].Equals('G'))
                tileData.sprite = GroundSprites[13];

            if (composition[0].Equals('E')
            && composition[1].Equals('G')
            && composition[3].Equals('G')
            && composition[5].Equals('G')
            && composition[7].Equals('G')
            && composition[8].Equals('E'))
                tileData.sprite = GroundSprites[7];

        }
    }
}