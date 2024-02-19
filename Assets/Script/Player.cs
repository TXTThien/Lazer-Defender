using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    
    Shooter shooter;
    Vector2 input;
    Vector2 minBounds;
    Vector2 maxBounds;
    private void Awake() {
        shooter = GetComponent<Shooter>();
    }
    private void Start() {
        InitBound();
    }
    void Update()
    {
        Move();
    }
    void InitBound()
    {
        Camera mainCamera = Camera.main;
        minBounds=mainCamera.ViewportToWorldPoint(new Vector2 (0,0));
        maxBounds= mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    private void Move()
    {
        Vector3 delta = input*speed*Time.deltaTime;
        Vector2 newpos= new Vector2();
        newpos.x=Mathf.Clamp(transform.position.x + delta.x,minBounds.x+ paddingLeft,maxBounds.x-paddingLeft);
        newpos.y=Mathf.Clamp(transform.position.y + delta.y,minBounds.y+paddingBottom,maxBounds.y-paddingTop);
        transform.position=newpos;

    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
    void OnFire (InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFire = value.isPressed;
        }
    }
}
