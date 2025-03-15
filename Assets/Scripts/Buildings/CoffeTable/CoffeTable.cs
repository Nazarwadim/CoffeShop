using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeTable : MonoBehaviour, IOrdable
{
    [SerializeField] private float _timeToOrder;
    [SerializeField] private float _timeToMakeCappuccino;
    [SerializeField] private int moneyForCustomer;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Item _cappuccino;
    [SerializeField] private Recipe _cappuccinoRecipe;

    private readonly Queue<IOrdered> _customersQueue = new();

    private Coroutine _makingCappuccino;

    private void Start()
    {
        StartMakingCappuccino();
    }

    private void OnEnable()
    {
        _inventory.InventoryChanged += StartMakingCappuccino;
    }

    private void OnDisable()
    {
        _inventory.InventoryChanged -= StartMakingCappuccino;
    }

    public void Order(IOrdered customer)
    {
        _customersQueue.Enqueue(customer);
        if (_customersQueue.Count == 1)
        {
            InvokeRepeating(nameof(OrderInQueue), _timeToOrder, _timeToOrder);
        }
    }

    private void StartMakingCappuccino()
    {
        if(_makingCappuccino == null)
        {
            _makingCappuccino = StartCoroutine(MakingCappuccino());
        }
    }

    private IEnumerator MakingCappuccino()
    {
        while (_cappuccinoRecipe.CanCraft(_inventory))
        {
            yield return new WaitForSeconds(_timeToMakeCappuccino);
            _cappuccinoRecipe.Craft(_inventory);
        }
        _makingCappuccino = null;
    }

    private void OrderInQueue()
    {
        var item = _inventory.FindItem(_cappuccino);
        if (item.Count == 0)
        {
            return;
        }

        IOrdered customer = _customersQueue.Dequeue();

        customer.Ordered();
        _inventory.RemoveItem(_cappuccino);

        if (_customersQueue.Count == 0)
        {
            CancelInvoke(nameof(OrderInQueue));
        }
    }
}
