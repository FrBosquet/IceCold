using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

  private Dictionary<string, AudioSource> audioDictionary;

  private void Awake()
  {
    audioDictionary = new Dictionary<string, AudioSource>();

    foreach (Transform child in transform)
    {
      audioDictionary.Add(child.gameObject.name, child.GetComponent<AudioSource>());
    }
  }

  public void PlaySound(string sound)
  {
    if (!audioDictionary.ContainsKey(sound)) return;
    AudioSource target = audioDictionary[sound];
    target.Play();
  }
}
