using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// Written by Kesavan Shanmugasundaram
/// ToDo class when button is hovered
/// No known errors
/// </summary>
public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Outline outline;
    public ButtonType buttonType;
    public bool isHovering;
    public Color shape, transformation, menu;
    public AudioClip hoverEffect;
    public AudioSource audioSource;
    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.effectColor = Color.white;
        buttonType = GetComponent<ButtonProperties>().buttonType;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    /// <summary>
    /// Checks if the button is actively being hovered and changes color based on button type
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerEnter(PointerEventData data)
    {
        audioSource.PlayOneShot(hoverEffect);
        switch (buttonType)
        {
            case ButtonType.shape: //shape button
                outline.effectColor = new Color(1.0f, 0.64f, 0f);
                break;
            case ButtonType.transformation: //transformation button
                outline.effectColor = Color.green;
                break;
            case ButtonType.none:
                outline.effectColor = Color.magenta;
                break;
        }
    }
    /// <summary>
    /// Resets button color to white
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerExit(PointerEventData data)
    {
        outline.effectColor = Color.white;
    }
}
