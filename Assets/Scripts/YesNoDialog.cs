using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class YesNoDialog
{
    //NOTE: If the panel you're using doesn't have title or message, the value passed in will be ignored
    public static void ShowDialog(GameObject panel, string title, string message, string button1Text, Action clicked1, string button2Text, Action clicked2)
    {
        Text[] labels = panel.GetComponentsInChildren<Text>();

        Text lblTitle = labels.FirstOrDefault(o => o.name == "Title");
        if (lblTitle != null)
            lblTitle.text = title ?? "";

        Text lblMsg = labels.FirstOrDefault(o => o.name == "Message");
        if (lblMsg != null)
            lblMsg.text = message ?? "";

        Button[] buttons = panel.GetComponentsInChildren<Button>();

        var btn1 = buttons.FirstOrDefault(o => o.name == "Button1");
        if (btn1 != null)
            SetupButton(panel, btn1, button1Text, clicked1);

        var btn2 = buttons.FirstOrDefault(o => o.name == "Button2");
        if (btn2 != null)
            SetupButton(panel, btn2, button2Text, clicked2);

        panel.SetActive(true);
    }

    private static void SetupButton(GameObject panel, Button button, string text, Action clicked)
    {
        Text label = button.GetComponentInChildren<Text>();
        if (label != null)
            label.text = text;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            clicked?.Invoke();
            UnityEngine.Object.Destroy(panel);
        });
    }
}
