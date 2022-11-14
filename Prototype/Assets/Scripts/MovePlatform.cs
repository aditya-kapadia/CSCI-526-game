using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlatform : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 lastPlatformPosition;

    [SerializeField] private Text PlatformCountText;
    public static int platformsLeft;
    public static int platformsUsed = 0;
    public GameObject target;
    private bool scriptEnabled;
    private bool platformMoved;

    private SpriteRenderer sprite;
    private Color color;

    private void Start()
    {
        scriptEnabled = true;
        platformMoved = false;

        // Make platform invisible
        sprite = gameObject.GetComponent<SpriteRenderer>();
        color = sprite.color;
        color.a = 0;
        sprite.color = color;
    }
    private void OnDisable()
    {
        scriptEnabled = false;
    }

    private void OnEnable()
    {
        scriptEnabled = true;
    }

    private void OnMouseDown()
    {
        if (scriptEnabled)
        {
            // First delete demo cursor and platform
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Demo"))
            {
                Destroy(obj);
            }

            // Turn platform visible
            color.a = 1;
            sprite.color = color;

            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            lastPlatformPosition = transform.position;

            // Turn isTrigger on so player cannot collide platforms with self while placing them
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnMouseDrag()
    {
        if (scriptEnabled)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;

            if (gameObject.CompareTag("FallingPlatform"))
            {
                gameObject.GetComponent<FallingPlatform>().UpdatePosition();
            }
            if (gameObject.CompareTag("FlyingPlatform"))
            {
                gameObject.GetComponent<level4_immovable>().UpdatePosition();
            }

            platformMoved = true;
        }

    }

    private void OnMouseUp()
    {
        if (scriptEnabled)
        {
            // Turn isTrigger off when player is no longer moving platform
            GetComponent<BoxCollider2D>().isTrigger = false;

            if (platformMoved)
            {

                // Disable platform movement if user placed platform directly under player sprite
                Collider2D platformCollider = gameObject.GetComponent<Collider2D>();
                Collider2D playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
                if (platformCollider.IsTouching(playerCollider))
                {
                    gameObject.GetComponent<MovePlatform>().enabled = false;
                    if (gameObject.CompareTag("FallingPlatform"))
                        gameObject.GetComponent<FallingPlatform>().TriggerFall();
                }

                // Adjust platform count
                platformsLeft = int.Parse(PlatformCountText.text);


                if (platformsLeft == 1)
                {
                    platformsLeft--;
                    platformsUsed++;
                    PlatformCountText.text = platformsLeft.ToString();
                    if (target == null)
                    {
                        return;
                    }
                    Animator otherAnimator = target.GetComponent<Animator>();
                    if (otherAnimator != null)
                    {
                        otherAnimator.StopPlayback();
                        otherAnimator.enabled = false;
                    }
                    return;
                }

                if (platformsLeft == 0)
                {
                    return;
                }
                platformsLeft--;
                PlatformCountText.text = platformsLeft.ToString();
                platformsUsed++;

            }
        }
    }
}
