using Database.Account.Models;
using Database.DataModel.Enums;
using Database.Game.Models;
using Packets.Server.Game.Structures;
using Server.Game.Models.Game;
using Server.Game.Services.Database;
using System.Linq;

namespace Server.Game.Services
{
    /// <summary>
    ///     Database mapping service
    /// </summary>
    public class DBGameMappingService
    {
        private readonly ParmRepository _parmRepository;

        public DBGameMappingService(ParmRepository parmRepository)
        {
            _parmRepository = parmRepository;
        }

        #region Character mapping
        /// <summary>
        ///     Map character
        /// </summary>
        /// <param name="pc"></param>
        /// <param name="dbPc"></param>
        public void MapCharacter(GPc pc, Pc dbPc, ParmMonster parmMon)
        {
            pc.Simple = new GPcSimple
            {
                PcNo = (uint)dbPc.No,
                NickName = dbPc.NickName,
                Slot = dbPc.Slot,
                Class = (PcClassEnum)dbPc.Class,
                Sex = dbPc.Sex,
                Head = dbPc.Head,
                Face = dbPc.Face,
                Level = (ushort)dbPc.State.Level,
                Exp = (ulong)dbPc.State.Exp,
                Hp = dbPc.State.Hp,
                Mp = dbPc.State.Mp,
            };

            pc.BeginHp = pc.Simple.Hp;
            pc.BeginMp = pc.Simple.Mp;
            pc.AddHp = (short)dbPc.State.HpAdd;
            pc.AddMp = (short)dbPc.State.MpAdd;
            pc.PreventItemDrop = dbPc.State.IsPreventItemDrop == true;
            pc.Simple.SetStomach(dbPc.State.Stomach);

            pc.PositionCur = new Vector3(dbPc.State.PosX, dbPc.State.PosY, dbPc.State.PosZ);
            // TODO GUILD __int64 __fastcall CPc::__FetchPcBase(CPc *this, unsigned int pPcNo)

            pc.CalcAbility();
            pc.Detail = new GPcDetail();
            pc.Detail.SetChaotic(dbPc.State.Chaotic);
            pc._SetDefaultInfo(parmMon);

            foreach (var item in dbPc.PcInventoryItems)
            {
                var parmItem = _parmRepository.GetItemById(item.ItemNo);

                if (parmItem == null)
                    continue;

                var gItem = new GItem(parmItem);
                gItem.SerialNumber = (ulong)item.SerialNo;
                gItem.IsConfirm = item.IsConfirm;
                gItem.Status = (ItemStatusEnum)item.Status;
                gItem.Count = item.Cnt;
                gItem.UseCount = item.CntUse;
                gItem.ItemBind = (ItemBindTypeEnum)item.BindingType;
                gItem.Restore = item.RestoreCnt;
                gItem.Hole = item.HoleCount;

                pc.Inventory.Items.Add(gItem);
            }

            foreach (var itemEquip in dbPc.PcEquips)
            {
                var item = pc.Inventory.Items.FirstOrDefault(x => x.SerialNumber == (ulong)itemEquip.SerialNo);
                if (item == null)
                    continue;

                var equip = new GPcEquip()
                {
                    IsConfirm = item.IsConfirm ? 1 : 0,
                    IsEquip = true, // TODO хуйня какая-то, если мы берем экипировку, то почему есть bool IsEquip?
                    IsSeal = false,
                    SerialNo = item.SerialNumber,
                    Status = item.Status,
                    Item = item
                };

                pc.Equip.Add(equip);
            }


            // TODO Подтягивание шмота и экипировки

            //TODO Добавить в бд pc направление взгляда
        }
        #endregion

        #region Item mapping
        /// <summary>
        ///     Map item
        /// </summary>
        /// <param name="itemGame"></param>
        /// <param name="item"></param>
        //public void MapItem(GItem itemGame, ItemModel item)
        //{
        //    itemGame.Id = item.Id;
        //    itemGame.Id = item.ItemId;

        //    itemGame.EquipPos = item.Position;
        //    itemGame.Count = item.Count;

        //    itemGame.IsConfirm = item.Flag;
        //    itemGame.EndTick = item.EndTick;
        //    itemGame.Status = item.ItemStatus;
        //    itemGame.UseCount = item.UseCount;
        //    itemGame.EatTime = item.EatTime;
        //    itemGame.TermOfValidity = item.TermOfEffectivity;
        //    itemGame.ItemBind = item.ItemBind;
        //    itemGame.Restore = item.Restore;
        //    itemGame.Hole = item.Hole;
        //}
        #endregion

        #region Session mapping
        /// <summary>
        ///     Map session
        /// </summary>
        /// <param name="sessionGame"></param>
        /// <param name="session"></param>
        public void MapSession(GSession sessionGame, SessionModel session)
        {
            sessionGame.Id = session.Id;

            sessionGame.AccountId = session.AccountId;
            sessionGame.ServerId = session.ServerId;
            sessionGame.InGame = session.InGame;
        }
        #endregion
    }
}
