using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KnivesPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject  knifeIconPrefab;

    private int knifeCounter = 0;

    private void Awake()
    {
        HitEvent.KnifeLanded += SpendKnife;
        HitEvent.KnifeMissed += SpendKnife;
    }

    public void UpdatePanel(int newAmountOfKnives)
    {
        // Destroys all knife icons and create new ones according to the new amount
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < newAmountOfKnives; i++)
        {
            Instantiate(knifeIconPrefab, transform);
        }

        knifeCounter = 0;
    }

    private void SpendKnife()
    {
        // Changes used knife icon alpha and moves to the next one
        Image knifeImage = transform.GetChild(knifeCounter).GetComponent<Image>();
        Color knifeColor = knifeImage.color;
        knifeColor.a = 0.25f;
        knifeImage.color = knifeColor;

        ++knifeCounter;
    }

    private void OnDestroy()
    {
        HitEvent.KnifeLanded -= SpendKnife;
        HitEvent.KnifeMissed -= SpendKnife;
    }
}
