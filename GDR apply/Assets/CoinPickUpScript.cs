using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinPickUpScript : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject[] coins;
    [SerializeField] private GameObject winScreen;
    private int points;
    private void Start()
    {
            coins = GameObject.FindGameObjectsWithTag("Coin");
    }
    
    private void Update()
    {
        if (points== coins.Length)
        {
            winScreen.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            points++;
            Destroy(other.gameObject);
            pointsText.text = "Монет собрано: " + points;
        }

    }

}
