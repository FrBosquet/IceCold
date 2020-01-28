using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : BaseScript
{
  public float floatingForce = 2400f;
  public float impactForce = 5000f;

  private new Rigidbody2D rigidbody;
  private bool isFloating = false;
  private int waterCollider = 0;

  private new void Awake()
  {
    base.Awake();
    rigidbody = gameObject.GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    if (isFloating)
    {
      rigidbody.AddForce(Vector2.up * floatingForce * Time.deltaTime);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(GOAL))
    {
      gameManager.NextLevel();
    }
    else if (other.gameObject.CompareTag(WATER))
    {
      waterCollider++;
      checkFloating();
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(WATER))
    {
      waterCollider--;
      checkFloating();
    }
  }

  private void checkFloating()
  {
    if (!isFloating && waterCollider > 0)
    {
      float ammount = rigidbody.velocity.magnitude / 6;
      rigidbody.AddForce(Vector2.up * impactForce * ammount, ForceMode2D.Impulse);
    }

    isFloating = waterCollider > 0;
  }
}
