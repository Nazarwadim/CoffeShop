using UnityEngine;

public class AnimatorSwitcher
{
    public AnimatorSwitcher(Animator animator)
    {
        _animator = animator;
    }

    private readonly Animator _animator;

    public void WaitWithFood()
    {
        if (_animator.GetBool("idleWithFood") == true)
            return;
        _animator.SetBool("idleWithFood", true);
        _animator.SetBool("walking", false);
        _animator.SetBool("idle", false);
        _animator.SetBool("walkingWithFood", false);
    }
    public void Walk()
    {
        if (_animator.GetBool("walking") == true)
            return;
        _animator.SetBool("idleWithFood", false);
        _animator.SetBool("walking", true);
        _animator.SetBool("idle", false);
        _animator.SetBool("walkingWithFood", false);
    }
    public void Idle()
    {
        if (_animator.GetBool("idle") == true)
            return;
        _animator.SetBool("idleWithFood", false);
        _animator.SetBool("walking", false);
        _animator.SetBool("idle", true);
        _animator.SetBool("walkingWithFood", false);
    }
    public void Carry()
    {
        if (_animator.GetBool("walkingWithFood") == true)
            return;
        _animator.SetBool("idleWithFood", false);
        _animator.SetBool("walking", false);
        _animator.SetBool("idle", false);
        _animator.SetBool("walkingWithFood", true);
    }
    public void CustomerWalk()
    {
        _animator.SetBool("standIdle", false);
        _animator.SetBool("walking", true);
        _animator.SetBool("eating", false);
        _animator.SetBool("idle", false);
    }
    public void CustomerSit()
    {
        _animator.SetBool("standIdle", false);
        _animator.SetTrigger("standToSit");
        _animator.SetBool("walking", false);
        _animator.SetBool("eating", false);
        _animator.SetBool("idle", false);
    }
    public void CustomerOrder()
    {
        _animator.SetBool("standIdle", false);
        _animator.SetTrigger("order");
        _animator.SetBool("walking", false);
        _animator.SetBool("eating", false);
        _animator.SetBool("idle", false);
    }
    public void CustomerSitIdle()
    {
        _animator.SetBool("standIdle", false);
        _animator.SetBool("walking", false);
        _animator.SetBool("eating", false);
        _animator.SetBool("idle", true);
    }
    public void CustomerStand()
    {
        _animator.SetBool("standIdle", false);
        _animator.SetTrigger("sitToStand");
        _animator.SetBool("walking", false);
        _animator.SetBool("eating", false);
        _animator.SetBool("idle", false);
    }
    public void CustomerEat()
    {
        _animator.SetBool("standIdle", false);
        _animator.SetBool("idle", false);
        _animator.SetBool("walking", false);
        _animator.SetBool("eating", false);
    }
    public void CustomerStandIdle()
    {
        _animator.SetBool("standIdle", true);
        _animator.SetBool("idle", false);
        _animator.SetBool("walking", false);
        _animator.SetBool("eating", false);
    }
}
