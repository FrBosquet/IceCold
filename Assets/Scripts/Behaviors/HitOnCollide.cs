﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOnCollide : BaseScript
{
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.relativeVelocity.magnitude > 2)
    {
      gameManager.PlaySound("hit");
    }
  }
}
