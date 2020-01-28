using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject WaterPrefab;
  public GameObject IcePrefab;

  public GameObject WaterContainer;

  public void BreakIce(GameObject block, bool hasWater)
  {
    if (hasWater)
    {
      GameObject newWaterBlock = Instantiate(WaterPrefab, block.transform.position, WaterPrefab.transform.rotation);
      newWaterBlock.transform.SetParent(WaterContainer.transform);
    }

    Destroy(block);
  }

  public void NextLevel()
  {
    Debug.Log("Next level!!");
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    Application.LoadLevel(currentIndex + 1);
  }
}
