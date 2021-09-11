namespace Units
{
    public class UnitController : CharacterController
    {
        protected override void Reset()
        {
            base.Reset();
            Type = EntityType.Unit;
        }
    }
}