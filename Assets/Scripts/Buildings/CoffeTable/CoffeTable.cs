using System;
using System.Collections.Generic;
using UnityEngine;

public class CoffeTable : MonoBehaviour, IOrdable
{
    [SerializeField] private float _timeToOrder;

    private readonly Queue<IOrdered> _customersQueue = new();

    public void Order(IOrdered customer)
    {
        _customersQueue.Enqueue(customer);
        if(_customersQueue.Count == 1)
        {
            InvokeRepeating(nameof(OrderInQueue), _timeToOrder, _timeToOrder);
        }
    }

    private void OrderInQueue()
    {
        IOrdered customer = _customersQueue.Dequeue();

        customer.Ordered();

        if(_customersQueue.Count == 0) 
        {
            CancelInvoke(nameof(OrderInQueue));
        }
    }
}
