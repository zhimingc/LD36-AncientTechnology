﻿using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

  public float moveSpeed, moveCap;
  private Rigidbody2D rbody;

  // Use this for initialization
  void Start () {
    rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    float moveDir = Input.GetAxis("Horizontal");

    // Feedback for acceleration direction
    if (moveDir == 0.0f && transform.eulerAngles.z != 0.0f)
    {
      transform.Rotate(new Vector3(0.0f, 0.0f, -HeavySide(180.0f - transform.eulerAngles.z) * 2.0f));
      if (transform.eulerAngles.z < 2.0f || transform.eulerAngles.z > 358.0f)
      {
        transform.eulerAngles = Vector3.zero;
      }
    }
    else if (AngleClamp(30.0f) == 1)
    {
      transform.Rotate(new Vector3(0.0f, 0.0f, -moveDir));
    }

    // Move ship
    rbody.AddForce(new Vector3(moveDir * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    // Clamp ship's movement
    rbody.velocity = new Vector2(Mathf.Clamp(rbody.velocity.x, -moveCap, moveCap), 0.0f);
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
