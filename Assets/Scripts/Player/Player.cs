using UnityEngine;

public class Player : MonoBehaviour
{
    public bool CanMove;

    public AnimatorSwitcher PlayerAnimatorSwitcher { get; private set; }

    private void Start()
    {
        PlayerAnimatorSwitcher = new AnimatorSwitcher(GetComponent<Animator>());
    }

    private void Update()
    {
        if (CanMove)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            PlayerAnimatorSwitcher.Walk();
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        else
        {
            PlayerAnimatorSwitcher.Idle();
        }
    }
}