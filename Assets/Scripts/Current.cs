using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
  public Vector2 direction;
  public float force;
  public new Transform collider;

  private Vector2 position;

  private void Start()
  {
    position = transform.position;
    UpdateCurrent();
  }

  public void UpdateCurrent()
  {
    Vector2 normalized = direction.normalized;

    transform.position = position - normalized / 2;
    collider.localPosition = normalized / 2;

    LayerMask mask = LayerMask.GetMask("Solid");
    RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)normalized / 100, direction, 100f, mask);

    float distance = Mathf.Round(hit.distance);

    transform.localScale = Vector2.one + normalized * distance - normalized;
  }

  public Vector2 GetForce()
  {
    return force * direction.normalized;
  }
}
