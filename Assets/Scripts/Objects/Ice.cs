using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : BaseScript
{
  private new BoxCollider2D collider;
  private ParticleSystem particles;
  private SpriteRenderer sprite;

  protected override void Awake()
  {
    base.Awake();
    collider = gameObject.GetComponent<BoxCollider2D>();
    particles = GetComponentInChildren<ParticleSystem>();
    sprite = gameObject.GetComponent<SpriteRenderer>();
  }

  private void OnMouseDown()
  {
    if (gameManager.BreakIce(gameObject))
    {
      collider.enabled = false;
      sprite.enabled = false;
      particles.Play();
      StartCoroutine(WaitAndDestroy());
    }
  }

  IEnumerator WaitAndDestroy()
  {
    yield return new WaitForSeconds(1);
    Destroy(gameObject);
  }
}
