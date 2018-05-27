using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoticePanel : UIBase {

    [SerializeField]
    private Button confirmBtn;

    [SerializeField]
    private Button cancelBtn;

    protected override void Awake()
    {
        base.Awake();
        confirmBtn.onClick.AddListener(OnClickBtnTOConfirm);
        cancelBtn.onClick.AddListener(OnClickBtnTOConfirm);
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    void OnClickBtnTOConfirm() {
        AllPanel.NoticePanel.ClosePanel();
    }

    void OnClickBtnToCancel()
    {
        AllPanel.NoticePanel.ClosePanel();
    }
}
