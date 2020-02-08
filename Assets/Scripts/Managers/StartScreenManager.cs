using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : BaseScript
{
  public Vector2 ballForce;

  private Rigidbody2D Ball;
  private UIScroller scroller;

  protected override void Awake()
  {
    base.Awake();
    scroller = GetComponent<UIScroller>();

    Ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    StartCoroutine("DescendAndMenu");
  }

  public void StartGame()
  {
    if (scroller.moving) return;
    StartCoroutine("AscendAndStart");
  }

  private IEnumerator DescendAndMenu()
  {
    yield return StartCoroutine(scroller.Descent());
    gameManager.PlaySound("rockBreak");
  }

  private IEnumerator AscendAndStart()
  {
    gameManager.PlaySound("jump");
    yield return StartCoroutine(scroller.Ascend());
    Ball.AddForce(ballForce, ForceMode2D.Impulse);
  }
}
