using Motherload.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

namespace Assets.Scripts.Player
{
    public class Oretile : RuleTile
    {
        #region Oretile
        
        public SpriteAtlas m_Atlas;

        /// <summary>
        /// Indica se é um minério
        /// </summary>
        private bool IsNormal => TileType == OresTypes.NORMAL;

        /// <summary>
        /// Tipo de piso
        /// </summary>
        public OresTypes TileType = OresTypes.NORMAL;

        /// <summary>
        /// Sobrescreve a informação sobre o piso original
        /// </summary>
        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            if (IsNormal)
                base.GetTileData(position, tilemap, ref tileData);
            else
            {
                tileData.sprite = m_Atlas.GetSprite("tileset_20");
            }
        }

        #endregion
        
    }
}
