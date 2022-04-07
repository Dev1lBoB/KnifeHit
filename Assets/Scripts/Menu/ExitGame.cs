using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject dialogPanelPrefab;
    public GameObject mainCanvas;

    private CanvasGroup canvasGroup;

    private bool isActive = false;

    private void Start()
    {
        canvasGroup = mainCanvas.GetComponentInChildren<CanvasGroup>();
    }

    private void YesPressed()
    {
        Application.Quit();
    }

    private void NoPressed()
    {
        isActive = false;
        canvasGroup.interactable = true;
    }

    public void Exit()
    {
        if (isActive == true)
            return ;
        isActive = true;

        canvasGroup.interactable = false;
        YesNoDialog.ShowDialog
        (
            Instantiate(dialogPanelPrefab, mainCanvas.transform),
            // dialogPanelPrefab,
            null,
            "Are you sure want to quit?",

            "Yes",
            () => YesPressed(),

            "No",
            () => NoPressed()
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
}
