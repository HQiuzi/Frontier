using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSO", menuName = "ScriptableObjects/ColorSO", order = 1)]
public class ColorSO : ScriptableObject
{
   public Color Color;
   public Color GreenLight;
   public Color Red;
}
