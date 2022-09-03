using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveStablePlatform : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool platformMoved = false;
    private Vector3 lastPlatformPosition;

    [SerializeField] private Text PlatformStableCountText;
    private int stablePlatformsLeft;

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
        if (platformMoved && lastPlatformPosition == new Vector3(-11.07f, 5.99f, 0))
        {
            stablePlatformsLeft = int.Parse(PlatformStableCountText.text);
            stablePlatformsLeft--;
            PlatformStableCountText.text = stablePlatformsLeft.ToString();

        }
    }
}
