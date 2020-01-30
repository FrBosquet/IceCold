using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : BaseScript
{
  private void OnMouseDown()
  {
    Debug.Log("Clicked on water");
    gameManager.FreezeWater(gameObject);
  }
}
