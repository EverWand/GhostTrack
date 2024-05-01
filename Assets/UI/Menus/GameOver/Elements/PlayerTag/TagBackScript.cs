using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagBackScript : MonoBehaviour
{

    public enum BackType { Win, Lose}
    public BackType BackState = BackType.Win;

    public Sprite WinBackSprite;
    public Sprite LoseBackSprite;


    public Image BackDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called when the Script Changes
    void OnValidate()
    {

        UpdateTagBack();
    }

    public void UpdateTagBack() 
    {
        switch (BackState)
        {
            case BackType.Win:
                BackDisplay.sprite = WinBackSprite;
                break;

            case BackType.Lose:
                BackDisplay.sprite = LoseBackSprite;
                break;
            }
    }
}
