using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private ScaleAnimation openAnimation;
    [SerializeField] private ScaleAnimation closeAnimation;
    private bool _isOpen = false;
    private PlayerLook _playerLook;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerLook = FindObjectOfType<PlayerLook>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Escape"))
            return;

        if (_isOpen)
            Close();
        else
            Open();
    }

    public void Open()
    {
        if (_isOpen) return;
        _isOpen = true;
        openAnimation.Play();
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        _playerLook.enabled = false;
    }

    public void Close()
    {
        if (!_isOpen) return;
        _isOpen = false;
        closeAnimation.Play();
        
        Cursor.lockState = CursorLockMode.Locked;
        
        _playerLook.enabled = true;
    }
    
    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
