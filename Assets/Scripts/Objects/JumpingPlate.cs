using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlate : BaseScript
{
  public float force;

  private Animator animator;

  protected override void Awake()
  {
    base.Awake();
    animator = gameObject.GetComponent<Animator>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Ball"))
    {

      Rigidbody2D ball = other.gameObject.GetComponent<Rigidbody2D>();

      gameManager.PlaySound("jump");

      animator.SetTrigger("jump");
      ball.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
  }
}
