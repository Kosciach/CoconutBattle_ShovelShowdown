using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject[] _menus;

    public delegate void CanvasEvent();
    public static event CanvasEvent StartGame;


    public void StartButton()
    {
        StartGame();
        gameObject.SetActive(false);
    }
    public void ChangeMenuButton(GameObject choosenMenu)
    {
        foreach(GameObject menu in _menus) menu.SetActive(false);

        choosenMenu.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
