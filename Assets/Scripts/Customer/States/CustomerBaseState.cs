using UnityEngine;

[RequireComponent(typeof(Customer))]
public class CustomerBaseState : BaseState
{
    protected Customer customer;

    protected override void Start()
    {
        base.Start();
        customer = GetComponent<Customer>();
    }
}
