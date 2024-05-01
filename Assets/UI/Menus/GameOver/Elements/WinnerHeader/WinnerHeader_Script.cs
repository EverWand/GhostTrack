using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerHeader_Script : MonoBehaviour
{
    public enum EWinner { GHOST, TRACKERS };
    public EWinner Winner = EWinner.TRACKERS;

    public Image WinnerDiplay;

    public Sprite GhostWinSprite;
    public Sprite TrackerWinSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnValidate() {
        UpdateWinnerDisplay();
    }

    private void UpdateWinnerDisplay(){
        if (Winner == EWinner.TRACKERS) {
            WinnerDiplay.sprite = TrackerWinSprite;
        }
            
        if (Winner == EWinner.GHOST) {
            WinnerDiplay.sprite = GhostWinSprite;
        }
    } 
}
