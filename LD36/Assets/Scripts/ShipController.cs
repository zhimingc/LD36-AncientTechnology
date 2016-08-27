using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

  public float moveSpeed, moveCap;
  private Rigidbody2D rigidbody;
  public float speedOfPicked;
  private GameObject picked;

  // Use this for initialization
  void Start () {
    rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    float moveDir = Input.GetAxis("Horizontal");

    // Feedback for acceleration direction
    if (moveDir == 0.0f)
    {
      transform.Rotate(new Vector3(0.0f, 0.0f, -HeavySide(180.0f - transform.eulerAngles.z) * 2.0f));
    }
    else if (AngleClamp(30.0f) == 1)
    {
      transform.Rotate(new Vector3(0.0f, 0.0f, -moveDir));
    }

    // Move ship
    rigidbody.AddForce(new Vector3(moveDir * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    // Clamp ship's movement
    rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x, -moveCap, moveCap), 0.0f);

    UpdatePickup();
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

  int AngleClamp(float clampAmt)
  {
    if (transform.eulerAngles.z < clampAmt || transform.eulerAngles.z > 360.0f - clampAmt)
    {
      return 1;
    }
    return 0;
  }

  int HeavySide(float input)
  {
    if (input < 0.0f) return -1;
    if (input > 0.0f) return 1;
    return 0;
  }
}
