using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject CreditsScreen;
    public GameObject EndingScreen;
    public static GameManager instance;

    public KeyCode TitleScreenKey;
    public KeyCode CreditsScreenKey;
    public KeyCode EndingScreenKey;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateTitleScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TitleScreenKey))
        {
            ActivateTitleScreen();
        }

        if (Input.GetKeyDown(CreditsScreenKey))
        {
            ActivateCreditsScreen();
        }

        if (Input.GetKeyDown(EndingScreenKey))
        {
            ActivateEndingScreen();
        }
    }

    public void DeactiateStates()
    {
        TitleScreen.SetActive(false);
        CreditsScreen.SetActive(false);
        EndingScreen.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        // TODO: Anything that needs to happen when this even fires

        DeactiateStates();

        TitleScreen.SetActive(true);
    }

    public void ActivateCreditsScreen()
    {
        // TODO: Anything that needs to happen when this even fires

        DeactiateStates();

        CreditsScreen.SetActive(true);
    }

    public void ActivateEndingScreen()
    {
        // TODO: Anything that needs to happen when this even fires

        DeactiateStates();

        EndingScreen.SetActive(true);
    }
}