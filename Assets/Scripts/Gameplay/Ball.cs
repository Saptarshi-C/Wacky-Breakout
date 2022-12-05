using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

/// <summary>
/// Controls the Ball
/// </summary>
public class Ball : MonoBehaviour
{
    Rigidbody2D ballRb;
    Timer ballTimer;
    Timer moveTimer;

    BallDiedEvent ballDiedEvent = new BallDiedEvent();
    BallLostEvent ballLostEvent = new BallLostEvent();

    Timer speedupTimer;
    float speedupFactor;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();        
        
        ballTimer = gameObject.AddComponent<Timer>();
        ballTimer.Duration = ConfigurationUtils.BallLifeTime;
        ballTimer.Run();
        ballTimer.AddTimerFinishedListener(BallDeath);

        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 2;
        moveTimer.Run();
        moveTimer.AddTimerFinishedListener(MoveBall);

        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(SpeedupTimerFinishedHandler);
        EventManager.AddSpeedupEffectActivatedListener(SpeedupEffectActivatedHandler);

        EventManager.AddBallDiedInvoker(this);
        EventManager.AddBallLostInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveBall()
    {
        if (ballRb.velocity == Vector2.zero)
        {
            float angle = 270 * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            direction.Normalize();
            float magnitude = ConfigurationUtils.BallImpulseForce;
            if (EffectUtils.SpeedupEffectActive)
            {
                StartSpeedupEffect(EffectUtils.SpeedupTimeLeft, EffectUtils.SpeedupFactor);
                magnitude *= speedupFactor;
            }

            ballRb.AddForce(direction * magnitude, ForceMode2D.Impulse);
        }
    }

    void BallDeath()
    {
        ballDiedEvent.Invoke();
        DestroyBall();
    }

    public void SetDirection(Vector2 direction)
    {
        ballRb.velocity = ballRb.velocity.magnitude * direction;
    }

    private void OnBecameInvisible()
    {

        if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            ballLostEvent.Invoke();
            DestroyBall();
        }
    }

    void DestroyBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        EventManager.RemoveSpeedupEffectActivatedListener(SpeedupEffectActivatedHandler);
        Destroy(gameObject);
    }

    void SpeedupEffectActivatedHandler(float duration, float speedupFactor)
    {
        if(!speedupTimer.Running)
        {
            StartSpeedupEffect(duration, speedupFactor);
            ballRb.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    void StartSpeedupEffect(float duration, float speedupFactor)
    {
        this.speedupFactor = speedupFactor;
        speedupTimer.Duration = duration;
        speedupTimer.Run();
    }

    void SpeedupTimerFinishedHandler()
    {
        speedupTimer.Stop();
        ballRb.velocity *= 1 / speedupFactor;
    }

    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }

    public void AddBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }
}
