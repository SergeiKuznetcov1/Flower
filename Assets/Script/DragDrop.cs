using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private SeedsInfoManager.Flower _flowerType;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private FlowersCombanerTracker _combanerTracker;
    [SerializeField] private float _doubleClickWindow;
    private MoneyManager _moneyManager;
    private float _doubleClickTimer;
    private int _numberOfClicks;
    private bool _startTimer;
    private Levels _levels;
    private Vector3 _initPos;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;
    private Vector2 _startingPos;
    public bool combaned;
    public PotManager flowerPot;
    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _startingPos = GetComponent<RectTransform>().anchoredPosition;
        _combanerTracker = FindObjectOfType<FlowersCombanerTracker>();
        _moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void Start() {
        _initPos = transform.position;
        _levels = GetComponent<Levels>();   
    }

    private void Update() {
        if (_startTimer) {
            _doubleClickTimer += Time.deltaTime;
            if (_doubleClickTimer >= _doubleClickWindow) {
                _startTimer = false;
                _doubleClickTimer = 0.0f;
                _numberOfClicks = 0;
            }
        }
    }
    // Проверяет условия для перетягивания цветка и изменяет перетягиваемый цветок
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_levels.curLvl != 2) {
            eventData.pointerDrag = null;
        }
        else if (combaned == true) {
            eventData.pointerDrag = null;
        }
        else {
            _combanerTracker.draggableFlowerType = _flowerType;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0.6f;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }
    // Решает какие действия нужно совершит по окончанию перетягивания цветка
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_combanerTracker.droppedOnFlowerCombaned == false) {
            _rectTransform.anchoredPosition = _startingPos;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1.0f;
            _combanerTracker.draggableFlowerType = SeedsInfoManager.Flower.None;
            _combanerTracker.droppedOnFlowerCombaned = false;
        } else if (_combanerTracker.droppedOnFlowerCombaned == true) {
            _combanerTracker.droppedOnFlowerCombaned = false;
            flowerPot.hasPlant = false;
            Destroy(gameObject);
        }
    }
    // Проверяет можем ли мы уничтожить цветок двойным нажатием
    public void OnPointerDown(PointerEventData eventData)
    {
        _numberOfClicks++;
        if (_levels.curLvl == 2 && _numberOfClicks == 1) {
            _startTimer = true;
        } 
        else if (_levels.curLvl == 2 && _numberOfClicks == 2) {
            if (_doubleClickTimer < _doubleClickWindow) {
                flowerPot.hasPlant = false;
                _moneyManager.IncreaseMoney();
                Destroy(gameObject);
            }
        }
    }
    // Решаем, что делать с цветком НА который перетягиваем другой цветок. Может остаться каким и был, может скомбинироваться в новый
    public void OnDrop(PointerEventData eventData)
    {
        if (combaned == false) {
            _combanerTracker.droppedOnFlowerType = _flowerType;
            if (_combanerTracker.draggableFlowerType != _combanerTracker.droppedOnFlowerType) {
                combaned = true;
                _combanerTracker.droppedOnFlowerCombaned = true;
                GetComponent<Image>().sprite = _sprite;
                _canvasGroup.alpha = 1.0f;
                eventData.pointerDrag.GetComponent<Image>().sprite = null;
                eventData.pointerDrag.GetComponent<CanvasGroup>().alpha = 0.0f;
            }
        }
    }
}
