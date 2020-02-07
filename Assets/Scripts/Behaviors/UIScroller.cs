using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScroller : MonoBehaviour
{
  public float startY;
  public float targetY;

  public float descentSpeed = 5;
  public float descentRate = 0.05f;

  public bool moving = false;

  private void Awake()
  {
    transform.position = new Vector2(400f, startY);
  }



  public IEnumerator Descent()
  {
    moving = true;

    while (transform.position.y > targetY)
    {
      yield return new WaitForSeconds(descentRate);

      transform.position = new Vector2(transform.position.x, transform.position.y - descentSpeed);
    }
    moving = false;
  }

  public IEnumerator Ascend()
  {
    moving = true;
    while (transform.position.y < startY)
    {
      yield return new WaitForSeconds(descentRate);

      transform.position = new Vector2(transform.position.x, transform.position.y + descentSpeed);
    }
    moving = false;
  }

}
