using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour
{
  public bool isHortizontal;
  private Quaternion initRot;
  private Vector3 curPos;

  //public GameObject templateObject;
  public float inPlaceBuffer;
  public bool isObjectInPlace;
  private GameObject player;
  private BuilderManager builderScript;

	// Use this for initialization
	void Start () {
    initRot = transform.rotation;
    //templateObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
    //templateObject.transform.localScale = transform.localScale;
    //templateObject.transform.localRotation = transform.localRotation;
    inPlaceBuffer = 0.4f;
    isObjectInPlace = false;
    player = GameObject.FindGameObjectWithTag("Player");

    builderScript = GameObject.Find("BuilderManager").GetComponent<BuilderManager>();
    GhostMode(true);
  }

	// Update is called once per frame
	void Update () {
    ObjectInPlaceCheck();
	}

  void LateUpdate()
  {
    transform.rotation = initRot;
  }

  void ObjectInPlaceCheck()
  {
    //if((transform.position - templateObject.transform.position).magnitude < inPlaceBuffer)
    //{
    //  isObjectInPlace = true;
    //  templateObject.GetComponent<SpriteRenderer>().enabled = false;
    //}
    //else
    //{
    //  isObjectInPlace = false;
    //  templateObject.GetComponent<SpriteRenderer>().enabled = true;
    //}
  }

  void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(0))
    {
      builderScript.UpdateSelectedObj(gameObject);
    }
  }

  public void GhostMode(bool isGhostMode)
  {
    if (isGhostMode)
    {
      GetComponent<Collider2D>().enabled = false;
      GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }
    else
    {
      GetComponent<Collider2D>().enabled = true;
      GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
  }

}
