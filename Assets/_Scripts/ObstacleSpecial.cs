using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleSpecial : MonoBehaviour
{
    public int requiredTips;
    public int connectedTips;

    [Space(10)] 
    public GameObject wrongObject;
    public GameObject correctObject;
    [Space(10)]
    public List<Transform> tipTransforms = new List<Transform>();
    public void TipConnected()
    {
        connectedTips++;
        CheckTips();
    }
    
    public void TipRemoved()
    {
        connectedTips--;
        CheckTips();
    }

    public void CheckTips()
    {
        if (connectedTips >= requiredTips)
        {
           ClearedObstacle();
        }
    }

    private void ClearedObstacle()
    {
        wrongObject.SetActive(false);
        correctObject.SetActive(true);

        foreach (var po in GameObject.FindGameObjectsWithTag("PlayObj"))
        {
            Destroy(po);
        }

        correctObject.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0), 0.2f, 60).SetEase(Ease.OutQuad);

        correctObject.GetComponent<SpriteRenderer>().DOColor(Color.green, 0.1f);

        for (int i = 0; i < tipTransforms.Count; i++)
        {
            Destroy(Instantiate(GameManager.Instance.connectParticle, tipTransforms[i].position, Quaternion.identity), 2);
        }
            
        GameManager.Instance.ls.MoveCheck();

        // Camera.main.backgroundColor = GameManager.Instance.bgColors[Random.Range(0, GameManager.Instance.bgColors.Count)];

        GameManager.Instance.GameWin();
    }
}
