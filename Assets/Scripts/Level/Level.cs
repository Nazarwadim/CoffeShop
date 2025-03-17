using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerConfig _playerStartConfig;

    [SerializeField, Min(1)] private float _saveDuration;
    [SerializeField] private Transition _transition;

    private JsonSaveSystem _saveSystem;

    private Coroutine _saveCoroutine;

    private void Awake()
    {
        _saveSystem = new JsonSaveSystem(_player, _playerStartConfig);
    }

    private void OnApplicationQuit()
    {
        if (_saveCoroutine != null)
        {
            StopCoroutine(_saveCoroutine);
            _saveCoroutine = null;
        }
        _saveSystem.Save();
    }

    private void Start()
    {
        _saveSystem.Load();
        _saveCoroutine = StartCoroutine(SaveCoroutine());
    }

    private IEnumerator SaveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_saveDuration);
            _saveSystem.Save();
        }
    }

    public void OnMenuPressed()
    {
        _transition.TransitionToScene((int)Scenes.MainMenu);
    }
}
