using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject explosion_VFX;
    [SerializeField] GameObject hit_VFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int lifeCount = 3;

    ScoreBoard scoreBoard;
    Rigidbody rb;

    private void Start()
    {
        //Find�� ������ ��������, ���� �ϳ��� �����Ҷ����� �ϳ��� ��ü Ÿ���� ã�°� ����� ������.
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        explo.transform.parent = parent;
        scoreBoard.IncreaseScore(scorePerHit);
        lifeCount--;
    }

    private void KillEnemy()
    {
        GameObject explo = Instantiate(explosion_VFX, transform.position, Quaternion.identity);
        explo.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
