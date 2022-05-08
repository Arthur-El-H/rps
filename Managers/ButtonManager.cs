using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    [SerializeField] private Camera _cam;

    public static void moveBtn(GameObject btnGameObject, Vector2 targetPos)
    {
        Camera cam = btnGameObject.transform.parent.GetComponent<Canvas>().worldCamera;

        Vector2 goal = cam.WorldToScreenPoint(new Vector3(targetPos.x, targetPos.y, 0));

        RectTransform btnRect = btnGameObject.GetComponent<RectTransform>();
        RectTransform canvRect = btnGameObject.transform.parent.GetComponent<RectTransform>();

        Vector2 btnPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvRect, goal, cam, out btnPos);
        btnRect.anchoredPosition = btnPos;
    }
}
