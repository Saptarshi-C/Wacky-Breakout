using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectBlock : Block
{
    EffectName effectName;

    [SerializeField]
    Sprite[] blockSprite = new Sprite[2];

    float effectDuration;

    FreezerEffectActivatedEvent freezerEffectActivatedEvent;

    SpeedupEffectActivatedEvent speedupEffectActivatedEvent;

    float speedupFactor;

    public EffectName EffectName
    {
        set { 
            effectName = value;

            SpriteRenderer blockSR = GetComponent<SpriteRenderer>();
            
            if (value == EffectName.Freezer)
            {
                blockSR.sprite = blockSprite[0];
                effectDuration = ConfigurationUtils.FreezerEffectDuration;
                freezerEffectActivatedEvent = new FreezerEffectActivatedEvent();
                EventManager.AddFreezerEffectActivatedInvoker(this);
            }
            else if (value == EffectName.Speedup)
            {
                blockSR.sprite = blockSprite[1];
                effectDuration = ConfigurationUtils.SpeedupEffectDuration;
                speedupFactor = ConfigurationUtils.SpeedupFactor;
                speedupEffectActivatedEvent = new SpeedupEffectActivatedEvent();
                EventManager.AddSpeedupEffectActivatedInvoker(this);
            }
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        BlockPoints = ConfigurationUtils.EffectBlockPoints;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (effectName == EffectName.Freezer)
            {
                freezerEffectActivatedEvent.Invoke(effectDuration);
                EventManager.RemoveFreezerEffectActivatedInvoker(this);
            }
            else if(effectName == EffectName.Speedup)
            {
                speedupEffectActivatedEvent.Invoke(effectDuration,speedupFactor);
                EventManager.RemoveSpeedupEffectActivatedInvoker(this);
            }
        }
        base.OnCollisionEnter2D(collision);
    }

    public void FreezerEffectActivatedEventListener(UnityAction<float> listener)
    {
        freezerEffectActivatedEvent.AddListener(listener);
    }

    public void SpeedupEffectActivatedEventListener(UnityAction<float,float> listener)
    {
        speedupEffectActivatedEvent.AddListener(listener);
    }

    public void RemoveSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedEvent.RemoveListener(listener);
    }
}
