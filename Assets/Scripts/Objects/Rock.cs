using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : BaseScript
{
  public bool[] buildSpots = new bool[4] { false, false, false, false };

  private void Start()
  {
    if (buildSpots[0]) gameManager.AddBuildSpot((Vector2)transform.position + Vector2.up, Vector2.up);
    if (buildSpots[1]) gameManager.AddBuildSpot((Vector2)transform.position + Vector2.right, Vector2.right);
    if (buildSpots[2]) gameManager.AddBuildSpot((Vector2)transform.position + Vector2.down, Vector2.down);
    if (buildSpots[3]) gameManager.AddBuildSpot((Vector2)transform.position + Vector2.left, Vector2.left);
  }
}
