using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int Count{get; private set;}

    public event Action<int> MoneyChanged;

    public void AddMoney(int amount) {
        Count += amount;
        MoneyChanged?.Invoke(Count);
    }

    public void RemoveMoney(int amount)
    {
        if(amount > Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        Count -= amount;
        MoneyChanged?.Invoke(Count);
    }

    public void ResetMoney() {
        Count = 0;
        MoneyChanged?.Invoke(Count);
    }
}
