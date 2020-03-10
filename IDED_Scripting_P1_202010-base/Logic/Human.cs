namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            switch (_unitClass)
            {

                case EUnitClass.Imp:
                    _unitClass = EUnitClass.Villager;
                    break;
                case EUnitClass.Orc:
                    _unitClass = EUnitClass.Villager;
                    break;
                case EUnitClass.Dragon:
                    _unitClass = EUnitClass.Villager;
                    break;
                default:
                    _unitClass = EUnitClass.Villager;
                    break;
            }

            if (_potential >= 10)
            {
                _potential = 10;
            }
            if(_potential <= 0)
            {
               _potential = 0;
            }
            else { Potential = _potential; }
        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            if(UnitClass == EUnitClass.Squire && newClass == EUnitClass.Soldier)
            {
                UnitClass = newClass;
                return true;
            }
            if (UnitClass == EUnitClass.Soldier && newClass == EUnitClass.Squire)
            {
                UnitClass = newClass;
                return true;
            }
            if (UnitClass == EUnitClass.Ranger && newClass == EUnitClass.Mage)
            {
                UnitClass = newClass;
                return true;
            }
            if (UnitClass == EUnitClass.Mage && newClass == EUnitClass.Ranger)
            {
                UnitClass = newClass;
                return true;
            }
            if(UnitClass == EUnitClass.Villager)
            {
                return false;
            }
            return false;
        }
    }
}