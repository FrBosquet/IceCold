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
  public GameObject BuildSpotPrefab;

  public UIManager uiManager;
  public CursorManager cursorManager;
  public SoundManager soundManager;

  private GameObject BackgroundContainer;
  private GameObject IceContainer;
  private GameObject RockContainer;
  private GameObject WaterContainer;
  private GameObject BuildSpotContainer;
  private GameObject InteractableContainer;

  public string currentTool;

  public AvailableTools availableTools;

  private void Awake()
  {
    BackgroundContainer = GameObject.Find("BackgroundContainer");
    IceContainer = GameObject.Find("IceContainer");
    RockContainer = GameObject.Find("RockContainer");
    WaterContainer = GameObject.Find("WaterContainer");
    BuildSpotContainer = GameObject.Find("BuildSpotContainer");
  }

  private void Start()
  {
    currentTool = GetDefaultTool();
    cursorManager.SetCurrentTool(currentTool);

    UpdateUI();
  }

  public void AddBuildSpot(Vector2 position, Vector2 direction)
  {
    if (!availableTools.jumpingplate || BuildSpotContainer == null) return;

    GameObject newBuildSpot = Instantiate(BuildSpotPrefab, position, Quaternion.LookRotation(Vector3.forward, direction));
    newBuildSpot.transform.SetParent(BuildSpotContainer.transform);
  }

  public void BreakIce(GameObject block)
  {
    if (currentTool != "pick") return;
    PlaySound("iceBreak");

    Destroy(block);
    UpdateCurrents();
  }

  public void FreezeWater(GameObject block)
  {
    if (currentTool != "freeze") return;
    PlaySound("freezeWater");

    GameObject newIceBlock = Instantiate(IcePrefab, block.transform.position, IcePrefab.transform.rotation);
    newIceBlock.transform.SetParent(IceContainer.transform);

    UpdateCurrents();
  }

  public void BuildHere(Transform target)
  {
    if (currentTool != "jumpingplate") return;
    PlaySound("build");

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
    PlaySound("failLevel");
    uiManager.HighlightReset();
  }

  public void NextLevel()
  {
    PlaySound("nextLevel");
    StartCoroutine(ChangeLevel(1));
  }

  public void RestartLevel()
  {
    PlaySound("restartLevel");
    StartCoroutine(ChangeLevel(0));
  }

  private IEnumerator ChangeLevel(int offset)
  {
    yield return new WaitForSeconds(0.5f);
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex + offset);
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
    PlaySound("selectTool");
    uiManager.SetCurrentTool(currentTool);
    cursorManager.SetCurrentTool(currentTool);
  }

  public void StoreAsInteractable(GameObject target)
  {
    target.transform.SetParent(InteractableContainer.transform);
  }

  public void PlaySound(string sound)
  {
    soundManager.PlaySound(sound);
  }
}
