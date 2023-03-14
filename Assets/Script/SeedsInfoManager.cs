using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SeedsInfoManager : MonoBehaviour
{
    public enum Flower { Purple, Yellow, None };
    [SerializeField] private GameObject _purplePrefab;
    [SerializeField] private GameObject _yellowPrefab;
    [SerializeField] TextMeshProUGUI _purpleText;
    [SerializeField] TextMeshProUGUI _yellowText;
    [SerializeField] TextMeshProUGUI _fertilizer1;
    [SerializeField] TextMeshProUGUI _fertilizer2;
    [SerializeField] TextMeshProUGUI _fertilizerInfo;
    public int purpleCount;
    public int yellowCount;
    public int fertilizer1Count;
    public int fertilizer2Count;
    public float fertilizerBust;
    public Flower lastPickedFlower;
    private void Start() {
        lastPickedFlower = Flower.None;
        _purpleText.text = $"x {purpleCount}"; 
        _yellowText.text = $"x {yellowCount}"; 
        _fertilizer1.text = $"x {fertilizer1Count}"; 
        _fertilizer2.text = $"x {fertilizer2Count}"; 
    }
    // Обновляем текстовые здачения у цветок и удобрения, функции ниже делают тоже самое
    public void IncreasePurpleCount() {
        purpleCount++;
        _purpleText.text = $"x {purpleCount}"; 
    }

    public void DecreasePurpleCount() {
        purpleCount--;
        _purpleText.text = $"x {purpleCount}"; 
    }
    public void IncreaseYellowCount() {
        yellowCount++;
        _yellowText.text = $"x {yellowCount}"; 
    }

    public void DecreaseYellowCount() {
        yellowCount--;
        _yellowText.text = $"x {yellowCount}";
    }

    public void IncreaseFertilizer1Count() {
        fertilizer1Count++;
        _fertilizer1.text = $"x {fertilizer1Count}"; 
    }

    public void DecreaseFertilizer1Count() {
        if (fertilizer1Count > 0) {
            fertilizer1Count--;
            fertilizerBust = 2.0f;
            _fertilizerInfo.text = "Plant grow speed: 2x";
            _fertilizer1.text = $"x {fertilizer1Count}"; 
        }
    }

    public void IncreaseFertilizer2Count() {
        fertilizer2Count++;
        _fertilizer2.text = $"x {fertilizer2Count}"; 
    }

    public void DecreaseFertilizer2Count() {
        if (fertilizer2Count > 0) {
            fertilizer2Count--;
            fertilizerBust = 5.0f;
            _fertilizerInfo.text = "Plant grow speed: 5x";
            _fertilizer2.text = $"x {fertilizer2Count}";
        }
    }
    // Устанавливаем какой цветок был выбран последним
    public void PurpleLastPickedFlower() {
        if (purpleCount > 0) {
            lastPickedFlower = Flower.Purple;
        }
    }

    public void YellowLastPickedFlower() {
        if (yellowCount > 0) {
            lastPickedFlower = Flower.Yellow;
        }
    }
}
