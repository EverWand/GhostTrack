using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTag_Script : MonoBehaviour
{
    public enum EPlayers { Ghost, Hunter1, Hunter2 }
    public EPlayers Player = EPlayers.Ghost;

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
            case EPlayers.Ghost:
                IconScript.Avatar_Icon = AvatarIconScript.Avatars.Ghost;
                PlayerText.text = "Ghost";
                break;
            case EPlayers.Hunter1:
                IconScript.Avatar_Icon = AvatarIconScript.Avatars.Girl;
                PlayerText.text = "Hunter 1";
                break;
            case EPlayers.Hunter2:
                IconScript.Avatar_Icon = AvatarIconScript.Avatars.Boy;
                PlayerText.text = "Hunter 2";
                break;
        }
        IconScript.UpdateIconDisplay();
    }

   public void UpdateWinStateDisplay()
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
