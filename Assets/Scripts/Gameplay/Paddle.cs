using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the Paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    Rigidbody2D paddleRb;
    float colliderHalfWidth;
    float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    bool isFrozen = false;
    Timer freezeTimer;

    // Start is called before the first frame update
    void Start()
    {
        paddleRb = GetComponent<Rigidbody2D>();
        colliderHalfWidth = GetComponent<BoxCollider2D>().size.x / 2;

        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedListener(FreezerEffectFinishedHandler);
        EventManager.AddFreezerEffectActivatedListener(FreezerEffectActivatedEventHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horzInput = Input.GetAxis("Horizontal");
        if (horzInput!=0 && !isFrozen)
        {
            Vector2 position = paddleRb.position + Vector2.right * horzInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
            float xPosition = CalculateClampedX(position.x);
            position.x = xPosition;
            paddleRb.MovePosition(position);
        }
    }

    float CalculateClampedX(float xPosition)
    {
        if(xPosition - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            xPosition = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (xPosition + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            xPosition = ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        return xPosition;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && IsColliderTop(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                colliderHalfWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool IsColliderTop(Collision2D coll)
    {
        const float tolerance = 0.05f;

        ContactPoint2D[] contacts = new ContactPoint2D[2];
        coll.GetContacts(contacts);

        if (Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void FreezerEffectActivatedEventHandler(float duration)
    {
        isFrozen = true;

        if(!freezeTimer.Running)
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        else
        {
            freezeTimer.AddTime(duration);
        }
    }

    void FreezerEffectFinishedHandler()
    {
        isFrozen = false;
        freezeTimer.Stop();
    }
}
