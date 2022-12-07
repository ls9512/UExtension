using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Aya.Extension
{
    public static class TilemapExtension
    {
        #region https://github.com/Faulo/UnityExtensions/blob/master/Runtime/TilemapExtensions.cs
        
        public static void ClearTile(this Tilemap tilemap, Vector3Int position)
        {
            tilemap.SetTile(position, null);
        }

        public static IEnumerable<(Vector3Int, TileBase)> GetUsedTiles(this ITilemap tilemap)
        {
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile(position);
                if (tile)
                {
                    yield return (position, tile);
                }
            }
        }

        public static IEnumerable<(Vector3Int, TileBase)> GetUsedTiles(this Tilemap tilemap)
        {
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile(position);
                if (tile)
                {
                    yield return (position, tile);
                }
            }
        }

        public static IEnumerable<(Vector3Int, TTile)> GetUsedTiles<TTile>(this ITilemap tilemap) where TTile : TileBase
        {
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile<TTile>(position);
                if (tile)
                {
                    yield return (position, tile);
                }
            }
        }

        public static IEnumerable<(Vector3Int, TTile)> GetUsedTiles<TTile>(this Tilemap tilemap) where TTile : TileBase
        {
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile<TTile>(position);
                if (tile)
                {
                    yield return (position, tile);
                }
            }
        }

        public static bool IsTile(this ITilemap tilemap, Vector3Int position, TileBase tile)
        {
            return tilemap.GetTile(position) == tile;
        }

        public static bool IsTile(this Tilemap tilemap, Vector3Int position, TileBase tile)
        {
            return tilemap.GetTile(position) == tile;
        }

        public delegate bool TileComparer(TileBase tileA, TileBase tileB);

        public static bool IsTile(this ITilemap tilemap, Vector3Int position, TileBase tile, TileComparer comparer)
        {
            return comparer(tilemap.GetTile(position), tile);
        }

        public static bool IsTile(this Tilemap tilemap, Vector3Int position, TileBase tile, TileComparer comparer)
        {
            return comparer(tilemap.GetTile(position), tile);
        } 

        #endregion
    }
}
