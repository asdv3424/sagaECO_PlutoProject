using System;
using System.Collections.Generic;
using System.Text;

using SagaDB.Actor;
using SagaMap.Scripting;
//所在地圖:下城(10024000) NPC基本信息:商人前輩(18000046) X:168 Y:116
namespace SagaScript.M10024000
{
    public class S18000046 : Event
    {
        public S18000046()
        {
            this.EventID = 18000046;
        }

        public override void OnEvent(ActorPC pc)
        {

        }
    }
}
