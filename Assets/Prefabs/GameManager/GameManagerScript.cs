using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //CHARACTERS
    public GameObject Ghost;
    public GameObject Tracker1;
    public GameObject Tracker2;
    public float MaxTimeLeft = 5.0f;
    public float TimeRemaining = 5.0f;

    float GameTimer(float DeltaTime)
    {
        TimeRemaining -= DeltaTime;
        if (TimeRemaining <= 0)
        {
            OnTimerOver();
        }
        return TimeRemaining;
    }


    // Start is called before the first frame update
    void Start()
    {
        TimeRemaining = MaxTimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer(Time.deltaTime);
    }
    void OnTimerOver()
    {
        return;
    }
}