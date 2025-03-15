using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IWorker
{
    public bool CanMove;

    public AnimatorSwitcher PlayerAnimatorSwitcher { get; private set; }

    [SerializeField] private Inventory _inventory;
    [SerializeField] private float _carrySpeed = 1;

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

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
            if (_inventory.GetTotalItemsCount() > 0)
            {
                PlayerAnimatorSwitcher.Carry();
                transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, _carrySpeed * Time.deltaTime);
            }
            else
            {
                PlayerAnimatorSwitcher.Walk();
            }
        }
        else
        {
            if (_inventory.GetTotalItemsCount() > 0)
            {
                PlayerAnimatorSwitcher.WaitWithFood();
            }
            else
            {
                PlayerAnimatorSwitcher.Idle();
            }

        }
    }

    public void Work()
    {
        throw new System.NotImplementedException();
    }
}
