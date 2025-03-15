using UnityEngine;

[RequireComponent(typeof(Customer))]
public class CustomerBaseState : BaseState
{
    protected Customer customer;

    private void Awake()
    {
        customer = GetComponent<Customer>();
    }
}
