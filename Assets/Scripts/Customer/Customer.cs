using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Customer : MonoBehaviour
{
    public AnimatorSwitcher CustomerAnimatorSwitcher { get; private set; }

    private void Awake()
    {
        CustomerAnimatorSwitcher = new AnimatorSwitcher(GetComponent<Animator>());
    }
}
