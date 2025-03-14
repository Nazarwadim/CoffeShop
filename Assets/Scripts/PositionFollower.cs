using UnityEngine;

public class PositionFollower : MonoBehaviour
{
    [SerializeField] private Transform _transformToFollow;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = _transformToFollow.position + _offset;
    }
}
