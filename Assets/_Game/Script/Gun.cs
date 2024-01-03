using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]private Bullet bullet;
    Vector2 direction;
    [SerializeField] private bool autoShoot;
    [SerializeField] private float shootIntervalSeconds = 1f;
    [SerializeField] private float shootDelaySeconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;
    void Update()
    {
        if (GameManager.Instance.IsState(GameState.PLAYING))
        {
            direction = (transform.localRotation * Vector2.right).normalized;

            if (autoShoot)
            {
                if (delayTimer >= shootDelaySeconds)
                {
                    if (shootTimer >= shootIntervalSeconds)
                    {
                        Shoot();
                        shootTimer = 0;
                    }
                    else
                    {
                        shootTimer += Time.deltaTime;
                    }
                }
                else
                {
                    delayTimer += Time.deltaTime;
                }
            }
        }
       
    }
    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, transform.rotation);
        Bullet goBullet = go.GetComponent<Bullet>();
    }
}
