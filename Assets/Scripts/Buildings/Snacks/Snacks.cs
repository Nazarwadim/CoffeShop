using System;
using System.Collections.Generic;
using UnityEngine;

public class Snacks : MonoBehaviour, IOrdable
{
    [SerializeField] private float _timeToOrder;
    [SerializeField] private int _moneyForCustomer;
    [SerializeField] private Money _money;

    private readonly Queue<IOrderer> _customersQueue = new();

    private IWorker _worker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IWorker worker))
        {
            _worker = worker;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IWorker worker) && _worker == worker)
        {
            _worker = null;
        }
    }

    public void Order(IOrderer customer)
    {
        _customersQueue.Enqueue(customer);
        if (_customersQueue.Count == 1)
        {
            InvokeRepeating(nameof(OrderInQueue), _timeToOrder, _timeToOrder);
        }
    }

    private void OrderInQueue()
    {
        if (_worker == null)
        {
            return;
        }

        IOrderer customer = _customersQueue.Dequeue();
        customer.Ordered();
        _money.AddMoney(_moneyForCustomer);

        if (_customersQueue.Count == 0)
        {
            CancelInvoke(nameof(OrderInQueue));
        }
    }
}
