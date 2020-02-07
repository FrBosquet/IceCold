using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
  public string currentTool;
  public string currentTarget;
  public string currentCursor;
  private bool highlight;

  public Texture2D pick;
  public Texture2D pickHighlight;
  public Texture2D freeze;
  public Texture2D freezeHighlight;
  public Texture2D jumpingplate;
  public Texture2D jumpingplateHighlight;
  public Texture2D hand;
  public Texture2D handHighlight;

  private Dictionary<string, string> toolsAndTargets = new Dictionary<string, string>(){
    {"pick", "Ice"},
    {"freeze", "Water"},
    {"jumpingplate", "BuildSpot"},
    {"hand", "Lever"},
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
      {"hand", hand},
      {"handhighlight", handHighlight},
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

  public void SetCurrentTool(string tool)
  {
    currentTool = tool;
    SetCursor(tool);
  }

  private void SetCursor(string cursor)
  {
    if (cursor != currentCursor)
    {
      Cursor.SetCursor(cursors[cursor], Vector2.zero, CursorMode.Auto);
      currentCursor = cursor;
    }
  }
}
