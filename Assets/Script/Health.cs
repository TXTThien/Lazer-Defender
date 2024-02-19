using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int point=50;
    [SerializeField] int health = 10;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    Score score;
    LevelManager levelManager;
    private void Awake() {
        cameraShake=Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        score = FindObjectOfType<Score>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        DamageDeal damageDeal = other.GetComponent<DamageDeal>();
        if (damageDeal!=null)
        {
            TakeDamage(damageDeal.GetDamage()); 
            PlayHitEffect();
            audioPlayer.PlayExplosionClip();
            ShakeCamera();
            damageDeal.Hit();
        }
    }
    void TakeDamage (int i)
    {
        health -= i;
        if (health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            score.ModifyScore(point);
        }
        else if (isPlayer)
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }


    void PlayHitEffect()
    {
        if (hitEffect!=null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration +instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if(cameraShake!=null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
