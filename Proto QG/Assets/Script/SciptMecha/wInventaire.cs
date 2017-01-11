using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eeGames.Widget;

public class wInventaire : Widget {
    [SerializeField] private Button open;
    [SerializeField] private Button close;

    protected override void Awake() {
        open.onClick.AddListener(openInv);
        close.onClick.AddListener(closeInv);
    }

    void OnDestroy() {
        open.onClick.RemoveListener(openInv);
        close.onClick.RemoveListener(closeInv);
        base.DestroyWidget();
    }

    void openInv() {
        WidgetManager.Instance.Push(WidgetName.inventaire, false, true);
    }

    void closeInv() {
        WidgetManager.Instance.Pop(false);
    }

}
