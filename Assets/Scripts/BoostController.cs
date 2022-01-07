using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostController : MonoBehaviour
{
    public GameObject boostButton;
    private Button button;
    private Image buttonImage;

    private float waitTime = 0;

    void Start()
    {
        button = boostButton.GetComponent<Button>();
        buttonImage = boostButton.GetComponent<Image>();
    }

    void Update()
    {
        if (!button.interactable)
        {
            if (buttonImage.fillAmount != 1)
            {
                waitTime += Time.deltaTime;
                buttonImage.fillAmount = waitTime / 40;
                if (waitTime > 5)
                {
                    GameController.Instance.isBoostActive = false;
                }
            }
            else
            {
                waitTime = 0;
                button.interactable = true;
            }
        }
    }

    public void ActivateBoost() 
    {
        buttonImage.fillAmount = 0;
        GameController.Instance.isBoostActive = true;
        button.interactable = false;
    }
}
