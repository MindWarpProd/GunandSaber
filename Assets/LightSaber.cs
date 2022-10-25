using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public Animator lightSaberAnimator;
   public void TurnOnLightSaber()
    {
        lightSaberAnimator.SetBool("LightSaberBool", true);
    }

    public void TurnOffLightSaber()
    {
        lightSaberAnimator.SetBool("LightSaberBool", false);
    }
}
