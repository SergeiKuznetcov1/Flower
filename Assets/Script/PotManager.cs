using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PotManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SeedsInfoManager _seedsInfo;
    [SerializeField] private GameObject _purpleFlower;
    [SerializeField] private GameObject _yellowFlower;
    [SerializeField] private Transform _pots; 
    public bool hasPlant;
    public bool combaned;
    // Создаём объект цветка рядом с горшком
    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasPlant == false) {
            if (_seedsInfo.lastPickedFlower == SeedsInfoManager.Flower.Purple && _seedsInfo.purpleCount > 0) {
                GameObject flower = Instantiate(_purpleFlower, transform.position + new Vector3(0.0f, 150.0f, 0.5f), Quaternion.identity, _pots);
                flower.GetComponent<DragDrop>().flowerPot = this;
                _seedsInfo.DecreasePurpleCount();
                if (_seedsInfo.purpleCount == 0)
                    _seedsInfo.lastPickedFlower = SeedsInfoManager.Flower.None;
                hasPlant = true;
            }
            if (_seedsInfo.lastPickedFlower == SeedsInfoManager.Flower.Yellow && _seedsInfo.yellowCount > 0) {
                GameObject flower = Instantiate(_yellowFlower, transform.position + new Vector3(0.0f, 150.0f, 0.5f), Quaternion.identity, _pots);
                flower.GetComponent<DragDrop>().flowerPot = this;
                _seedsInfo.DecreaseYellowCount();
                if (_seedsInfo.yellowCount == 0)
                    _seedsInfo.lastPickedFlower = SeedsInfoManager.Flower.None;
                hasPlant = true;
            }
        }
    }
}
