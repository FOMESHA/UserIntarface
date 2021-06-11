using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuButton : MonoBehaviour
{
    [SerializeField] View _activatingView;

    private TMP_Text _buttonText;
    private MenuChanger _menuChanger;
    private bool isActive = false;

    private void Awake()
    {
        _menuChanger = GetComponentInParent<MenuChanger>();
        _buttonText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _menuChanger.OnChangeView += Deactivate;
    }

    private void OnDisable()
    {
        _menuChanger.OnChangeView -= Deactivate;
        isActive = false;
    }

    public void Activate(Color newTextColor)
    {
        isActive = true;
        _activatingView.gameObject.SetActive(true);
        _buttonText.color = newTextColor;
    }

    public void OnClickMenuButton()
    {
        if (!isActive)
            _menuChanger.ChangeMenuView(this);
    }

    private void Deactivate(Color oldTextColor)
    {
        isActive = false;
        _activatingView.gameObject.SetActive(false);
        _buttonText.color = oldTextColor;
    }
}
