using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score ;
    static Score instance;

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
    void Update()
    {
        
    }
    public int GetScore()
    {
        return score;
    }
    public void resetScore()
    {
        score=0;
    }
    public void ModifyScore(int value)
    {
        score+=value;
        Mathf.Clamp(score,0,int.MaxValue);
    }
}
