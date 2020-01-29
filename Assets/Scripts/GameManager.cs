using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject WaterPrefab;
  public GameObject IcePrefab;

  public GameObject WaterContainer;
  public GameObject IceContainer;

  public void BreakIce(GameObject block, bool hasWater)
  {
    if (hasWater)
    {
      GameObject newWaterBlock = Instantiate(WaterPrefab, block.transform.position, WaterPrefab.transform.rotation);
      newWaterBlock.transform.SetParent(WaterContainer.transform);
    }

    Destroy(block);
    UpdateCurrents();

  }

  public void FreezeWater(GameObject block)
  {

    GameObject newIceBlock = Instantiate(IcePrefab, block.transform.position, IcePrefab.transform.rotation);
    newIceBlock.transform.SetParent(IceContainer.transform);

    newIceBlock.GetComponent<Ice>().hasWater = true;
    Destroy(block);
    UpdateCurrents();
  }

  public void UpdateCurrents()
  {
    Current[] currents = GameObject.FindObjectsOfType<Current>();

    foreach (Current current in currents)
    {
      current.UpdateCurrent();
    }
  }

  public void NextLevel()
  {
    Debug.Log("Next level!!");
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    Application.LoadLevel(currentIndex + 1);
  }

  public void RestartLevel()
  {
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    Application.LoadLevel(currentIndex);
  }
}
