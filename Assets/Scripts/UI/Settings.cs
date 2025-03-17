using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private Transition _transition;
    [SerializeField] private GameObject _menu;

    public void OnMenuPressed()
    {
        _transition.TransitionInScene(gameObject, _menu);
    }
}
