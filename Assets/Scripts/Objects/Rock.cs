using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : BaseScript
{
  public GameObject upSpot;
  public GameObject rightSpot;
  public GameObject downSpot;
  public GameObject leftSpot;

  private void Start()
  {
    TileSprite tileSprite = gameObject.GetComponent<TileSprite>();

    upSpot.transform.parent = null;
    leftSpot.transform.parent = null;
    rightSpot.transform.parent = null;
    downSpot.transform.parent = null;

    if (tileSprite.neigbours[1]) Destroy(upSpot);
    if (tileSprite.neigbours[3]) Destroy(rightSpot);
    if (tileSprite.neigbours[5]) Destroy(downSpot);
    if (tileSprite.neigbours[7]) Destroy(leftSpot);
  }
}
