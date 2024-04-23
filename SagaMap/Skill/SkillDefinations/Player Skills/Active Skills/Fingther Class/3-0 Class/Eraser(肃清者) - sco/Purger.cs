﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SagaDB.Actor;
using SagaMap.Skill.Additions.Global;

namespace SagaMap.Skill.SkillDefinations.Eraser
{
    public class Purger : ISkill
    {
        public int TryCast(ActorPC pc, Actor dActor, SkillArg args)
        {
            return 0;
        }
        public ushort speed_old;
        public void Proc(SagaDB.Actor.Actor sActor, SagaDB.Actor.Actor dActor, SkillArg args, byte level)
        {
            if (!dActor.Status.Additions.ContainsKey("イレイザー"))
            {
                int lifetime = 30000 + 30000 * level;
                Actor RealActor = SkillHandler.Instance.GetPossesionedActor((ActorPC)sActor);
                DefaultBuff skill = new DefaultBuff(args.skill, RealActor, "イレイザー", lifetime, 1000);
                skill.OnAdditionStart += this.StartEventHandler;
                skill.OnAdditionEnd += this.EndEventHandler;
                //skill.OnUpdate += this.UpdateEventHandler;
                SkillHandler.ApplyAddition(RealActor, skill);
            }
            else
            {
                dActor.Status.Additions["イレイザー"].OnTimerEnd();
            }

        }

        //void UpdateEventHandler(Actor actor, DefaultBuff skill)
        //{
        //    if (actor.Speed != 310)
        //    {
        //        actor.Status.speed_skill = -100;
        //        actor.Status.speed_item = 0;
        //    }
        //}
        void StartEventHandler(Actor actor, DefaultBuff skill)
        {

            int speed_add = 100;
            if (skill.Variable.ContainsKey("Eraser_speed"))
                skill.Variable.Remove("Eraser_speed");
            actor.Status.Purger_Lv = skill.skill.Level;
            skill.Variable.Add("Eraser_speed", speed_add);
            actor.Status.speed_skill -= (ushort)speed_add;
            actor.Buff.MainSkillPowerUp3RD = true;
            Manager.MapManager.Instance.GetMap(actor.MapID).SendEventToAllActorsWhoCanSeeActor(Map.EVENT_TYPE.BUFF_CHANGE, null, actor, true);
        }
        void EndEventHandler(Actor actor, DefaultBuff skill)
        {
            actor.Status.speed_skill += (ushort)skill.Variable["Eraser_speed"];
            actor.Status.Purger_Lv = 0;
            actor.Buff.MainSkillPowerUp3RD = false;
            Manager.MapManager.Instance.GetMap(actor.MapID).SendEventToAllActorsWhoCanSeeActor(Map.EVENT_TYPE.BUFF_CHANGE, null, actor, true);
        }
    }
}
