using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
  public EndScreenManager endScreen;

  private void OnTriggerEnter2D(Collider2D other)
  {
    endScreen.Credits();
  }
}
