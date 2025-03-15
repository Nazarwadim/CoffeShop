using UnityEngine;

public class GoingOutsideState : CustomerBaseState
{
    [SerializeField] private MovingState _movingState;

    [SerializeField] private WayPoints _wayPoints;

    public override void StartState()
    {
        customer.CustomerAnimatorSwitcher.CustomerWalk();
        Vector3 direction = _wayPoints.GetCurrentPoint().position - transform.position;

        if (direction.sqrMagnitude <= 0.01f)
        {
            _wayPoints.MoveNext();
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
            ChangeState(_movingState);
        }
    }
}
