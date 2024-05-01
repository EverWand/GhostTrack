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

    public void UpdateResults()
    {
        switch (WinState) 
        {
            case EWinStates.TackerWin:
                break;
            case EWinStates.GhostWin:
                
                break;
        }
    }
}
