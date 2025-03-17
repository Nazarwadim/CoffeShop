using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _money.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _money.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int amount)
    {
        _text.text = "Money: " + amount.ToString();
    }
}