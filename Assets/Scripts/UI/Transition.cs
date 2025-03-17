using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition : MonoBehaviour
{
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 1f;

    private IEnumerator TransitionToSceneCoroutine(int levelIndex)
    {
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator TransitionInSceneCoroutine(GameObject from, GameObject to)
    {
        yield return new WaitForSeconds(_transitionTime);
        from.SetActive(false);
        to.SetActive(true);

    }

    public void TransitionToScene(int levelIndex)
    {
        _transition.SetTrigger("ToScene");
        StartCoroutine(TransitionToSceneCoroutine(levelIndex));
    }

    public void TransitionInScene(GameObject from, GameObject to)
    {
        _transition.SetTrigger("InScene");
        StartCoroutine(TransitionInSceneCoroutine(from, to));
    }
}
