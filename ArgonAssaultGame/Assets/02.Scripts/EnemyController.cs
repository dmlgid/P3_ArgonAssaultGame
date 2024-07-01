using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject explosion_FX;
    [SerializeField] GameObject hit_VFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int lifeCount = 3;

    ScoreBoard scoreBoard;
    Rigidbody rb;
    GameObject gameObjectParent;

    private void Start()
    {
        //Find�� ������ ��������, ���� �ϳ��� �����Ҷ����� �ϳ��� ��ü Ÿ���� ã�°� ����� ������.
        scoreBoard = FindObjectOfType<ScoreBoard>();
        gameObjectParent = GameObject.FindWithTag("SpawnAtRuntime"); //tag�� �̿��� ���� ��������
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnParticleCollision()
    {
        // Debug.Log($"{this.name} -- Collision -- {other.gameObject.name}");
        ProcessHit();

        if (lifeCount <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        GameObject explo = Instantiate(hit_VFX, transform.position, Quaternion.identity);
        explo.transform.parent = gameObjectParent.transform;
        lifeCount--;
    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject explo = Instantiate(explosion_FX, transform.position, Quaternion.identity);
        explo.transform.parent = gameObjectParent.transform;
        Destroy(this.gameObject);
    }
}
