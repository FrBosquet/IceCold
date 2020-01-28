using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : BaseScript
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(GOAL))
    {
      Debug.Log("Win");
    }
  }
}
