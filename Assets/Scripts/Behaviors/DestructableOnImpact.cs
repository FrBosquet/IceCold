using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableOnImpact : BaseScript
{
  public float requiredEnergy;

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

  private void OnCollisionEnter2D(Collision2D other)
  {
    Rigidbody2D rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
    Vector2 velocity = other.relativeVelocity;

    Vector2 axis = other.gameObject.transform.position - transform.position;

    if (axis.x > axis.y)
    {
      axis = Vector2.right;
    }
    else
    {
      axis = Vector2.up;
    }

    float energy = Mathf.Abs(Vector2.Dot(axis, velocity) / axis.magnitude);

    if (energy > requiredEnergy)
    {
      gameManager.PlaySound("rockBreak");
      collider.enabled = false;
      sprite.enabled = false;
      particles.Play();
      rigidbody.velocity = velocity.normalized * (energy - requiredEnergy);
      StartCoroutine(WaitAndDestroy());
    }

  }

  IEnumerator WaitAndDestroy()
  {
    yield return new WaitForSeconds(1);
    Destroy(gameObject);
  }
}
