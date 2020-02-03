using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
  public Door target;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Ball"))
    {
      if (target != null)
      {
        target.Open();
      }
      Destroy(gameObject);
    }
  }
}
