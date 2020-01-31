using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
  protected GameManager gameManager;
  protected string GOAL = "Goal";
  protected string WATER = "Water";
  protected string CURRENT = "Current";
  protected string FAIL = "Fail";

  protected void Awake()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }
}
