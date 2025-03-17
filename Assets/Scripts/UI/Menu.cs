using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Transition _transition;
    [SerializeField] private GameObject _settings;

    public void OnSettingsPressed()
    {
        _transition.TransitionInScene(gameObject, _settings);
    }

    public void OnPlayPressed()
    {
        _transition.TransitionToScene((int)Scenes.SampleScene);
    }
}
