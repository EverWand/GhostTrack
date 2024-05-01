using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTag_Script : MonoBehaviour
{
    public enum EPlayers { Player1, Player2, Player3 }
    public EPlayers Player = EPlayers.Player1;

    public enum EWinState { Win, Lose };
    public EWinState WinState = EWinState.Win;


    [SerializeField] GameObject Back;
    [SerializeField] GameObject Icon;
    [SerializeField] TextMeshProUGUI PlayerText;

    [SerializeField] AvatarIconScript IconScript;
    [SerializeField] TagBackScript BackScript;

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
        UpdatePlayerDisplay();
        UpdateWinStateDisplay();
    }

    void UpdatePlayerDisplay()
    {
        switch (Player)
        {
            case EPlayers.Player1:
                IconScript.Avatar_Icon = AvatarIconScript.Avatars.Ghost;
                PlayerText.text = "Player 1";
                break;
            case EPlayers.Player2:
                IconScript.Avatar_Icon = AvatarIconScript.Avatars.Girl;
                PlayerText.text = "Player 2";
                break;
            case EPlayers.Player3:
                IconScript.Avatar_Icon = AvatarIconScript.Avatars.Boy;
                PlayerText.text = "Player 3";
                break;
        }
        IconScript.UpdateIconDisplay();
    }

   void UpdateWinStateDisplay()
    {
        switch (WinState)
        {
            case EWinState.Win:
                BackScript.BackState = TagBackScript.BackType.Win;
                break;

            case EWinState.Lose:
                BackScript.BackState = TagBackScript.BackType.Lose;
                break;
        }

        BackScript.UpdateTagBack();
    }
}
