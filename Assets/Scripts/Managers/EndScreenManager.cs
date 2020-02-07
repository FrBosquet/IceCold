using UnityEngine;
using UnityEngine.SceneManagement;


public class EndScreenManager : MonoBehaviour
{
  private UIScroller scroller;

  private void Awake()
  {
    scroller = gameObject.GetComponent<UIScroller>();
  }

  public void Credits()
  {
    StartCoroutine(scroller.Descent());
  }

  public void ReestartGame()
  {
    SceneManager.LoadScene(0);
  }

  public void Quit()
  {
    Application.Quit();
  }
}
