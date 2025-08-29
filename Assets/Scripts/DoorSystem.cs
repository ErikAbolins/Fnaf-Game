using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public Transform door;
    private bool isOpen = false;
    public AudioSource doorOpen;
    public AudioSource doorClose;

   public void OnMouseDown()
   {
     OpenDoor();
   }


   void OpenDoor()
   {
     UnityEngine.Debug.Log("Door has been clicked");
     
     if (isOpen)
     {
        
        doorClose.Play();
        door.transform.Rotate(0.0f, 0.0f, 90f, Space.Self);
     }
     else
     {
        
        doorOpen.Play();
        door.transform.Rotate(0.0f, 0.0f, -90f, Space.Self);
     }
     
     isOpen = !isOpen;
   }
}
