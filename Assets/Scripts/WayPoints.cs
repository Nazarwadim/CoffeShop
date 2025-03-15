using UnityEngine;

public class WayPoints : MonoBehaviour
{
    private Transform[] _wayPoints;
    private int _currentWayPointNumber;

    private void Start()
    {
        _wayPoints = GetComponentsInChildren<Transform>();

        _wayPoints = System.Array.FindAll(_wayPoints, t => t != transform);
    }

    public void MoveNext()
    {
        _currentWayPointNumber++;
        if (_currentWayPointNumber == _wayPoints.Length)
        {
            _currentWayPointNumber = 0;
        }
    }

    public Transform GetCurrentPoint()
    {
        return _wayPoints[_currentWayPointNumber];
    }
}