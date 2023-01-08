using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GlobalText
{
    Left,
    Center,
    FullCenter,
    Right,
    Bottom,
    Top
}

public class GlobalTextManager : MonoBehaviour
{
    public static GlobalTextManager Instance
    {
        get;
        private set;
    }

    [SerializeField] public TMP_Text tmpText;

    [Header("Text Settings")]
    [SerializeField] public Color defaultTextColor = Color.white;
    [SerializeField] public float defaultTextSize = 11f;
    [SerializeField] public bool defaultAutoWrap = true;
    [SerializeField] public bool defaultAutoSize = true;

    [Header("Texts")]
    [SerializeField] private TMP_Text topText;
    [SerializeField] private TMP_Text bottomText;
    [SerializeField] private TMP_Text leftText;
    [SerializeField] private TMP_Text rightText;
    [SerializeField] private TMP_Text centerText;
    [SerializeField] private TMP_Text fullCenterText;

    private void LoadCutscenes()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        
        if(scene == 1)
            Introduction();
    }
    
    private void Start()
    {
        LoadCutscenes();
    }

    public TMP_Text GetText(GlobalText display)
    {
        switch (display)
        {
            case GlobalText.Top:
                return topText;
            case GlobalText.Bottom:
                return bottomText;
            case GlobalText.Left:
                return leftText;
            case GlobalText.Right:
                return rightText;
            case GlobalText.Center:
                return centerText;
            case GlobalText.FullCenter:
                return fullCenterText;
            default:
                return null;
        }
    }
    
    // Make all variations of SetText
    public void SetText(GlobalText display, string text)
    {
        GetText(display).text = text;
    }
    
    public void SetText(GlobalText display, string text, Color color)
    {
        GetText(display).text = text;
        GetText(display).color = color;
    }
    
    public void SetText(GlobalText display, string text, float size)
    {
        GetText(display).text = text;
        GetText(display).fontSize = size;
    }
    
    public void SetText(GlobalText display, string text, bool autoWrap)
    {
        GetText(display).text = text;
        GetText(display).enableWordWrapping = autoWrap;
    }
    
    public void SetText(GlobalText display, string text, bool autoWrap, bool autoSize)
    {
        GetText(display).text = text;
        GetText(display).enableWordWrapping = autoWrap;
        GetText(display).enableAutoSizing = autoSize;
    }
    
    public void SetText(GlobalText display, string text, Color color, float size)
    {
        GetText(display).text = text;
        GetText(display).color = color;
        GetText(display).fontSize = size;
    }
    
    public void SetText(GlobalText display, string text, Color color, float size, bool autoWrap, bool autoSize)
    {
        GetText(display).text = text;
        GetText(display).color = color;
        GetText(display).enableWordWrapping = autoWrap;
        GetText(display).enableAutoSizing = autoSize;
    }
    
    public void SetText(GlobalText display, string text, float size, bool autoWrap, bool autoSize)
    {
        GetText(display).text = text;
        GetText(display).fontSize = size;
        GetText(display).enableWordWrapping = autoWrap;
        GetText(display).enableAutoSizing = autoSize;
    }
    
    // Animate Text
    public Task<WaitForSeconds> AnimateText(GlobalText display, string text, float time)
    {
        StartCoroutine(IAnimateText(display, text, time));
        
        return Task.FromResult(new WaitForSeconds(time));
    }
    
    public Task<WaitForSeconds> AnimateText(GlobalText display, string text, float time, Color color)
    {
        GetText(display).color = color;
        StartCoroutine(IAnimateText(display, text, time));
        
        return Task.FromResult(new WaitForSeconds(time));
    }
    
    public Task<WaitForSeconds> AnimateText(GlobalText display, string text, float time, float size)
    {
        GetText(display).fontSize = size;
        StartCoroutine(IAnimateText(display, text, time));
        
        return Task.FromResult(new WaitForSeconds(time));
    }
    
    public Task<WaitForSeconds> AnimateText(GlobalText display, string text, float time, bool autoWrap)
    {
        GetText(display).enableWordWrapping = autoWrap;
        StartCoroutine(IAnimateText(display, text, time));
        
        return Task.FromResult(new WaitForSeconds(time));
    }
    
    public Task<WaitForSeconds> AnimateText(GlobalText display, string text, Color white, float time, bool autoWrap, bool autoSize)
    {
        GetText(display).enableWordWrapping = autoWrap;
        GetText(display).enableAutoSizing = autoSize;
        StartCoroutine(IAnimateText(display, text, time));

        return Task.FromResult(CoroutineHelpers.GetWait(time));
    }
    
    public Task<WaitForSeconds> AnimateText(GlobalText display, string text, float time, Color color, float size)
    {
        GetText(display).color = color;
        GetText(display).fontSize = size;
        StartCoroutine(IAnimateText(display, text, time));
        
        return Task.FromResult(CoroutineHelpers.GetWait(time));
    }
    
    public Task<WaitForSeconds> AnimateText(GlobalText display, string text, float time, Color color, float size, bool autoWrap, bool autoSize)
    {
        GetText(display).color = color;
        GetText(display).fontSize = size;
        GetText(display).enableWordWrapping = autoWrap;
        GetText(display).enableAutoSizing = autoSize;
        StartCoroutine(IAnimateText(display, text, time));
        
        return Task.FromResult(CoroutineHelpers.GetWait(time));
    }


    IEnumerator IAnimateText(GlobalText display, string message, float time)
    {
        var charTime = time / message.Length;
        GetText(display).text = "";
        foreach (char c in message)
        {
            GetText(display).text += c;
            yield return CoroutineHelpers.GetWait(charTime);
        }

        GetText(display).text = message;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void ResetText(GlobalText display)
    {
        GetText(display).text = "";
        GetText(display).color = Color.white;
    }
    
    // Pre-Coded Scenes
    public void Introduction()
    {
        StartCoroutine(IIntroduction());
    }
    
    private IEnumerator IIntroduction()
    {
        float inbetweenText = 5f;
        
        SetText(GlobalText.FullCenter, "Willkommen in cos(<i>game</i>)!", true, true);
        yield return CoroutineHelpers.GetWait(inbetweenText);
        
        SetText(GlobalText.FullCenter, "Dieses Spiel ist ein simplistischer 3D-Platformer", true, true);
        yield return CoroutineHelpers.GetWait(inbetweenText);
        
        SetText(GlobalText.FullCenter, "Du kannst dich mit <i>W, A, S, D</i> bewegen", true, true);
        yield return CoroutineHelpers.GetWait(inbetweenText);
        
        SetText(GlobalText.FullCenter, "Mit <i>Leertaste</i> kannst du springen", true, true);
        yield return CoroutineHelpers.GetWait(inbetweenText);
        
        SetText(GlobalText.FullCenter, "Mit der Maus kannst du dich umschauen.", true, true);
        yield return CoroutineHelpers.GetWait(inbetweenText);
        
        yield return AnimateText(GlobalText.FullCenter, "Viel Spaß!", 2f, Color.white, 11f, true, true).Result;
        yield return CoroutineHelpers.GetWait(1f);

        SceneManager.LoadScene(2);
    }
}
