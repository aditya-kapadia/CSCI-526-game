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

    private GameObject playIcon;

    private void Start()
    {
        playIcon = GameObject.FindWithTag("InBuildMode");
    }
    void OnMouseDown()
    {

		// First delete example mouse
        Destroy(GameObject.FindWithTag("Cursor"));
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        lastPlatformPosition = transform.position;
    }

    void OnMouseDrag()
    {
        if (playIcon.activeSelf)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;

            platformMoved = true;
        }

    }

    private void OnMouseUp()
    {
        if (playIcon.activeSelf)
        {
        if (platformMoved && (lastPlatformPosition == new Vector3(-13.0f, 6.0f, 0) || lastPlatformPosition == new Vector3(-10.0f, 6.0f, 0)))
        {
            platformsLeft = int.Parse(PlatformCountText.text);

            
            if (platformsLeft == 1)
            {
                platformsLeft--;
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
                        GameObject playButton = GameObject.FindWithTag("InBuildMode");
                        playButton.GetComponent<BlinkPulse>().enabled = true;
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
