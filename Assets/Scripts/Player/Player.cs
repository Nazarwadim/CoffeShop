using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IWorker, IBuildingBuyer
{
    public AnimatorSwitcher PlayerAnimatorSwitcher { get; private set; }

    [SerializeField] private Inventory _inventory;

    [SerializeField] private Money _money;

    private PlayerData _playerConfig;
    private bool _canMove;

    private void Update()
    {
        if (_canMove)
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
                transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, _playerConfig.CarrySpeed * Time.deltaTime);
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

    public void Work(float duration) {}

    public bool CanAffordBuilding(int cost)
    {
        return _money.Count >= cost;
    }

    public void PurchaseBuilding(int cost)
    {
        _money.RemoveMoney(cost);
    }

    public PlayerData GetPlayerData()
    {
        _playerConfig = new()
        {
            Position = transform.position,
            Money = _money.Count,
            InventoryData = _inventory.GetItems().ToArray(),
            CarrySpeed = _playerConfig.CarrySpeed
        };
        return _playerConfig;
    }

    public void Initialize(PlayerData playerData)
    {
        _playerConfig = playerData;

        transform.position = playerData.Position;
        _money.AddMoney(playerData.Money);
        _inventory.SetItems(playerData.InventoryData);

        PlayerAnimatorSwitcher = new AnimatorSwitcher(GetComponent<Animator>());

        _canMove = true;
    }
}
