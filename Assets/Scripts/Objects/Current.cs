using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour
{
  public Vector2 direction;
  public float force;
  public new Transform collider;
  public LineRenderer line;

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
    transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector2.Perpendicular(normalized));

    LayerMask mask = LayerMask.GetMask("Solid");
    Vector3 shotOrigin = transform.position + (Vector3)normalized / 100;
    RaycastHit2D hit = Physics2D.Raycast(shotOrigin, direction, 100f, mask);

    line.SetPosition(0, shotOrigin);
    line.SetPosition(1, hit.point);

    float particleSpeed = particles.main.startSpeed.constant;

    ParticleSystem.MainModule psmain = particles.main;
    psmain.startLifetime = new ParticleSystem.MinMaxCurve(direction.magnitude / particleSpeed);
    particles.Play();

    float distance = direction.magnitude;

    if (hit.collider != null)
    {
      distance = Mathf.Round(hit.distance);
    }

    transform.localScale = new Vector2(distance, 1);
  }

  public Vector2 GetForce(Vector2 ballPosition)
  {
    float distance = Vector2.Distance(ballPosition, position);
    float maxDistance = direction.magnitude;
    return force * direction.normalized * (distance / maxDistance);
  }
}
