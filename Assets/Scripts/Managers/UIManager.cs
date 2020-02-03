using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
  private const bool V = true;
  public GameObject resetButton;
  public RectTransform pickButton;
  public RectTransform freezeButton;
  public RectTransform jumpingplateButton;

  public RectTransform toolHighlight;

  public void HighlightReset()
  {
    RectTransform buttonRect = resetButton.GetComponent<RectTransform>();

    buttonRect.sizeDelta = new Vector2(80, 80);
  }

  public void SetTools(AvailableTools availableTools)
  {
    int offset = 105;

    if (availableTools.pick)
    {
      pickButton.position = new Vector2(offset, 15);
      offset += 65;
    }
    else
    {
      pickButton.gameObject.SetActive(false);
    }

    if (availableTools.freeze)
    {
      freezeButton.position = new Vector2(offset, 15);
      offset += 65;
    }
    else
    {
      freezeButton.gameObject.SetActive(false);
    }

    if (availableTools.jumpingplate)
    {
      jumpingplateButton.position = new Vector2(offset, 15);
      offset += 65;
    }
    else
    {
      jumpingplateButton.gameObject.SetActive(false);
    }
  }

  public void SetCurrentTool(string currentTool)
  {
    switch (currentTool)
    {
      case "pick":
        toolHighlight.position = pickButton.position;
        break;
      case "freeze":
        toolHighlight.position = freezeButton.position;
        break;
      case "jumpingplate":
        toolHighlight.position = jumpingplateButton.position;
        break;

    }
  }
}
