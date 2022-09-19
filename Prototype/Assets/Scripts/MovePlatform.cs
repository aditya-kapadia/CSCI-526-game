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
    private int platformsLeft;

    public GameObject target;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        lastPlatformPosition = transform.position;
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
        if (platformMoved && lastPlatformPosition == new Vector3(-11.0f, 6.0f, 0))
        {
            platformsLeft = int.Parse(PlatformCountText.text);

            
            if (platformsLeft == 1)
            {
                platformsLeft--;
                PlatformCountText.text = platformsLeft.ToString();
                Animator otherAnimator = target.GetComponent<Animator>();
                otherAnimator.StopPlayback();
                Debug.Log(platformsLeft);
                otherAnimator.enabled = false;
                return;
            }
            platformsLeft--;
            PlatformCountText.text = platformsLeft.ToString();
        }
        
    }
}
