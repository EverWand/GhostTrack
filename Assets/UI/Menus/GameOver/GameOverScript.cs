using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    public enum EWinStates { TackerWin, GhostWin};
    public EWinStates WinState = EWinStates.TackerWin;

    [SerializeField] PlayerTag_Script[] PlayerTags;
    [SerializeField] WinnerHeader_Script WinHeader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnValidate() 
    {
        UpdateResults();
    }

    public void UpdateResults()
    {
        switch (WinState) 
        {
            case EWinStates.TackerWin:
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
