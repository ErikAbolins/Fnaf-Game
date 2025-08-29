using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StaticTest : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoCanvas;
    private bool videoPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            videoCanvas.SetActive(true);
            videoPlayer.Play();
            videoPlaying = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Debug.Log("Attempt to stop video");
            videoCanvas.SetActive(false);
            videoPlayer.Stop();
            videoPlaying = false;
        }
    }
}
