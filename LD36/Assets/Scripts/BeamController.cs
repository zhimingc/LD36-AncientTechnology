using UnityEngine;
using System.Collections;

public class BeamController : MonoBehaviour {

  public float speedOfPicked;
  private GameObject picked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    UpdatePickup();
    PickupControls();
	}

  void PickupControls()
  {
    float rotAmt = Input.GetAxis("ArrowHorizontal");

    if (picked) picked.transform.Rotate(new Vector3(0.0f, 0.0f, rotAmt));

  }

  void UpdatePickup()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (picked == null)
      {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up); // Get it to ignore certain things
        if (hit.collider != null)
        {
          if (hit.collider.tag == "Pickable") // Change to tag later?
          {
            print("Picked: " + hit.collider.name);
            picked = GameObject.Find(hit.collider.name);
            picked.GetComponent<Rigidbody2D>().gravityScale = 0;
          }
        }
      }
      else
      {
        picked.GetComponent<Rigidbody2D>().gravityScale = 1;
        picked = null;
      }
    }

    // Update the picked object
    if (picked != null)
    {
      float offsetFromShip = 4;
      Vector3 v;
      Vector3 targetPosition = transform.position + (offsetFromShip * (-Vector3.up));
      v = targetPosition - picked.transform.position;

      picked.GetComponent<Rigidbody2D>().AddForce(v * speedOfPicked);
    }
  }
}
