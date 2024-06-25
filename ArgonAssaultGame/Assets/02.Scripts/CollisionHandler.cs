using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;

    private int index;

    private void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        Invoke(nameof(ReloadScene), delayTime);

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(index);
    }
}
