using UnityEngine;
using System.Collections;

public class BeamBulletBehavior : MonoBehaviour {

  public float bulletSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    transform.Translate(-Vector3.up * bulletSpeed * Time.deltaTime);
	}

  void BeamStreamBehaviour()
  {

  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.tag == "Pickable" || col.gameObject.tag == "Floor")
    {
      Destroy(gameObject);
    }
  }

}
