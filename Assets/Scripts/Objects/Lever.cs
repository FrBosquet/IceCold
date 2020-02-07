using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : BaseScript
{
  public Door[] doors;

  public bool state;
  private Animator animator;

  protected override void Awake()
  {
    base.Awake();
    animator = gameObject.GetComponent<Animator>();
    animator.SetBool("isOpen", state);
  }

  public void Toggle()
  {
    state = !state;
    animator.SetBool("isOpen", state);
    StartCoroutine(gameManager.UpdateCurrents());

    foreach (Door door in doors)
    {
      door.Toggle();
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Ball"))
    {
      Toggle();
    }
  }

  private void OnMouseDown()
  {
    if (gameManager.currentTool == "hand")
    {
      Toggle();
    }

  }
}
