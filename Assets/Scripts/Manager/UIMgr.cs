using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AllPanel
{
    None,
    /// <summary>
    /// 主界面
    /// </summary>
    MainPanel,
    /// <summary>
    /// 提示界面
    /// </summary>
    NoticePanel,

    Length,
}

public static class UIMgr{

    /// <summary>
    /// 加载进内存的panel
    /// </summary>
    private static Dictionary<AllPanel, UIBase> loadPanels = new Dictionary<AllPanel, UIBase>();
    /// <summary>
    /// 展现的panel
    /// </summary>
    private static List<AllPanel> showPanels = new List<AllPanel>();
    /// <summary>
    /// 隐藏的panel
    /// </summary>
    private static List<AllPanel> hidePanels = new List<AllPanel>();

    private static Dictionary<AllPanel, string> panelPath = new Dictionary<AllPanel,string>{
        {AllPanel.MainPanel, "Main/MainPanel"},
        {AllPanel.NoticePanel, "Notice/NoticePanel"}
    };

    private static readonly string TAG = "[UIMgr]:";
    

    public static string GetPanelPath(AllPanel panel)
    {
        string p = panelPath[panel];

        return AssetMgr.UIPathStr + p;
    }

    public static void OpenPanel(this AllPanel panel, UGUIDelegate action = null)
    {
        OpenPanelIn(panel, action);
    }
    private static void OpenPanelIn(AllPanel panel, UGUIDelegate action = null)
    { 
        GameObject o;
        if(loadPanels.ContainsKey(panel)){
            UIBase ui = loadPanels[panel];
            ui.AddEnterEvent(action);
            ui.OnEnter();
            showPanels.Add(panel);
            
            object oo = hidePanels.Find(p => {
                return p.Equals(panel);
            });
            if (oo == null)
                return;
            else
                hidePanels.Remove(panel);
        }
        else{
            // 从资源文件夹加载UI资源
            string str = GetPanelPath(panel);
            o = AssetMgr.GetInstance().LoadAsset(str);
            SetUIPanelInitState(o);

            UIBase uibase = o.GetComponent<UIBase>();
            loadPanels.Add(panel, uibase);
            showPanels.Add(panel);            
        }
    }
    public static void ClosePanel(this AllPanel panel, UGUIDelegate action = null)
    {
        ClosePanelIn(panel, action);
    }
    private static void ClosePanelIn(AllPanel panel, UGUIDelegate action)
    {
        if (loadPanels.ContainsKey(panel))
        {
            UIBase ui = loadPanels[panel];
            ui.AddExitEvent(action);
            ui.OnExit();
            hidePanels.Add(panel);
            showPanels.Remove(panel);
        }
        else
        {
            Debug.LogError(TAG + "该界面不存在.");
        }
    }

    public static bool GetPanelActive(AllPanel panel)
    { 
        if(showPanels.Contains(panel)){
            return true;
        }
        else
            return false;
    }

    private static GameObject uimgrs;
    public static GameObject FIndUIMgr()
    {
        if(uimgrs == null){
            uimgrs = GameObject.Find("UIMgr");
        }
        return uimgrs;
    }

    public static void SetUIPanelInitState(GameObject o)
    {
        //o.transform.SetParent(FIndUIMgr().transform);
        o.transform.parent = FIndUIMgr().transform;
        o.transform.localScale = Vector3.one;
        o.transform.localPosition = Vector3.zero;
        o.transform.localEulerAngles = Vector3.zero;
    }


}
