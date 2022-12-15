using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2d;
    float halfColliderWidth;
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    private bool isFrozen;
    private bool isSpeedup;

    private Timer freezeTimer;
    private Timer speedupTimer;

    // Start is called before the first frame update
    void Start()
    {
        isFrozen = false;
        isSpeedup = false;

        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;

        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedEventListener(UnfreezePaddle);
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedEventListener(UnspeedupPaddle);

        EventManager.AddFreezerBlockDestroyedListener(FreezePaddle);
        EventManager.AddSpeedupBlockDestroyedListener(SpeedupPaddle);

    }

    private void FixedUpdate()
    {
        if (isFrozen) { return; }

        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector2 moveLocation = transform.position;
            if (isSpeedup)
            {
                moveLocation.x += ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime * ConfigurationUtils.SpeedupMultiplier;
            }
            else
            {
                moveLocation.x += ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            }
            moveLocation.x = CalculateClampedX(moveLocation.x);
            rb2d.MovePosition(moveLocation);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vector2 moveLocation = transform.position;
            if (isSpeedup)
            {
                moveLocation.x -= ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime * ConfigurationUtils.SpeedupMultiplier;

            }
            else
            {
                moveLocation.x -= ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            }
            moveLocation.x = CalculateClampedX(moveLocation.x);
            rb2d.MovePosition(moveLocation);
        }
    }

    float CalculateClampedX(float x)
    {
        if (x < ScreenUtils.ScreenLeft + halfColliderWidth)
        {
            return ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (x > ScreenUtils.ScreenRight - halfColliderWidth)
        {
            return ScreenUtils.ScreenRight - halfColliderWidth;
        }
        else
            return x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            ContactPoint2D[] contactPoint = new ContactPoint2D[1];
            coll.GetContacts(contactPoint);

            if (isTopCollision(contactPoint[0]))
            {
                // calculate new ball direction
                float ballOffsetFromPaddleCenter = transform.position.x -
                    coll.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    halfColliderWidth;
                float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // tell ball to set direction to new direction
                Ball ballScript = coll.gameObject.GetComponent<Ball>();
                ballScript.SetDirection(direction);
            }

        }
    }

    bool isTopCollision(ContactPoint2D cp)
    {
        //return cp.point.y > cp.collider.transform.position.y;
        if (cp.point.x - cp.otherCollider.transform.position.x + halfColliderWidth <= 0.05f &&
            cp.point.x - cp.otherCollider.transform.position.x + halfColliderWidth > 0)
        {
            return false;
        }

        if (Mathf.Abs(cp.point.x) - Mathf.Abs(cp.otherCollider.transform.position.x - halfColliderWidth) <= 0.05f &&
            Mathf.Abs(cp.point.x) - Mathf.Abs(cp.otherCollider.transform.position.x - halfColliderWidth) > 0)
        {
            return false;
        }

        return true;
    }

    private void FreezePaddle(float duration)
    {
        freezeTimer.Duration = duration;
        isFrozen = true;
        freezeTimer.Run();
    }

    private void SpeedupPaddle(float duration)
    {
        speedupTimer.Duration = duration;
        isSpeedup = true;
        speedupTimer.Run();
    }

    private void UnfreezePaddle()
    {
        isFrozen = false;
    }

    private void UnspeedupPaddle()
    {
        isSpeedup = false;
    }

}
