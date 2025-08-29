using System.Collections;
using UnityEngine;

public class ChicaMove : MonoBehaviour
{
  public GameObject Chica;
  public int currentStep = 0;
  public ChicaStates[] chicaPath;
  public bool isMoving = false;

  public Transform showroom;
  public Transform kitchen;
  public Transform rHallway;
  public Transform lHallway;

  public enum ChicaStates
  {
    Showroom,
    Kitchen,
    RHallway,
    LHallway
  }

  void Start()
  {
    StartCoroutine(ChicaRoutine());
  }

  IEnumerator ChicaRoutine()
  {
    while(true)
    {
      MoveChica();

      isMoving = true;
      float moveDuration = Random.Range(1f, 2f);
      yield return new WaitForSeconds(moveDuration);

      isMoving = false;
      float idleDuration = Random.Range(3f, 7f);
      yield return new WaitForSeconds(idleDuration);
    }
  }

  void MoveChica()
  {
    if(currentStep >= chicaPath.Length)
      currentStep = 0;

    ChicaStates nextState = chicaPath[currentStep];

    switch(nextState)
    {
      case ChicaStates.Showroom:
        Chica.transform.position = showroom.position;
        break;
      case ChicaStates.Kitchen:
        Chica.transform.position = kitchen.position;
        break;
      case ChicaStates.RHallway:
        Chica.transform.position = rHallway.position;
        break;
      case ChicaStates.LHallway:
        Chica.transform.position = lHallway.position;
        break;
    }

    Chica.SetActive(true);
    currentStep++;
  }
}
