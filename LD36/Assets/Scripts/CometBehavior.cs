using UnityEngine;
using System.Collections;

public class CometBehavior : MonoBehaviour {

  public Vector2 v;
  public float forceMultiplier;

	// Use this for initialization
	void Start () {
  }
	
	// Update is called once per frame
	void Update () {
    UpdateCometMovement();
	}

  void UpdateCometMovement()
  {
    GetComponent<Rigidbody2D>().AddForce(v * forceMultiplier * Time.deltaTime);
  }
}
