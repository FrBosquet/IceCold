using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : BaseScript
{
  public float floatingForce = 2400f;
  public float impactForce = 5000f;

  private List<Current> suscribedCurrents = new List<Current>();

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
    Vector2 currentForce = Vector2.zero;
    foreach (Current current in suscribedCurrents)
    {
      currentForce += current.GetForce(transform.position);
    }
    rigidbody.AddForce(currentForce);

    if (isFloating)
    {
      rigidbody.AddForce(Vector2.up * floatingForce * Time.deltaTime);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(FAIL))
    {
      gameManager.FailLevel();
    }
    if (other.gameObject.CompareTag(GOAL))
    {
      gameManager.NextLevel();
    }
    else if (other.gameObject.CompareTag(WATER))
    {
      waterCollider++;
      checkFloating();
    }
    else if (other.gameObject.CompareTag(CURRENT))
    {
      suscribedCurrents.Add(other.transform.parent.GetComponent<Current>());
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(WATER))
    {
      waterCollider--;
      checkFloating();
    }
    else if (other.gameObject.CompareTag(CURRENT))
    {

      suscribedCurrents.Remove(other.transform.parent.GetComponent<Current>());
    }
  }

  private void checkFloating()
  {
    if (!isFloating && waterCollider > 0)
    {
      float ammount = rigidbody.velocity.magnitude / 6;
      rigidbody.AddForce(Vector2.up * impactForce * ammount, ForceMode2D.Impulse);
      gameManager.AddWaterSpark(transform);
    }

    isFloating = waterCollider > 0;
  }
}
