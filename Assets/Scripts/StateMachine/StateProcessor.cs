using UnityEngine;

public class StateProcessor : MonoBehaviour
{
    [SerializeField] private BaseState _currentState;

    private void Start()
    {
        if (_currentState)
        {
            _currentState.StartState();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (_currentState)
        {
            _currentState.ExitState();
            _currentState = newState;
        }

        if (_currentState)
        {
            _currentState.StartState();
        }
    }

    private void Update()
    {
        if (_currentState)
        {
            _currentState.UpdateState();
        }
    }

    private void OnDestroy()
    {
        if (_currentState)
        {
            _currentState.ExitState();
        }
    }
}
