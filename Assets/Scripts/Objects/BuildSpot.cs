using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpot : BaseScript
{
  private void OnMouseDown()
  {
    gameManager.BuildHere(transform);
  }
}
