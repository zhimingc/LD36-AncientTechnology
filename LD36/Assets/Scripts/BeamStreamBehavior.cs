using UnityEngine;
using System.Collections;

public class BeamStreamBehavior : MonoBehaviour {

  public float bulletSpeed;
  private Vector3 initScale, initPos;
  private GameObject floor;

  // Use this for initialization
  void Start()
  {
    initPos = transform.position;
    initScale = transform.localScale;
    transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    floor = GameObject.FindWithTag("Floor");
    Destroy(gameObject, 0.6f);
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(-Vector3.up * bulletSpeed * Time.deltaTime);
    BeamStreamBehaviour();
  }

  void BeamStreamBehaviour()
  {
    transform.localScale = ((transform.position.y - initPos.y) / (floor.transform.position.y - initPos.y)) * initScale;
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.tag == "Pickable")
    {
      Destroy(gameObject);
    }
  }
}
