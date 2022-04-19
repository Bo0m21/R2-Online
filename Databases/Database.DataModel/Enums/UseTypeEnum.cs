using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataModel.Enums
{
    public enum UseTypeEnum
    {
        None = 0,
        Self = 1,
        ToObjCtrl = 2,
        ToObj = 3,
        ToItem = 4,
        ToItemUpgrade = 5,
        ToObjAttack = 6,
        ToObjSelfRange = 7,
        SelfDelay = 8,
        SpecificSelf = 9,
        SpecificToObj = 10,
        SpecificToItem = 11,
        SelfWrappingItem = 12,
        SelfUnMovable = 13,
        KeyForWrappingItem = 14,
        AbilityToObjCtrlDHit = 15,
        AbilityToObjCtrlMHit = 16,
        AbilityToObjAttackDHit = 17,
        AbilityToObjAttackMHit = 18,
        AbilityToObjCtrlRHit = 19,
        AbilityToObjAttackRHit = 20,
        eUseTypeCnt = 21,
    }
}
