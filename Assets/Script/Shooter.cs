using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header ("General")]
    [SerializeField] GameObject projecttilePrefab;
    [SerializeField] float  projecttileSpeed = 10f;
    [SerializeField] float projecttileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    
    [Header("AI")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minFiringRate = 0.1f;
    [SerializeField] bool useAI;

    public bool isFire;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    private void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFire=true;
        }
    }

    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFire && firingCoroutine ==null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (firingCoroutine != null && !isFire)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine =null;
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject Instance = Instantiate (projecttilePrefab, transform.position,Quaternion.identity);
            Rigidbody2D rigidbody2D = Instance.GetComponent<Rigidbody2D>();
            if (rigidbody2D!=null)
            {
                rigidbody2D.velocity =transform.up*projecttileSpeed;
            }
            Destroy(Instance,projecttileLifetime);
            float firingRate = UnityEngine.Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            firingRate = Mathf.Clamp (firingRate,minFiringRate,float.MaxValue);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds (firingRate);
        }
    }
}
