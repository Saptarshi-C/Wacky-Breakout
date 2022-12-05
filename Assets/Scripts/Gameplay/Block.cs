using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    int blockPoints;

    PointsAddedEvent pointsAddedEvent = new PointsAddedEvent();

    BlockDestroyedEvent blockDestroyedEvent = new BlockDestroyedEvent();

    protected int BlockPoints
    {
        set { blockPoints = value; }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        EventManager.AddPointsAddedInvoker(this);
        EventManager.AddBlockDestroyedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            pointsAddedEvent.Invoke(blockPoints);
            EventManager.RemovePointsAddedInvoker(this);
            blockDestroyedEvent.Invoke();
            EventManager.RemoveBlockDestroyedInvoker(this);
            Destroy(gameObject);
        }
    }

    public void AddPointsAddedEventListener(UnityAction<int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    public void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedEvent.AddListener(listener);
    }
}
