using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //CHARACTERS
    public GameObject Ghost;
    public GameObject Tracker1;
    public GameObject Tracker2;
    [SerializeField] private Timer = 5.0f;
    float TimeRemaining = Timer;

    void GameTimer(float DeltaTime)
    {
        TimeRemaining -= DeltaTime;
        if (TimeRemaining <= 0)
        {
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer(Time.DeltaTime);
    }
}