using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour
{
  public bool isHortizontal, isStatic;
  private Quaternion initRot;
  private Vector3 curPos;

	// Use this for initialization
	void Start () {
    if (isHortizontal) transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    else transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

    initRot = transform.rotation;
	}

	// Update is called once per frame
	void Update () {
	
	}

  void LateUpdate()
  {
    transform.rotation = initRot;
    //if (isStatic) transform.position = curPos;
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
