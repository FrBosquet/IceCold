using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject WaterPrefab;
  public GameObject IcePrefab;
  public UIManager uiManager;

  private GameObject BackgroundContainer;
  private GameObject IceContainer;
  private GameObject RockContainer;
  private GameObject WaterContainer;

  private void Awake()
  {
    BackgroundContainer = GameObject.Find("BackgroundContainer");
    IceContainer = GameObject.Find("IceContainer");
    RockContainer = GameObject.Find("RockContainer");
    WaterContainer = GameObject.Find("WaterContainer");
  }

  public void BreakIce(GameObject block)
  {
    Destroy(block);
    UpdateCurrents();
  }

  public void FreezeWater(GameObject block)
  {

    GameObject newIceBlock = Instantiate(IcePrefab, block.transform.position, IcePrefab.transform.rotation);
    newIceBlock.transform.SetParent(IceContainer.transform);

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

  public void FailLevel()
  {
    uiManager.HighlightReset();
  }

  public void NextLevel()
  {
    Debug.Log("Next level!!");
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex + 1);
  }

  public void RestartLevel()
  {
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex);
  }
}
