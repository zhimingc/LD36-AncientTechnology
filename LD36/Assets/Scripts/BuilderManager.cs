using UnityEngine;
using System.Collections;

public class BuilderManager : MonoBehaviour {

  public Camera mainCam;
  public GameObject selectedObj;
  private Vector3 oldMousePos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetMouseButton(0) && selectedObj)
    {
      Vector3 mousePos = Input.mousePosition;
      mousePos = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
      selectedObj.transform.position = mousePos;
    }
    if (Input.GetMouseButtonUp(0))
    {
      if (selectedObj)
      {
        selectedObj.GetComponent<BlockBehavior>().GhostMode(false);
      }
      selectedObj = null;
    }
	}

  public void CreateNewBlock(GameObject block)
  {
    Vector3 mousePos = Input.mousePosition;
    mousePos = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));

    selectedObj = (GameObject)Instantiate(block, mousePos, block.transform.rotation);
  }

  public void UpdateSelectedObj(GameObject block)
  {
    Vector3 mousePos = Input.mousePosition;
    mousePos = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
    oldMousePos = mousePos;
    selectedObj = block;
  }
}
