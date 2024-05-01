using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarIconScript : MonoBehaviour
{
    public enum Avatars { Girl, Boy, Ghost };
    public Avatars Avatar_Icon;

    public Sprite[] AvatarSprites;

    public Image AvaterDisplay;

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
        UpdateIconDisplay();
    }


    public void UpdateIconDisplay() 
    {
        switch (Avatar_Icon)
        {
            case Avatars.Girl:
                AvaterDisplay.sprite = AvatarSprites[0];
                break;
            case Avatars.Boy:
                AvaterDisplay.sprite = AvatarSprites[1];
                break;
            case Avatars.Ghost:
                AvaterDisplay.sprite = AvatarSprites[2];
                break;
        }
    }
}
