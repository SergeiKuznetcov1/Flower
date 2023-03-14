using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyManager : MonoBehaviour
{
    [SerializeField] private SeedsInfoManager _seedsInfo;
    [SerializeField] private TextMeshProUGUI _money;
    public int moneyAmount;
    private void Start() {
        UpdateMoneyText();
    }

    public void IncreaseMoney() {
        moneyAmount += 5;
        UpdateMoneyText();
    }

    public void UpdateMoneyText() => _money.text = "MONEY: " + moneyAmount;

    // Обрабатываем покупку одного из предметов в магазине, функции ниже делают тоже самое
    public void BuyPurpleFlower(int cost) {
        if (cost <= moneyAmount) {
            moneyAmount -= cost;
            UpdateMoneyText();
            _seedsInfo.IncreasePurpleCount();
        }
    }

    public void BuyYellowFlower(int cost) {
        if (cost <= moneyAmount) {
            moneyAmount -= cost;
            UpdateMoneyText();
            _seedsInfo.IncreaseYellowCount();
        }
    }

    public void BuyFertilizer1(int cost) {
        if (cost <= moneyAmount) {
            moneyAmount -= cost;
            UpdateMoneyText();
            _seedsInfo.IncreaseFertilizer1Count();
        }
    }

    public void BuyFertilizer2(int cost) {
        if (cost <= moneyAmount) {
            moneyAmount -= cost;
            UpdateMoneyText();
            _seedsInfo.IncreaseFertilizer2Count();
        }
    }
}
