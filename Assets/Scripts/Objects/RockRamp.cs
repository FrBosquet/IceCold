using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRamp : BaseScript
{
  public Vector2 direction;
  public bool hasBuildSpot;

  private void Start()
  {
    if (hasBuildSpot) gameManager.AddBuildSpot((Vector2)transform.position + direction.normalized / 2, direction);
  }
}
