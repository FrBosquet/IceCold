using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct AvailableTools
{
  public bool pick;
  public bool freeze;
  public bool jumpingplate;
}

public class GameManager : MonoBehaviour
{
  public GameObject WaterPrefab;
  public GameObject IcePrefab;
  public GameObject JumpingplatePrefab;

  public UIManager uiManager;
  public CursorManager cursorManager;

  private GameObject BackgroundContainer;
  private GameObject IceContainer;
  private GameObject RockContainer;
  private GameObject WaterContainer;
  private GameObject InteractableContainer;

  public string currentTool;

  public AvailableTools availableTools;

  private void Awake()
  {
    BackgroundContainer = GameObject.Find("BackgroundContainer");
    IceContainer = GameObject.Find("IceContainer");
    RockContainer = GameObject.Find("RockContainer");
    WaterContainer = GameObject.Find("WaterContainer");
    InteractableContainer = GameObject.Find("InteractableContainer");
  }

  private void Start()
  {
    SetTool(GetDefaultTool());
    UpdateUI();
  }

  public void BreakIce(GameObject block)
  {
    if (currentTool != "pick") return;
    Destroy(block);
    UpdateCurrents();
  }

  public void FreezeWater(GameObject block)
  {
    if (currentTool != "freeze") return;
    GameObject newIceBlock = Instantiate(IcePrefab, block.transform.position, IcePrefab.transform.rotation);
    newIceBlock.transform.SetParent(IceContainer.transform);

    UpdateCurrents();
  }

  public void BuildHere(Transform target)
  {
    if (currentTool != "jumpingplate") return;

    GameObject NewJumpingPlate = Instantiate(JumpingplatePrefab, target.position, target.rotation);
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
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex + 1);
  }

  public void RestartLevel()
  {
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex);
  }

  private string GetDefaultTool()
  {
    if (availableTools.pick) return "pick";
    if (availableTools.freeze) return "freeze";
    return "none";
  }

  private void UpdateUI()
  {
    uiManager.SetTools(availableTools);
    uiManager.SetCurrentTool(currentTool);
  }

  public void SetTool(string newTool)
  {
    currentTool = newTool;
    uiManager.SetCurrentTool(currentTool);
    cursorManager.SetCurrentTool(currentTool);
  }

  public void StoreAsInteractable(GameObject target)
  {
    target.transform.SetParent(InteractableContainer.transform);
  }
}
