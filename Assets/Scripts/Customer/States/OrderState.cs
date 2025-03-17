using UnityEngine;

public class OrderState : CustomerBaseState, IOrderer
{
    [SerializeField] private GoingOutsideState _goingOutsideState;

    public IOrdable Ordable;

    public override void StartState()
    {
        customer.CustomerAnimatorSwitcher.CustomerStandIdle();
        Ordable.Order(this);
    }

    public void Ordered()
    {
        ChangeState(_goingOutsideState);
    }
}
