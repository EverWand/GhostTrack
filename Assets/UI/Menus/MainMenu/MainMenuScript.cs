using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuScript : MonoBehaviour
{
    public TiltFive.PlayerIndex PlayerID;

    public UnityEvent StartPressed;
    public UnityEvent CreditsPressed;
    public UnityEvent QuitPressed;

    // Update is called once per frame
    void Update()
    {
        if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.X, out bool xPressed, TiltFive.ControllerIndex.Right, PlayerID))
        {
            if (xPressed)
            {
                StartPressed.Invoke();
            }

        }

        if (TiltFive.Input.TryGetButtonDown(TiltFive.Input.WandButton.B, out bool bPressed, TiltFive.ControllerIndex.Right, PlayerID))
        {
            if (bPressed)
            {
                QuitPressed.Invoke();
            }

        }
    }
}
