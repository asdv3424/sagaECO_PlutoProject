﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SagaDB.Actor;
using SagaLib;
using SagaMap.Network.Client;
namespace SagaMap.Skill.SkillDefinations.Enchanter
{
    /// <summary>
    /// 酸性霧氣（アシッドミスト）
    /// </summary>
    public class AcidMist : ISkill
    {
        #region ISkill Members

        public int TryCast(ActorPC pc, Actor dActor, SkillArg args)
        {
            Map map = Manager.MapManager.Instance.GetMap(pc.MapID);
            if (map.CheckActorSkillInRange(SagaLib.Global.PosX8to16(args.x, map.Width), SagaLib.Global.PosY8to16(args.y, map.Height), 100))
                return -17;

            if (args.x >= map.Width || args.y >= map.Height)
                return -6;
            if (map.Info.earth[args.x, args.y] > 0)
                return 0;
            else
                return -12;
        }

        public void Proc(Actor sActor, Actor dActor, SkillArg args, byte level)
        {
            Map map = Manager.MapManager.Instance.GetMap(sActor.MapID);
            if (map.Info.earth[args.x, args.y] == 0)
            {
                MapClient.FromActorPC((ActorPC)sActor).SendSystemMessage("无法在指定的坐标使用");
                return;
            }
            //创建设置型技能技能体
            ActorSkill actor = new ActorSkill(args.skill, sActor);
            //设定技能体位置
            actor.MapID = dActor.MapID;
            actor.X = SagaLib.Global.PosX8to16(args.x, map.Width);
            actor.Y = SagaLib.Global.PosY8to16(args.y, map.Height);
            //设定技能体的事件处理器，由于技能体不需要得到消息广播，因此创建个空处理器
            actor.e = new ActorEventHandlers.NullEventHandler();
            //在指定地图注册技能体Actor
            map.RegisterActor(actor);
            //设置Actor隐身属性为非
            actor.invisble = false;
            //广播隐身属性改变事件，以便让玩家看到技能体
            map.OnActorVisibilityChange(actor);
            //创建技能效果处理对象
            Activator timer = new Activator(sActor, actor, args, level);
            timer.Activate();
        }
        #endregion

        #region Timer

        private class Activator : MultiRunTask
        {
            Actor sActor;
            ActorSkill actor;
            SkillArg skill;
            float factor;
            Map map;
            int times;
            int count = 0;
            int lifetime;
            public Activator(Actor _sActor, ActorSkill _dActor, SkillArg _args, byte level)
            {
                sActor = _sActor;
                actor = _dActor;
                skill = _args.Clone();
                factor = 1.5f + 0.1f * level;
                this.dueTime = 0;
                times = 30 - 5 * level;
                this.period = 500;
                lifetime = 35000 - 5000 * level;
                map = Manager.MapManager.Instance.GetMap(actor.MapID);
            }
            public override void CallBack()
            {
                //同步锁，表示之后的代码是线程安全的，也就是，不允许被第二个线程同时访问
                //测试去除技能同步锁ClientManager.EnterCriticalArea();
                try
                {
                    if (count <= times && lifetime > 0)
                    {
                        //取得设置型技能，技能体周围7x7范围的怪（范围300，300代表3格，以自己为中心的3格范围就是7x7）
                        List<Actor> actors = map.GetActorsArea(actor, 100, false);
                        List<Actor> affected = new List<Actor>();
                        //取得有效Actor（即怪物）

                        //施加魔法伤害
                        skill.affectedActors.Clear();
                        foreach (Actor i in actors)
                        {
                            if (SkillHandler.Instance.CheckValidAttackTarget(sActor, i))
                            {
                                affected.Add(i);
                            }
                        }
                        SkillHandler.Instance.MagicAttack(sActor, affected, skill, SagaLib.Elements.Earth, factor);
                        //广播技能效果
                        map.SendEventToAllActorsWhoCanSeeActor(Map.EVENT_TYPE.SKILL, skill, actor, false);
                        count++;
                        lifetime -= this.period;
                    }
                    else
                    {
                        this.Deactivate();
                        map.DeleteActor(actor);
                    }

                }
                catch (Exception ex)
                {
                    Logger.ShowError(ex);
                }
                //解开同步锁
                //测试去除技能同步锁ClientManager.LeaveCriticalArea();
            }

        }
        #endregion
    }
}
