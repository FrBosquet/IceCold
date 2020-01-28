using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : BaseScript
{
  public bool hasWater = false;

  private void OnMouseDown()
  {
    gameManager.BreakIce(gameObject, hasWater);
  }
}
