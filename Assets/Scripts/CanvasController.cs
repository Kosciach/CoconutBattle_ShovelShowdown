using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject[] _menus;
    [SerializeField] RectTransform _planksHolder;
    [SerializeField] GameObject _winnerScreen;

    public delegate void CanvasEvent();
    public static event CanvasEvent StartGame;


    public void StartButton()
    {
        DropPlanksDown();
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

    public void SetWinner(int winnerIndex)
    {
        _winnerScreen.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Winner: P" + winnerIndex.ToString();
        _winnerScreen.SetActive(true);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }


    private void DropPlanksDown()
    {
        Vector3 targetPosition = new Vector3(-400, -441, 0f);
        float targetRotation = 68.219f;

        _planksHolder.LeanRotateZ(targetRotation, 1f).setEaseInBack();
        _planksHolder.LeanMove(targetPosition, 1f).setEaseInBack().setOnComplete(() => 
        {
            StartGame();
            _menus[0].SetActive(false);
            _planksHolder.LeanRotateZ(0, 0.5f);
            _planksHolder.LeanMove(Vector3.zero, 0.5f);
        });
    }
}
