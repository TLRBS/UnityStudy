using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UIBase {
    [SerializeField]
    private Button btn1;
    protected override void Awake()
    {
        base.Awake();
        btn1.onClick.AddListener(OnClick1BtnToDo);
    }

    protected override void Start()
    {
        base.Start();
    }

    void OnClick1BtnToDo() {

        AllPanel.NoticePanel.OpenPanel();
    }
}
