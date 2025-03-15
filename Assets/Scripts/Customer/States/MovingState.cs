using UnityEngine;

public class MovingState : CustomerBaseState
{
    [SerializeField] private OrderState _orderState;

    [SerializeField] private WayPoints _wayPoints;

    private bool isCurrentState;

    public override void StartState()
    {
        Debug.Log("Moving state");
        customer.CustomerAnimatorSwitcher.CustomerWalk();
        isCurrentState = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCurrentState && other.TryGetComponent(out IOrdable ordable))
        {
            _orderState.Ordable = ordable;
            ChangeState(_orderState);
        }
    }

    public override void UpdateState()
    {
        Vector3 direction = _wayPoints.GetCurrentPoint().position - transform.position;

        if (direction.sqrMagnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            _wayPoints.MoveNext();
        }
    }

    public override void ExitState()
    {
        isCurrentState = false;
    }
}
