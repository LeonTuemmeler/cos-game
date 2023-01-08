using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ButtonInteractable : Interactable
{
    [SerializeField] private Material staticMaterial;
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private Material interactMaterial;

    [SerializeField] private float switchWaitTime = 1f; 
    
    private Renderer _renderer;

    private void MaterialSwitch(Material material)
    {
        _renderer.material = material;
    }

    private IEnumerator IMaterialSwitch(Material material)
    {
        _renderer.material = material;

        // Bruteforce solution
        // TODO: Fix later
        var time = 0f;
        for (;;)
        {
            if(time >= switchWaitTime)
                break;

            time += Time.deltaTime;

            _renderer.material = material;
            yield return null;
        }
    }
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = staticMaterial;
        
        onHover.AddListener(distance =>
        {
            MaterialSwitch(hoverMaterial);
        });
        
        onInteract.AddListener(distance =>
        {
            StartCoroutine(IMaterialSwitch(interactMaterial));
        });
    }

    private void Update()
    {
        if(!isInteractionInReach)
            MaterialSwitch(staticMaterial);
    }
}