using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseScript
{
  public bool open = false;
  private Animator animator;
  private new BoxCollider2D collider;

  private void Start()
  {
    animator = gameObject.GetComponent<Animator>();
    collider = gameObject.GetComponent<BoxCollider2D>();

    animator.SetBool("open", open);
  }

  public void Open()
  {
    open = true;
    collider.enabled = false;
    animator.SetBool("open", open);
    gameManager.PlaySound("openDoor");
  }

  public void Close()
  {
    open = false;
    collider.enabled = true;
    animator.SetBool("open", open);
    gameManager.PlaySound("openDoor");
  }

  public void Toggle()
  {
    if (open)
    {
      Close();
    }
    else
    {
      Open();
    }
  }
}
