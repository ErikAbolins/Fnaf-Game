using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TurnOnCameras : MonoBehaviour
{
  public GameObject[] cameras;
  public Button[] buttons;
  public GameObject MainCamera;
  public GameObject Laptop;
  public ChicaMove chicaScript;
  public VideoPlayer[] videoPlayers;

  private bool laptopClicked = false;

  void Start()
  {
    MainCamera.SetActive(true);
    cameras[0].SetActive(false);

    for (int i = 0; i < buttons.Length; i++)
    {
      int index = i;
      buttons[i].onClick.AddListener(() =>
      {
        if (laptopClicked)
        {
          OnButtonPressed(index);
        }
      });
    }

    buttons[3].onClick.AddListener(() => { Debug.Log("Direct Button 4 click"); });
  }

  void Update()
  {
    if (laptopClicked && Input.GetKeyDown(KeyCode.Space))
    {
      Debug.Log("Space key pressed");
      ExitCamera();
    }

    ApplyStatic();
  }

  void OnMouseDown()
  {
    MainCamera.SetActive(false);
    cameras[0].SetActive(true);
    laptopClicked = true;
    Debug.Log("Laptop clicked, now buttons can switch cameras.");
  }

  private void OnButtonPressed(int buttonIndex)
  {
    Debug.Log($"Button {buttonIndex + 1} pressed");
    foreach (GameObject cam in cameras)
    {
      cam.SetActive(false);
    }

    if (buttonIndex < cameras.Length)
    {
      cameras[buttonIndex].SetActive(true);
    }
  }

  void ExitCamera()
  {
    foreach (GameObject cam in cameras)
    {
      cam.SetActive(false);
    }

    MainCamera.SetActive(true);
    laptopClicked = false;
  }

void ApplyStatic()
{
  // Stop all videos and hide RawImages if Chica isn’t moving
  if (!chicaScript.isMoving)
  {
    foreach (VideoPlayer vp in videoPlayers)
    {
      RawImage ri = vp.GetComponent<RawImage>();
      if (vp.isPlaying)
        vp.Stop();
      if (ri != null)
        ri.enabled = false;
    }
    return;
  }

  // Find the index of the active camera
  int activeIndex = -1;
  for (int i = 0; i < cameras.Length; i++)
  {
    if (cameras[i].activeSelf)
    {
      activeIndex = i;
      break;
    }
  }

  if (activeIndex == -1)
    return;

  // Play video on the active camera, stop others
  for (int i = 0; i < videoPlayers.Length; i++)
  {
    VideoPlayer vp = videoPlayers[i];
    RawImage ri = vp.GetComponent<RawImage>();

    if (i == activeIndex)
    {
      if (ri != null)
        ri.enabled = true;

      if (!vp.isPrepared)
      {
        vp.Prepare();
        vp.prepareCompleted += player => player.Play();
      }
      else if (!vp.isPlaying)
      {
        vp.Play();
      }
    }
    else
    {
      if (vp.isPlaying)
        vp.Stop();
      if (ri != null)
        ri.enabled = false;
    }
  }
}

}
