using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;

    ScoreBoard scoreBoard;

    private void Start()
    {
        //Find�� ������ ��������, ���� �ϳ��� �����Ҷ����� �ϳ��� ��ü Ÿ���� ã�°� ����� ������.
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        // Debug.Log($"{this.name} -- Collision -- {other.gameObject.name}");
        ProcessHit();
        KillEnemy();
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }

    private void KillEnemy()
    {
        GameObject explo = Instantiate(explosion, transform.position, Quaternion.identity);
        explo.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
