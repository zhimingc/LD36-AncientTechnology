using UnityEngine;
using System.Collections;

enum TimeOfDay
{
  TRANSIT, IDLE
}

public class DayNightController : MonoBehaviour {

  public float idleTime, fadeSpeed;
  private GameObject bgDay, bgNight;
  private TimeOfDay timeState, nextState;
  private float timer;
  private int fadeDir;

	// Use this for initialization
	void Start () {
    bgDay = GameObject.Find("bg_day");
    bgNight = GameObject.Find("bg_night");
    timeState = TimeOfDay.IDLE;
    timer = idleTime;
    fadeDir = 1;
	}
	
	// Update is called once per frame
	void Update () {
	  switch (timeState)
    {
      case TimeOfDay.TRANSIT:
        float curAlpha = bgDay.GetComponent<SpriteRenderer>().color.a - Time.deltaTime * fadeDir * fadeSpeed;
        if (curAlpha < 0.0f || curAlpha > 1.0f)
        {
          fadeDir = -fadeDir;
          timeState = TimeOfDay.IDLE;
          curAlpha = Mathf.Clamp(curAlpha, 0.0f, 1.0f);
        }

        bgDay.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, curAlpha);
        break;
      case TimeOfDay.IDLE:
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
          timeState = TimeOfDay.TRANSIT;
          timer = idleTime;
        }
        break;
    }
	}
}
