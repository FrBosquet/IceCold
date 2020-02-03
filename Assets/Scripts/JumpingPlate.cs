using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlate : MonoBehaviour
{
  public float force;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Ball"))
    {

      Rigidbody2D ball = other.gameObject.GetComponent<Rigidbody2D>();

      ball.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
  }
}
