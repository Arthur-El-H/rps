using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    [SerializeField] private Camera _cam;

    [SerializeField] private GameObject _moveActionBtnPrefab;
    [SerializeField] private Canvas _canvas;
  
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

    public void setPossibleActionsOnScreen(Player player)
    {
        foreach (int code in player.getPossibleActionsCodes())
        {
            var btn = getActionBtn(code);
        }
    }

    public GameObject getActionBtn( int actionCode)
    {
        switch (actionCode) {
            case Move._code:
                return getMoveActionBtn();
            default:
                throw new methodCallError();
        }
    }

    public GameObject getMoveActionBtn()
    {
        return GameObject.Instantiate(_moveActionBtnPrefab, _canvas.transform);
    }
}
