using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

// Makes the button grow or shrink depending on the click
[RequireComponent(typeof(Button))]
public class ButtonResize : EventTrigger
{
    private const float SIZE_SCALE_INTERECTABLE = 0.90f, SIZE_SCALE_NOT_INTERACTABLE = 0.98f;

    private bool buttonHasText=false;

    private float sizeScale;

    private Button thisButton;
    private RectTransform recTransform;
    private TextMeshProUGUI buttonProText;
    private Vector2 originalSize; private int textOriginalSize;

    private void Start()
    {
        ButtonInfo();
        if (GetComponentInChildren<TextMeshProUGUI>() != null) TextInfo();
    }

    private void ButtonInfo()
    {
        thisButton = GetComponent<Button>();
        recTransform = GetComponent<RectTransform>();
        originalSize = recTransform.localScale;
    }

    private void TextInfo()
    {
        buttonHasText = true;
        buttonProText = GetComponentInChildren<TextMeshProUGUI>();
        textOriginalSize = (int)buttonProText.fontSize;
    }

    public override void OnPointerDown(PointerEventData data)
    {
        ButtonShrink();
    }

    public override void OnPointerUp(PointerEventData data)
    {
        ButtonGrow();
    }

    public void ButtonShrink()
    {
        if (thisButton.interactable)
        {
            sizeScale = SIZE_SCALE_INTERECTABLE;
        }
        else
        {
            sizeScale = SIZE_SCALE_NOT_INTERACTABLE;
        }

        recTransform.localScale = new Vector2(originalSize.x * sizeScale, originalSize.y * sizeScale);
        if (buttonHasText) buttonProText.fontSize = (int)(textOriginalSize * sizeScale);     
    }

    public void ButtonGrow()
    {
        recTransform.localScale = originalSize;
        if (buttonHasText) buttonProText.fontSize = textOriginalSize;       
    }
}