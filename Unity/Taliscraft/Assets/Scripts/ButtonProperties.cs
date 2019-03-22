using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Type of button
/// </summary>
public enum ButtonType
{
    shape,
    transformation,
    none
}
/// <summary>
/// Written by Kesavan Shanmugasundaram
/// holds basic button information
/// no known errors
/// </summary>
public class ButtonProperties : MonoBehaviour
{
    public ButtonType buttonType;
}
