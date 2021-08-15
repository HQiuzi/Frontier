using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameEvents.current.CloseBuildGUI();
    }
}
