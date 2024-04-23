﻿using System;
using System.Collections.Generic;
using System.Text;

using SagaDB.Actor;
using SagaMap.Scripting;

using SagaLib;
//所在地圖:埃米爾族的夢中(30203000) NPC基本信息:微微(13000176) X:15 Y:20
namespace SagaScript.M30203000
{
    public class S13000176 : Event
    {
        public S13000176()
        {
            this.EventID = 13000176;
        }

        public override void OnEvent(ActorPC pc)
        {
            byte x, y;

            pc.CInt["Country"] = 0;

            Say(pc, 13000176, 131, "您好像…有点困惑啊?$R;" +
                                   "$R您是第一次来这里吧?$R;", "蒂塔");

            Say(pc, 13000176, 132, "我是蒂塔，$R;" +
                                   "泰达尼亚第三族的大天使。$R;" +
                                   "$P这里是您的梦境哦!$R;" +
                                   "$R埃米尔的世界是$R;" +
                                   "非常闪耀的星星喔$R;" +
                                   "真是美丽的地方呀。$R;", "蒂塔");

            Say(pc, 13000176, 131, "您用不着担心的，$R;" +
                                   "$R让我带领着您，前往ECO的世界吧!$R;", "蒂塔");

            PlaySound(pc, 2122, false, 100, 50);
            ShowEffect(pc, 5607);
            Wait(pc, 2000);

            PlaySound(pc, 2122, false, 100, 50);
            ShowEffect(pc, 5607);
            Wait(pc, 1000);

            PlaySound(pc, 2122, false, 100, 50);
            ShowEffect(pc, 5607);
            Wait(pc, 2000);

            Say(pc, 13000176, 131, "啊!!$R;" +
                                   "$R…这是…$R;" +
                                   "这是『他们』的电磁波…!?$R;", "蒂塔");

            ShowEffect(pc, 4023);
            Wait(pc, 2000);

            pc.CInt["Beginner_Map"] = CreateMapInstance(50030000, 10023100, 250, 132);

            x = (byte)Global.Random.Next(2, 9);
            y = (byte)Global.Random.Next(2, 4);

            Warp(pc, (uint)pc.CInt["Beginner_Map"], x, y);
        }
    }
}
