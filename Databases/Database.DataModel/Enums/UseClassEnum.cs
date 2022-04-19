using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataModel.Enums
{
    public enum UseClassEnum
    {
        Fighter = 1,
        Dragoon = 2,
        Wizard = 4,
        FighterWizard = 5,
        FighterDragoonWizard = 7,
        Assassin = 8,
        Summoner = 16,
        DragoonWizardSummoner = 22,
        FighterDragoonWizardSummoner = 23,
        AllClasses = 255,
    }
}
