using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public static bool didGhostWin = false;

    public UnityEvent TimerOut;
    public float MaxTimeLeft = 5.0f;
    static float _timeRemaining = 5.0f;
    public static float TimeRemaining
    {
        get { return _timeRemaining; }
        private set { _timeRemaining = value; }
    }

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

        if (GameManagerScript.instance != null ) //enforce singleton
        {
            Destroy(GameManagerScript.instance);
        }
        GameManagerScript.instance = this;

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer(Time.deltaTime);
    }

    void OnTimerOver()
    {
        TimerOut.Invoke();
        return;
    }

    public void OnGameOver(bool didGhostWin)
    {
        GameManagerScript.didGhostWin = didGhostWin;
        //this will load the game over screen
        SceneManager.LoadScene("GameOver");

    }

    public void OnPlay()
    {
        SceneManager.LoadScene("Soph's Level");
        //this will load the main game level
        Debug.Log("WOAH GAMEPLAY!!!!!!");
        
    }

public void LoadMainMenu()
    {
        Debug.Log("WOAH MANIN MENU!!!");
        SceneManager.LoadScene("TitleLevel");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Quit the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the game
        Application.Quit();
#endif
    }
}