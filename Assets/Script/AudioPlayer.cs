using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    
    [SerializeField] [Range(0f,1f)] float shootingVolumn = 1f;
    
    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f,1f)] float explosionVolumn=1f;
    static AudioPlayer instance;

    private void Awake() {
        ManageSingleton();
    }
    void ManageSingleton()
    {

        if (instance!=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        PlayClip (shootingClip,shootingVolumn);
    }
    public void PlayExplosionClip()
    {
        PlayClip(explosionClip,explosionVolumn);
    }
    void PlayClip(AudioClip clip, float volumn)
    {
        if (clip!=null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,cameraPos,volumn);
        }
    }
}
