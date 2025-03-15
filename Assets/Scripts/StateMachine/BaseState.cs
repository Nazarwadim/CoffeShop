using UnityEngine;

[RequireComponent(typeof(StateProcessor))]
public class BaseState : MonoBehaviour
{
    private StateProcessor _stateMashine;

    protected virtual void Start()
    {
        _stateMashine = GetComponent<StateProcessor>();
    }

    public void ChangeState(BaseState newState)
    {
        _stateMashine.ChangeState(newState);
    }

    public virtual void StartState() { }
    public virtual void ExitState() { }

    public virtual void UpdateState() { }
}
