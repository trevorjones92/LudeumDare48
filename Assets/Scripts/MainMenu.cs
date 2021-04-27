using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton, exitGameButton, ammo, fuel, fuelUsage;
    public Text currentBalance;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);
        ammo.onClick.AddListener(UpgradeAmmoCapacity);
        fuel.onClick.AddListener(UpgradeFuelCapacity);
        fuelUsage.onClick.AddListener(DecreaseFuelUsage);
    }

    void Update()
    {
        currentBalance.text = CoinPickup.PlayerCoins.ToString();
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void UpgradeAmmoCapacity()
    {
        if (CoinPickup.PlayerCoins >= 10)
        {
            Weapon.bullets += 5;
            CoinPickup.PlayerCoins -= 10;
        }
    }

    void UpgradeFuelCapacity()
    {
        if (CoinPickup.PlayerCoins >= 10)
        {
            PlayerFuel.maxShipFuel += 20;
            CoinPickup.PlayerCoins -= 10;
        }
    }

    void DecreaseFuelUsage()
    {
        if (CoinPickup.PlayerCoins >= 10 && PlayerFuel.fuelUsageRate > 0)
        {
            PlayerFuel.fuelUsageRate -= .01f;
            CoinPickup.PlayerCoins -= 10;
        }      
    }
}
