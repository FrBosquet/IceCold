using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
  public float startY;
  public float targetY;
  public Vector2 ballForce;

  public float descentSpeed = 5;
  public float descentRate = 0.05f;
  private bool moving = false;

  private Rigidbody2D Ball;

  private void Awake()
  {
    transform.position = new Vector2(400f, startY);

    Ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    StartCoroutine("Descent");
  }

  private IEnumerator Descent()
  {
    moving = true;

    while (transform.position.y > targetY)
    {
      yield return new WaitForSeconds(descentRate);

      transform.position = new Vector2(transform.position.x, transform.position.y - descentSpeed);
    }
    moving = false;
  }

  private IEnumerator Ascend()
  {
    moving = true;
    while (transform.position.y < startY)
    {
      yield return new WaitForSeconds(descentRate);

      transform.position = new Vector2(transform.position.x, transform.position.y + descentSpeed);
    }

    Ball.AddForce(ballForce, ForceMode2D.Impulse);
    moving = false;
  }

  public void StartGame()
  {
    if (moving) return;
    Debug.Log("Start adventure");
    StartCoroutine("Ascend");
  }
}
