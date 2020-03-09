namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int baseAtk;
        public int baseDef;
        public int baseSpd;

        public int BaseAtk { get => baseAtk; set => baseAtk = value; }
        public int BaseDef { get => baseDef; set => baseDef = value; }
        public int BaseSpd { get => baseSpd; set => baseSpd = value; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public void Restriction()
        {
            if( BaseAtk<= 255 && BaseAtk >= 0)
            {
                BaseAtk = BaseAtk;
            }
            if (BaseAtk > 255) BaseAtk = 255;
            if (BaseAtk < 0) BaseAtk = 0;

            if (BaseDef <= 255 && BaseDef >= 0)
            {
                BaseDef = BaseDef;
            }
            if (BaseDef > 255) BaseDef = 255;
            if (BaseDef < 0) BaseDef = 0;

            if (BaseSpd <= 255 && BaseSpd >= 0)
            {
                BaseSpd = BaseSpd;
            }
            if (BaseSpd > 255) BaseSpd = 255;
            if (BaseSpd < 0) BaseSpd = 0;
            if (MoveRange > 10) MoveRange = 10;
            if (MoveRange < 1) MoveRange = 1;
        }  

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
            switch (UnitClass)
            {
                case EUnitClass.Squire:
                    Attack = 0.02f * BaseAtk;
                    Defense = 0.01f * BaseDef;
                    Speed = 0 * BaseSpd;
                    AtkRange = 1;
                    break;

                case EUnitClass.Soldier:
                    Attack = 0.03f * BaseAtk;
                    Defense = 0.02f * BaseDef;
                    Speed = 0.01f;
                    AtkRange = 1;
                    break;

                case EUnitClass.Ranger:
                    Attack = 0.01f * BaseAtk;
                    Defense = 0 * BaseDef;
                    Speed = 0.03f * BaseSpd;
                    AtkRange = 3;
                    break;

                case EUnitClass.Mage:
                    Attack = 0.03f * BaseAtk;
                    Defense = 0.01f * BaseDef;
                    Speed = -0.01f;
                    AtkRange = 3;
                    break;

                case EUnitClass.Imp:
                    Attack = 0.01f * BaseAtk;
                    Defense = 0 * BaseDef;
                    Speed = 0 * BaseSpd;
                    AtkRange = 1;
                    break;

                case EUnitClass.Orc:
                    Attack = 0.04f * BaseAtk;
                    Defense = 0.02f * BaseDef;
                    Speed = -0.02f * BaseSpd;
                    AtkRange = 1;
                    break;

                case EUnitClass.Dragon:
                    Attack = 0.05f * BaseAtk;
                    Defense = 0.03f * BaseDef;
                    Speed = 0.02f * BaseSpd;
                    AtkRange = 5;
                    break;

                case EUnitClass.Villager:
                    Attack = 0 * BaseAtk;
                    Defense = 0 * BaseDef;
                    Speed = 0 * BaseSpd;
                    AtkRange = 0;
                    break;
            }
        }

        public virtual bool Interact(Unit otherUnit)
        {
            if (UnitClass == EUnitClass.Villager)
            {
                return false;
            }

            else if (UnitClass == EUnitClass.Squire && otherUnit.UnitClass != EUnitClass.Villager)
            {
                return true;
            }
            else if (UnitClass == EUnitClass.Soldier && otherUnit.UnitClass != EUnitClass.Villager)
            {
                return true;
            }
            else if (UnitClass == EUnitClass.Ranger && otherUnit.UnitClass != EUnitClass.Mage || otherUnit.UnitClass != EUnitClass.Dragon)
            {
                return true;
            }
            else if (UnitClass == EUnitClass.Mage && otherUnit.UnitClass != EUnitClass.Mage)
            {
                return true;
            }
            else if (UnitClass == EUnitClass.Imp && otherUnit.UnitClass != EUnitClass.Dragon)
            {
                return true;
            }
            else if (UnitClass == EUnitClass.Orc && otherUnit.UnitClass != EUnitClass.Dragon)
            {
                return true;

            }

            else if (UnitClass == EUnitClass.Dragon)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public virtual bool Interact(Prop prop)
        {
            if (UnitClass == EUnitClass.Villager)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Move(Position targetPosition)
        {
            bool seMuebe = false;
            float targetSUM = targetPosition.x + targetPosition.y;
            float curentSUM = CurrentPosition.x + CurrentPosition.y;

            if (CurrentPosition.x == targetPosition.x && CurrentPosition.y == targetPosition.y)
            {
                seMuebe = false;
            }
            else if (curentSUM + MoveRange >= targetSUM)
            {
                seMuebe = true;
                CurrentPosition = targetPosition;
            }

            return seMuebe;
        }
        
    }
}