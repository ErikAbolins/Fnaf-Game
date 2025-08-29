using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
   public Light light;
   public float maxWait;
   public float maxFlicker;


   float timer;
   float interval;

   void Update()
   {
    timer += Time.deltaTime;
    if (timer > interval)
    {
        timer = 0;
        interval = Random.Range(0.5f, maxWait);
        light.intensity = Random.Range(5, maxFlicker);
    }
   }
}
