using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour {

  private GameObject[] gos;
  private int numberOfPickableObjects;
	// Use this for initialization
	void Start () {
    gos = GameObject.FindGameObjectsWithTag("Pickable");
    numberOfPickableObjects = gos.Length;
	}
	
	// Update is called once per frame
	void Update () {

    int numberOfObjectsInPlace = 0;

	  foreach(GameObject go in gos)
    {
      if(go.GetComponent<BlockBehavior>().isObjectInPlace)
      {
        ++numberOfObjectsInPlace;
      }
    }

    if(numberOfObjectsInPlace >= numberOfPickableObjects)
    {
      print("A WINNER IS YOU.");
    }
	}
}
