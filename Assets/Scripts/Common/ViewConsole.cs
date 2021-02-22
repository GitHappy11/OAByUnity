/****************************************************
    文件：ViewConsole.cs
	作者：Chinar 
    日期：2021年2月6日19:48:42
	功能：可视化控制台
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class ViewConsole : MonoBehaviour
{

        struct Log
        {
            public string  Message;
            public string  StackTrace;
            public LogType LogType;
        }


        #region Inspector 面板属性

        [Tooltip("快捷键-开/关控制台")]  public KeyCode ShortcutKey       = KeyCode.BackQuote;
        [Tooltip("摇动开启控制台？")]    public bool    ShakeToOpen       = true;
        [Tooltip("窗口打开加速度")]     public float   shakeAcceleration = 3f;
        [Tooltip("是否保持一定数量的日志")] public bool    restrictLogCount  = false;
        [Tooltip("最大日志数")]       public int     maxLogs           = 1000;

        #endregion

        private readonly List<Log> logs = new List<Log>();
        private          Log       log;
        private          Vector2   scrollPosition;
        private          bool      visible;
        public           bool      collapse;

        static readonly Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>
        {
            {LogType.Assert, Color.white},
            {LogType.Error, Color.red},
            {LogType.Exception, Color.red},
            {LogType.Log, Color.white},
            {LogType.Warning, Color.yellow},
        };

        private const string     ChinarWindowTitle = "0A系统-开发者控制台";
        private const int        Edge              = 20;
        readonly      GUIContent clearLabel        = new GUIContent("清空", "清空控制台内容");
        readonly      GUIContent hiddenLabel       = new GUIContent("合并信息", "隐藏重复信息");

        readonly Rect titleBarRect = new Rect(0, 0, 10000, 20);
        Rect          windowRect   = new Rect(Edge, Edge, Screen.width - (Edge * 2), Screen.height - (Edge * 2));


        void OnEnable()
        {

            Application.logMessageReceived += HandleLog;

        }


        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }


        void Update()
        {
            if (Input.GetKeyDown(ShortcutKey)) visible= !visible;
            if (ShakeToOpen && Input.acceleration.sqrMagnitude > shakeAcceleration) visible = true;
        }


        void OnGUI()
        {
            if (!visible) return;
            windowRect = GUILayout.Window(666, windowRect, DrawConsoleWindow, ChinarWindowTitle);
        }


        void DrawConsoleWindow(int windowid)
        {
            DrawLogsList();
            DrawToolbar();
            GUI.DragWindow(titleBarRect);
        }


        void DrawLogsList()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            for (var i = 0; i < logs.Count; i++)                        
            {
                if (collapse && i > 0) if (logs[i].Message != logs[i - 1].Message) continue; 
                GUI.contentColor = logTypeColors[logs[i].LogType];
                GUILayout.Label(logs[i].Message+logs[i].StackTrace);
            }
            GUILayout.EndScrollView();     
            GUI.contentColor = Color.white; 
        }


        void DrawToolbar()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(clearLabel))
            {
                logs.Clear();
            }

            collapse = GUILayout.Toggle(collapse, hiddenLabel, GUILayout.ExpandWidth(false));
            GUILayout.EndHorizontal();
        }


        void HandleLog(string message, string stackTrace, LogType type)
        {
        logs.Add(new Log
        {
                Message = "["+System.DateTime.Now +"]"+ message,
                StackTrace = stackTrace,
                LogType = type,
            });
        if (type==LogType.Error||type==LogType.Exception)
        {
            string tips = "已经定位错误来源，请将错误代码提供给技术人员！\n最好能够记住发生错误时实行的操作！以便错误复现！\n" + message +  "\n" + "详细内容请按~打开控制台查看！程序已启动保护措施！点击确认键安全退出！";
            OARoot.Instance.AddDynTips(tips, "发生严重错误！程序即将退出！",OARoot.Instance.ExitGame);
        }
        DeleteExcessLogs();
        }


        void DeleteExcessLogs()
        {
            if (!restrictLogCount) return;
            var amountToRemove = Mathf.Max(logs.Count - maxLogs, 0);
            print(amountToRemove);
            if (amountToRemove == 0)
            {
                return;
            }

            logs.RemoveRange(0, amountToRemove);
        }

}