using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
  public Vector2 ballForce;

  private Rigidbody2D Ball;
  private UIScroller scroller;

  private void Awake()
  {
    scroller = GetComponent<UIScroller>();

    Ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    StartCoroutine(scroller.Descent());
  }

  public void StartGame()
  {
    if (scroller.moving) return;
    StartCoroutine("AscendAndStart");
  }

  private IEnumerator AscendAndStart()
  {
    yield return StartCoroutine(scroller.Ascend());
    Ball.AddForce(ballForce, ForceMode2D.Impulse);
  }
}
