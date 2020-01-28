using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject WaterPrefab;
  public GameObject IcePrefab;

  public GameObject WaterContainer;

  public void BreakIce(GameObject block)
  {
    GameObject newWaterBlock = Instantiate(WaterPrefab, block.transform.position, WaterPrefab.transform.rotation);
    newWaterBlock.transform.SetParent(WaterContainer.transform);

    Destroy(block);
  }
}
