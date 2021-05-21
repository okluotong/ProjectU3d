
using SUIFW;
/**
*Description:  UI窗体父类
*定义UI窗体的父类
* 有四个生命周期
* 1.Display显示状态
* 2.Hiding隐藏状态
* 3.ReDisplay再显示状态
* 4.Freeze冻结状态 就是弹出窗体后面的窗体冻结
*History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIFrameWork
{
    //窗体类型
    public class UIType
    {
        /// <summary>
        /// 是否清空"栈集合" 反向切换
        /// </summary>
        public bool isClearStack = false;
        /// <summary>
        /// UI窗体(位置)类型
        /// </summary>
        public UIFormType type = UIFormType.Normal;
        /// <summary>
        ///UI窗体显示类型
        /// </summary>
        public UIFormShowMode mode = UIFormShowMode.Normal;
        /// <summary>
        /// UI窗体透明度类型
        /// </summary>
        public UIFormLucenyType lucenyType = UIFormLucenyType.Lucency;

    }

    public class BaseUI : MonoBehaviour
    {
        public UIType currentUIType { get; set; } = new UIType();

        #region 窗体的四种状态
        /// <summary>
        /// 显示状态
        /// </summary>
        public virtual void ActiveTrue()
        {
            gameObject.SetActive(true);
        }
        /// <summary>
        /// 隐藏状态
        /// </summary>
        public virtual void ActiveFalse()
        {

            gameObject.SetActive(false);
        }
        /// <summary>
        /// 重新显示状态
        /// </summary>
        public virtual void ReActiveTrue()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// 冻结状态
        /// </summary>
        public virtual void Freeze()
        {
            gameObject.SetActive(true);
        }
        #endregion

        #region 封装子类常用方法
        /// <summary>
        /// 注册按钮事件
        /// </summary>
        protected void RigisterBtnOnClick(string btnName, EventTriggerListener.VoidDelegate del)
        {
            Transform btn = UnityHelper.Find(gameObject.transform, btnName);
            EventTriggerListener.Get(btn?.gameObject).onClick = del;
        }

        /// <summary>
        /// 打开UI窗体
        /// </summary>
        /// <param name="UIName"></param>
        protected void OpenUI(string UIName)
        {
            UIManager.instance.ShowUI(UIName);
        }

        /// <summary>
        /// 关闭UI窗体
        /// </summary>
        protected void CloseUI()
        {
            string UIName;
            //int intPos = -1;
            //命名空间+类名
            UIName = GetType().ToString();
            //查询第一次出现在这在第几位
            //intPos = UIName.IndexOf('.');

            //if (intPos != -1)
            //{
            //    UIName = UIName.Substring(intPos + 1);
            //}

            UIManager.instance.CloseUI(UIName);

        }
        #endregion
    }
}