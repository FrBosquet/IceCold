using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  public GameObject resetButton;

  public void HighlightReset()
  {
    RectTransform buttonRect = resetButton.GetComponent<RectTransform>();

    buttonRect.sizeDelta *= 1.5f;
  }
}
