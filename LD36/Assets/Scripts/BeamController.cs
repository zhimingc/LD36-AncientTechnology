using UnityEngine;
using System.Collections;

public class BeamController : MonoBehaviour {

  public GameObject beamBullet;
  public float speedOfPicked, rotateSpeed, offsetSpeed, upwardSpeed;
  public bool isFloating;
  private GameObject picked;
  private Vector3 pointPicked;
  private Vector3 oldShipPos;

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
    float offsetAmt = Input.GetAxis("Vertical");

    if (picked)
    {
      picked.transform.Rotate(new Vector3(0.0f, 0.0f, rotAmt * rotateSpeed));
      Vector3 offsetDir = picked.transform.InverseTransformDirection(Vector3.up * offsetAmt);
      picked.transform.Translate(offsetDir * offsetSpeed * Time.deltaTime );
      //picked.GetComponent<Rigidbody2D>().AddForceAtPosition(offsetDir * offsetSpeed, pointPicked);
    }

  }

  void UpdatePickup()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Instantiate(beamBullet, transform.position + Vector3.up * 2, Quaternion.identity);

      if (picked == null)
      {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up); // Get it to ignore certain things
        if (hit.collider != null)
        {
          if (hit.collider.tag == "Pickable") // Change to tag later?
          {
            //print("Picked: " + hit.collider.name);
            picked = GameObject.Find(hit.collider.name);
            picked.GetComponent<Rigidbody2D>().gravityScale = 0;
            oldShipPos = transform.position;
            //picked.GetComponent<BlockBehavior>().ToggleStatic();

            // Different beam mode to test
            //pointPicked = hit.point;
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
    if (isFloating && picked != null)
    {
      GameObject floor = GameObject.FindGameObjectWithTag("Floor");
      float offsetFromShip = floor.transform.position.z + 1.5f;
      Vector3 v;
      Vector3 targetPosition = transform.position + (offsetFromShip * (-Vector3.up));
      v = targetPosition - picked.transform.position;

      picked.GetComponent<Rigidbody2D>().AddForce(v * speedOfPicked);
    }
    else if (!isFloating && picked)
    {
      // Constant upwards movement to the object
      Vector3 offsetDir = picked.transform.InverseTransformDirection(Vector3.up);
      picked.transform.Translate(offsetDir * upwardSpeed * Time.deltaTime);

      // Translation of the object to follow the ship
      offsetDir = picked.transform.InverseTransformDirection(Vector3.left);
      picked.transform.Translate(offsetDir * (oldShipPos.x - transform.position.x));
      oldShipPos = transform.position;
    }
  }
}
