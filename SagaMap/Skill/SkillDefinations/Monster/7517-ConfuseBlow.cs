﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SagaDB.Actor;


namespace SagaMap.Skill.SkillDefinations.Monster
{
    public class ConfuseBlow : ISkill
    {
        public int TryCast(ActorPC pc, Actor dActor, SkillArg args)
        {
            return 0;
        }
        public void Proc(Actor sActor, Actor dActor, SkillArg args, byte level)
        {
            args.type = ATTACK_TYPE.BLOW;
            float factor = 1.2f;
            int lifetime = 5000;
            int rate = 10;
            if (SkillHandler.Instance.CanAdditionApply(sActor, dActor, SkillHandler.DefaultAdditions.Confuse, rate))
            {
                Additions.Global.Confuse skill = new SagaMap.Skill.Additions.Global.Confuse(args.skill, dActor, lifetime);
                SkillHandler.ApplyAddition(dActor, skill);
            }
            SkillHandler.Instance.PhysicalAttack(sActor, dActor, args, SagaLib.Elements.Neutral, factor);
            //if (SagaLib.Global.Random.Next(0, 99) < rate)
            //{
                
            //    Additions.Global.Confuse skill = new SagaMap.Skill.Additions.Global.Confuse(args.skill, dActor, lifetime);
            //    SkillHandler.ApplyAddition(dActor, skill);
            //}
        }
    }
}
