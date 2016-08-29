using UnityEngine;
using System.Collections;

public class BuilderUI : MonoBehaviour {

  public GameObject blockPrefab;
  private BuilderManager builderScript;

	// Use this for initialization
	void Start () {
    builderScript = GameObject.Find("BuilderManager").GetComponent<BuilderManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(0))
    {
      builderScript.CreateNewBlock(blockPrefab);
    }
  }
}
