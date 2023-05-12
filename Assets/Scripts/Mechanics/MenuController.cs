using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private PanelMove _tutorialPanel;

    private void Start()
    {
        _playButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Game");
        });
        
        _tutorialButton.onClick.AddListener(delegate
        {
            _tutorialPanel.Move();
        });
        
        _exitButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }
}
