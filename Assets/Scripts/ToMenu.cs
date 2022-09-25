using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneControl.instance.GotoScene(0);
    }
}
