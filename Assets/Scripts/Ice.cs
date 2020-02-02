using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : BaseScript
{
  private void OnMouseDown()
  {
    gameManager.BreakIce(gameObject);
  }
}
