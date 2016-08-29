using UnityEngine;
using System.Collections;

public class BinUI : MonoBehaviour {

  private GameObject blockToDel;
  private BuilderManager builderScript;
  private Color oldColor;

  // Use this for initialization
  void Start()
  {
    builderScript = GameObject.Find("BuilderManager").GetComponent<BuilderManager>();
    blockToDel = null;
  }
	
	// Update is called once per frame
	void Update () {
	  if (Input.GetMouseButtonUp(0) && blockToDel)
    {
      Destroy(blockToDel);
      builderScript.selectedObj = null;
    }
	}

  void OnMouseEnter()
  {
    if (builderScript.selectedObj)
    {
      blockToDel = builderScript.selectedObj;
      oldColor = blockToDel.GetComponent<SpriteRenderer>().color;
      blockToDel.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
    }
  }

  void OnMouseExit()
  {
    if (blockToDel)
    {
      blockToDel.GetComponent<SpriteRenderer>().color = oldColor;
      blockToDel = null;
    }
  }
}
