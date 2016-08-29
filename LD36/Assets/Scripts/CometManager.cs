using UnityEngine;
using System.Collections;

public class CometManager : MonoBehaviour {

  public GameObject comet;
  private float timer;
  public float timePerSpawn;
	// Use this for initialization
	void Start () {
    timer = timePerSpawn;
	}
	
	// Update is called once per frame
	void Update () {
    UpdateCometSpawn();
	}

  void UpdateCometSpawn()
  {
    timer -= Time.deltaTime;

    if(timer <= 0)
    {
      Instantiate(comet, new Vector3(Random.Range(-7, 7), 15, 0), new Quaternion());
      timer = timePerSpawn;
    }
  }
}
