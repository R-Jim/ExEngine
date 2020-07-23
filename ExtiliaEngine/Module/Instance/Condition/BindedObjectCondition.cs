namespace ExtiliaEngine
{
    public class BindedObjectCondition : Condition
    {
        public object ValueObject { get; }
        public object BaseObject { get; }
        public string ObjectFieldPath { get; }

        public BindedObjectCondition(object valueObject, string fieldPath, string conditionOperator,
        object baseValue)
            : base(fieldPath, conditionOperator, baseValue)
        {
            ValueObject = valueObject;
        }

        public BindedObjectCondition(object valueObject, string fieldPath, string conditionOperator,
            object baseObject, string objectFieldPath)
            : base(fieldPath, conditionOperator, null)
        {
            ValueObject = valueObject;
            BaseObject = baseObject;
            ObjectFieldPath = objectFieldPath;
        }

        public override bool IsMatchCondition(object inputObject)
        {
            if (ObjectFieldPath != null && BaseObject != null)
            {
                BaseValue = Util.GetFieldValue(ObjectFieldPath, BaseObject);

            }
            return base.IsMatchCondition(ValueObject);
        }
    }
}
