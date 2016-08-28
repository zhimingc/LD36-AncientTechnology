using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour
{
  public bool isHortizontal, isStatic;
  private Quaternion initRot;
  private Vector3 curPos;
  public GameObject templateObject;
  public float inPlaceBuffer;
  public bool isObjectInPlace;

	// Use this for initialization
	void Start () {
    if (isHortizontal) transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    else transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

    initRot = transform.rotation;
    templateObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
    templateObject.transform.localScale = transform.localScale;
    templateObject.transform.localRotation = transform.localRotation;
    inPlaceBuffer = 0.4f;
    isObjectInPlace = false;
  }

	// Update is called once per frame
	void Update () {
    ObjectInPlaceCheck();
	}

  void LateUpdate()
  {
    transform.rotation = initRot;
    //if (isStatic) transform.position = curPos;
  }

  void ObjectInPlaceCheck()
  {
    if((transform.position - templateObject.transform.position).magnitude < inPlaceBuffer)
    {
      isObjectInPlace = true;
      templateObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      isObjectInPlace = false;
      templateObject.GetComponent<SpriteRenderer>().enabled = true;
    }
  }

  //public void ToggleStatic()
  //{
  //  isStatic = !isStatic;
  //}

  //void OnCollisionEnter2D(Collision2D col)
  //{
  //  print("saving curPos " + col.gameObject.tag);
  //  if (col.gameObject.tag == "Pickable")
  //  {
  //    BlockBehavior blockScript = col.gameObject.GetComponent<BlockBehavior>();
  //    if (!isStatic && blockScript.isStatic)
  //    {
  //      curPos = transform.position;
  //      isStatic = true;
  //    }
  //  }
  //  else if (col.gameObject.tag == "Floor")
  //  {
  //    if (!isStatic) 
  //    {
  //      curPos = transform.position;
  //      isStatic = true;
  //    }
  //  }
  //}

}
