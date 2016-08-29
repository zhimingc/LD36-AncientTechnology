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
      Vector2 startPos = new Vector2(Random.Range(-7, 7), 15);
      Vector2 endPos = new Vector2(Random.Range(-7, 7), -6);
      Vector2 dir = endPos - startPos;
      GameObject GO = (GameObject) Instantiate(comet, startPos, new Quaternion());
      
      GO.GetComponent<CometBehavior>().v = dir.normalized;
      GO.GetComponent<CometBehavior>().forceMultiplier = 10.0f;
      GO.GetComponent<ParticleSystem>().simulationSpace = ParticleSystemSimulationSpace.World;
      timer = timePerSpawn;
    }
  }
}
