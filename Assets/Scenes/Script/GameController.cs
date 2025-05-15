using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int carrotCollected;

    [SerializeField] private TMP_Text carrotCounterText;
    private void Start()
    {
        carrotCollected = 0;
        carrotCounterText.text = "Carrot Count: " + carrotCollected;
    }  

    public void AddCarrotCount()
    {
        carrotCollected++;
        carrotCounterText.text = "Carrot Count: " + carrotCollected;
    }
}
