using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayObject : MonoBehaviour
{
    public float power;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    private Camera cam;
    private Vector2 defScale;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    private Vector2 startPos;

    public bool isReady;
    
    public TrailRenderer tr;

    public float speed;

    void Start()
    {
        cam = Camera.main;
        defScale = transform.localScale;
        startPos = transform.localPosition;
        tr.enabled = false;
        
        transform.DOLocalMoveY(transform.position.y + 25,0).OnComplete(() =>
        {
            tr.enabled = true;
        });
        
        TimeManager.Instance.transform.DOMoveX(0, 0.1f).OnComplete(() =>
        {
            transform.DOLocalMove(startPos,0.35f).SetEase(Ease.InQuad).OnComplete(() =>
            {
                Ready();
                transform.DOPunchScale(new Vector3(0.15f, -0.2f), 0.2f);
            });
        });
        
    }

    public void Ready()
    {
        TimeManager.Instance.transform.DOMoveX(0, 0.1f).OnComplete(() =>
        {
            isReady = true;
        });
       
    }

    
    private void Update()
    {
        speed = rb.velocity.magnitude;
        
        if (isReady && GameManager.Instance.ls.moveLeft > 0)
        {
           
            
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }

            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector2.zero;
                
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                    Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                rb.AddTorque(power / 5, ForceMode2D.Impulse);
                
                
                transform.DOPunchScale(new Vector3(0.05f, 0.05f), 0.3f,0).OnComplete(() =>
                {
                    transform.DOScale(defScale, 0.1f);
                });
                
                if (GameManager.Instance.ls.moveLeft == 1)
                {
                    TimeManager.Instance.transform.DOMoveX(0, 1.25f).OnComplete(() =>
                    {
                        GameManager.Instance.ls.lastShot = true;
                    });
                }
                
                GameManager.Instance.ls.moves++;
                GameManager.Instance.ls.moveLeft--;
                UIManager.Instance.CheckMoveLeft();

               

            }

            if (GameManager.Instance.ls.moveLeft <= 0 && speed <= 0.015f && GameManager.Instance.ls.lastShot)
            {
                Destroy(gameObject);
                GameManager.Instance.GameLose();
            }
            
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isReady && speed > 5)
        {
            cam.transform.DOShakePosition(0.2f, 0.1f);
            
            transform.DOPunchScale(new Vector3(0.05f, 0.05f), 0.2f,25).OnComplete(() =>
            {
                transform.DOScale(defScale, 0.1f);
            });
        }
       
    }
}
