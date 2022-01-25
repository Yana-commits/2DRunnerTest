using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Button jumpBt;
    [SerializeField] private Button tryAgainBt;
    [SerializeField] private Text textLabel;

    public GameObject textPanel;
    public GameObject tryAgainPanel;

    public Action onJump;
    public Action onNextPlay;
    void Start()
    {
        jumpBt.onClick.AddListener(Jump);
        tryAgainBt.onClick.AddListener(NextPlay);
    }

    public void ShowGoText()
    {
        ShowPanel(textPanel);
        textLabel.text = "GO!";
    }
    public void ShowGameOverText()
    {
        ShowPanel(textPanel);
        textLabel.text = "Game Over";
    }
    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void Jump()
    {
        onJump?.Invoke();
    }
    public void NextPlay()
    {
        onNextPlay?.Invoke();
    }
    private void OnDestroy()
    {
        jumpBt.onClick.RemoveListener(Jump);
        tryAgainBt.onClick.RemoveListener(NextPlay);
    }
}
