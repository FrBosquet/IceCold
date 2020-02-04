using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
  private string currentTool;
  private string currentTarget;
  private string currentCursor;
  private bool highlight;

  public Texture2D pick;
  public Texture2D pickHighlight;
  public Texture2D freeze;
  public Texture2D freezeHighlight;
  public Texture2D jumpingplate;
  public Texture2D jumpingplateHighlight;

  private Dictionary<string, string> toolsAndTargets = new Dictionary<string, string>(){
    {"pick", "Ice"},
    {"freeze", "Water"},
    {"jumpingplate", "BuildSpot"},
  };

  private Dictionary<string, Texture2D> cursors;

  private void Awake()
  {
    cursors = new Dictionary<string, Texture2D>(){
      {"pick", pick},
      {"pickhighlight", pickHighlight},
      {"freeze", freeze},
      {"freezehighlight", freezeHighlight},
      {"jumpingplate", jumpingplate},
      {"jumpingplatehighlight", jumpingplateHighlight},
    };
  }

  private void Update()
  {
    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    if (hit.collider != null && (toolsAndTargets[currentTool] == hit.collider.tag))
    {
      SetCursor(currentTool + "highlight");

    }
    else
    {
      SetCursor(currentTool);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("Hitt something");
  }

  public void SetCurrentTool(string tool)
  {
    currentTool = tool;
    SetCursor(tool);
  }

  public void SetCurrentTarget(string target)
  {
    currentTarget = target;
  }

  private void SetCursor(string cursor)
  {
    if (cursor != currentCursor)
    {
      Cursor.SetCursor(cursors[cursor], Vector2.zero, CursorMode.Auto);

    }
  }
}
