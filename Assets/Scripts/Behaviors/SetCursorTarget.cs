using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorTarget : BaseScript
{
  public string target;

  private void OnMouseOver()
  {
    cursorManager.SetCurrentTarget(target);
  }
}
