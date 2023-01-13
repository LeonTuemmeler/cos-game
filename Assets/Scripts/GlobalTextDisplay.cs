using System.Collections;
using UnityEngine;

public class GlobalTextDisplay : MonoBehaviour
{
    [SerializeField] private Color color = Color.white;
    [SerializeField] private float fontSize = 11f;
    [SerializeField] private string text = "Hello World";
    [SerializeField] private GlobalText displayText;
    
    [SerializeField] private bool animate = false;
    [SerializeField] private float animateCharacterDelay = 0.5f;

    public void ShowText()
    {
        if (!animate)
        {
            GlobalTextManager.Instance.SetText(displayText, text, color, fontSize);
            return;
        }
        
        GlobalTextManager.Instance.AnimateText(displayText, text, animateCharacterDelay);
    }

    public void SetText(string text)
    {
        this.text = text;
    }
    
    public void SetColor(Color color)
    {
        this.color = color;
    }
    
    public void SetFontSize(float fontSize)
    {
        this.fontSize = fontSize;
    }
    
    public void SetAnimate(bool animate)
    {
        this.animate = animate;
    }
    
    public void SetAnimateCharacterDelay(float animateCharacterDelay)
    {
        this.animateCharacterDelay = animateCharacterDelay;
    }
    
    public void SetDisplayText(GlobalText displayText)
    {
        this.displayText = displayText;
    }
}
