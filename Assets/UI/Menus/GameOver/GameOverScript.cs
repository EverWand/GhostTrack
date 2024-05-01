using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScript : MonoBehaviour
{
    public TiltFive.PlayerIndex PlayerID;

    public enum EWinStates { TrackerWin, GhostWin};
    public EWinStates WinState = EWinStates.TrackerWin;

    [SerializeField] PlayerTag_Script[] PlayerTags;
    [SerializeField] WinnerHeader_Script WinHeader;

    public UnityEvent MainMenuPressed;
    public UnityEvent ContinuePressed;

    // Start is called before the first frame update
    void Start()
    {
        bool winner = GameManagerScript.didGhostWin;
       
        if (!winner) {WinState = EWinStates.TrackerWin; }  //Tracker Win 
        else { WinState = EWinStates.GhostWin; }  //Ghost Win 

        UpdateResults();
    }

    // Update is called once per frame
    void Update()
    { 
        ButtonInput();
    }

    void OnValidate() 
    {
        UpdateResults();
    }

    void ButtonInput() {
        //MAIN MENU
        if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.B, out bool bPressed, TiltFive.ControllerIndex.Right,PlayerID))
        {
            if (bPressed)
            {
                MainMenuPressed.Invoke();
            }
        }
        //Continue
        if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.A, out bool aPressed, TiltFive.ControllerIndex.Right, PlayerID))
        {
            if (aPressed)
            {
                ContinuePressed.Invoke();
            }
        }
    }

    public void UpdateResults()
    {
        switch (WinState) 
        {
            case EWinStates.TrackerWin:
                WinHeader.Winner = WinnerHeader_Script.EWinner.TRACKERS;

                for (int i = 0; i < PlayerTags.Length; i++)
                {
                    if (PlayerTags[i].Player != PlayerTag_Script.EPlayers.Ghost) {
                        PlayerTags[i].WinState = PlayerTag_Script.EWinState.Win;
                    }
                    else {
                        PlayerTags[i].WinState = PlayerTag_Script.EWinState.Lose;
                    }
                    
                    PlayerTags[i].UpdateWinStateDisplay();
                }
                break;
            case EWinStates.GhostWin:

                WinHeader.Winner = WinnerHeader_Script.EWinner.GHOST;
                for (int i = 0; i < PlayerTags.Length; i++)
                {
                    if (PlayerTags[i].Player != PlayerTag_Script.EPlayers.Ghost)
                    {
                        PlayerTags[i].WinState = PlayerTag_Script.EWinState.Lose;
                    }
                    else { PlayerTags[i].WinState = PlayerTag_Script.EWinState.Win; }
                    
                    PlayerTags[i].UpdateWinStateDisplay();
                }
                break;
        }

        WinHeader.UpdateWinnerDisplay();
    }
}
