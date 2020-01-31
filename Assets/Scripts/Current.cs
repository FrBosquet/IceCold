using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
  public Vector2 direction;
  public float force;
  public new Transform collider;

  private ParticleSystem particles;
  private Vector2 position;

  private void Awake()
  {
    particles = GetComponentInChildren<ParticleSystem>();
  }

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

    float particleSpeed = particles.main.startSpeed.constant;

    ParticleSystem.MainModule psmain = particles.main;
    psmain.startLifetime = new ParticleSystem.MinMaxCurve(direction.magnitude / particleSpeed);
    particles.Play();

    float distance = Mathf.Min(Mathf.Round(hit.distance), direction.magnitude);
    Debug.Log(distance);

    transform.localScale = Vector2.one + normalized * distance - normalized;
  }

  public Vector2 GetForce(Vector2 ballPosition)
  {
    float distance = Vector2.Distance(ballPosition, position);
    float maxDistance = direction.magnitude;
    return force * direction.normalized * (distance / maxDistance);
  }
}
