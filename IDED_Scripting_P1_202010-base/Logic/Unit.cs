namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        private int baseAtk;
        private int baseDef;
        private int baseSpd;

        public int BaseAtk { get => baseAtk; protected set => baseAtk = value; }
        public int BaseDef { get => baseDef; protected set => baseDef = value; }
        public int BaseSpd { get => baseSpd; protected set => baseSpd = value; }

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

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
        }

        public virtual bool Interact(Unit otherUnit)
        {
            return false;
        }

        public virtual bool Interact(Prop prop) => false;

        public bool Move(Position targetPosition) => false;
    }
}