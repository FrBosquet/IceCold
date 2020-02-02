using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : BaseScript
{
  private void OnMouseDown()
  {
    gameManager.FreezeWater(gameObject);
  }
}
