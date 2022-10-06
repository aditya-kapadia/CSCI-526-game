using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlatform : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool platformMoved = false;
    private Vector3 lastPlatformPosition;

    [SerializeField] private Text PlatformCountText;
    public static int platformsLeft;
    public static int platformsUsed = 0;
    public GameObject target;


    void OnMouseDown()
    {

		// First delete example mouse
        Destroy(GameObject.FindWithTag("Cursor"));
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        lastPlatformPosition = transform.position;

        // Turn isTrigger on so player cannot collide platforms with self while placing them
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = curPosition;

        platformMoved = true;

    }

    private void OnMouseUp()
    {
        // Turn isTrigger off when player is no longer moving platform
        GetComponent<BoxCollider2D>().isTrigger = false;

        if (platformMoved && (lastPlatformPosition == new Vector3(-13.0f, 6.0f, 0) || lastPlatformPosition == new Vector3(-10.0f, 6.0f, 0)))
        {
            platformsLeft = int.Parse(PlatformCountText.text);

            
            if (platformsLeft == 1)
            {
                platformsLeft--;
                platformsUsed++;
                PlatformCountText.text = platformsLeft.ToString();
                if(target == null)
                {
                    return;
                }
                Animator otherAnimator = target.GetComponent<Animator>();
                if(otherAnimator != null)
                {
                    otherAnimator.StopPlayback();
                    otherAnimator.enabled = false;
                        //GameObject playButton = GameObject.FindWithTag("InBuildMode");
                        //playButton.GetComponent<BlinkPulse>().enabled = true;
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
