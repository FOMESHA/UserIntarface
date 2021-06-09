using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] Color _activeButtonColor;
    [SerializeField] Color _deactivateButtonColor;

    public event UnityAction<Color> ChangeView;

    public void ChangeMenuView(MenuButton activatingButton)
    {
        ChangeView?.Invoke(_deactivateButtonColor);
        activatingButton.Activate(_activeButtonColor);
    }

    public void ChangeMenu(RectTransform menu)
    {
        menu.gameObject.SetActive(false);
    }
}
