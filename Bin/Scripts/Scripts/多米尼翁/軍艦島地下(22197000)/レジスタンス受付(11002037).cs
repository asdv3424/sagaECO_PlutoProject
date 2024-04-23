﻿using System;
using System.Collections.Generic;
using System.Text;

using SagaDB.Actor;
using SagaMap.Scripting;

using SagaLib;
namespace SagaScript.M22197000
{
    public class S11002037 : Event
    {
        public S11002037()
        {
            this.EventID = 11002037;
        }

        public override void OnEvent(ActorPC pc)
        {
            switch (Select(pc, "どうする？", "", "クエストカウンター", "フィールドチャンプについて聞く", "レジスタンスについて聞く", "序盤のオススメの敵は？", "この奥のモンスターについて", "なにもしない"))
            {
                case 1:
                    Say(pc, 131, "小战士。$R;" +
                    "$R愿你高贵的灵魂$R;" +
                    "不要被这世界污染了……。$R;", "抵抗運動接待處");
                    HandleQuest(pc, 61);
                    break;
                case 2:
                    Say(pc, 131, "战场冠军$R;" +
                    "在这个世界只存在10人$R;" +
                    "是一些拥有着特殊能力的人。$R;" +
                    "$P详细信息请咨询总部前面$R;" +
                    "的掲示板的掲示板旁边的$R;" +
                    "戦の調律者$R;", "抵抗運動接待處");
                    break;
                case 3:
                    Say(pc, 131, "我们与侵略者战斗$R;" +
                    "继续着将夺回「阿高普路斯市」为目标$R;" +
                    "的抵抗运动。$R;" +
                    "$P如果你对此有兴趣$R;" +
                    "就到设立在「西部要塞城」$R;" +
                    "的总部报道吧。$R;" +
                    "$P西部要塞城的话$R;" +
                    "要从这里乘坐飛空庭$R;" +
                    "跨过奥克鲁尼亚大陆$R;" +
                    "再穿越沙漠就能到达了。$R;" +
                    "$P西部要塞城附近$R;" +
                    "虽说还算安全，但是$R;" +
                    "途中可能会出现危险的魔物。$R;" +
                    "$P也可以绕道通过，不过$R;" +
                    "如果被缠住了的话$R;" +
                    "可以骑上一个「騎乗宠物」$R;" +
                    "来继续移动哦。$R;", "抵抗運動接待處");
                    break;
                case 4:
                    Say(pc, 11001589, 131, "ＬＶ１～：マリュス$R;" +
                    "ＬＶ５～：ピヨピヨ$R;" +
                    "ＬＶ８～：ゴーチン$R;" +
                    "ＬＶ１３～：マスケシュピンネ$R;" +
                    "ＬＶ１６～：ルナティック$R;", "レジスタンス受付");
                    break;
                case 5:
                    Say(pc, 131, "この奥の地下水路では$R;" +
                    "ドミニオン・トード$R;" +
                    "アーリー・ダイナー$R;" +
                    "ムカーデ・ダイナー$R;" +
                    "といったモンスターが確認されています。$R;" +
                    "$Rこの辺りは実力のある者なら$R;" +
                    "労せず倒せる相手だと思うわ。$R;" +
                    "$Pその先に関しては……$R;" +
                    "$P……ごめんなさい。$R;" +
                    "$Rこちらでも情報が錯綜していて$R;" +
                    "これ以上詳しい事はわからないの。$R;", "レジスタンス受付");
                    break;
            }
        }
    }
}


        
   


