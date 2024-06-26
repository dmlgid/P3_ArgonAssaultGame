using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;
    [SerializeField] ParticleSystem explosion;

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
        explosion.Play();
        //�ڽ� ������Ʈ ��Ȱ��ȭ
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke(nameof(ReloadScene), delayTime);

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(index);
    }
}
