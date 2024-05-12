using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public abstract class CardBehaviour : MonoBehaviour
{
    //该次下注开始时调用 --- 相当于Start() 执行卡牌的初始化
    public virtual void OnTimeStart(Card card)
    {

    }
    //点击下注按钮时调用
    public virtual void OnBet(Card card)
    {

    }
    //触发该卡效果时调用
    public abstract void OnAward(Card card);
    //结算该卡分数时调用
    public abstract float OnSettle(Card card);
    //抽完时调用
    public virtual void OnChosen(Card card)
    {

    }
    //该次下注结束时调用
    public virtual void OnTimeEnd(Card card)
    {

    }
    //被添加到牌组中时调用
    public virtual void OnAdd(Card card)
    {

    }
    //从牌组中移除时调用
    public virtual void OnRemove(Card card)
    {

    }

    public virtual void OnUnChosen(Card card)
    {
        
    }
}
