using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Levels : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _timeStep;
    private SeedsInfoManager _seedsInfo;
    public int curLvl;
    private float _secPassed;
    private Image _curImage;

    private void Start() {
        _curImage = GetComponent<Image>();
        _seedsInfo = FindObjectOfType<SeedsInfoManager>();
        ChangeSprite();
    }
    public void ChangeSprite() {
        _curImage.sprite = _sprites[curLvl];
    }
    // Увеличиваем рост цветка со временем и меняет картинки
    private void Update() {
        if (curLvl < _sprites.Length - 1) {
            _secPassed += Time.deltaTime * _seedsInfo.fertilizerBust;
            UpdateSprite();          
        }
    }

    private void UpdateSprite() {
        if (_secPassed > _timeStep) {
            curLvl++;
            _secPassed = 0.0f;
            ChangeSprite();
        }
    }
}
