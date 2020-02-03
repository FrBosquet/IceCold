using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
  private TileSprite[,] tiles = new TileSprite[100, 100];

  private void Awake()
  {
    foreach (Transform child in transform)
    {
      Vector2 position = child.position;
      tiles[(int)position.x, (int)position.y] = child.GetComponent<TileSprite>();
    }

    foreach (Transform child in transform)
    {
      Vector2 position = child.position;
      int x = (int)position.x;
      int y = (int)position.y;
      TileSprite tile = tiles[x, y];

      bool[] neigbours = new bool[8];

      neigbours[0] = (x != 0) ? (tiles[x - 1, y + 1] != null) : true;
      neigbours[1] = tiles[x, y + 1] != null;
      neigbours[2] = tiles[x + 1, y + 1] != null;
      neigbours[3] = tiles[x + 1, y] != null;
      neigbours[4] = (y != 0) ? (tiles[x + 1, y - 1] != null) : true;
      neigbours[5] = (y != 0) ? (tiles[x, y - 1] != null) : true;
      neigbours[6] = (x != 0 && y != 0) ? (tiles[x - 1, y - 1] != null) : true;
      neigbours[6] = (x != 0) ? (tiles[x - 1, y] != null) : true;

      tile.SetNeigbours(neigbours);
    }
  }
}
