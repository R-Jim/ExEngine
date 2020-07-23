namespace ExtiliaEngine
{
    public class BindedObjectCondition : ObjectCondition
    {
        public object ValueObject { get; }

        public BindedObjectCondition(object valueObject, string fieldPath, string conditionOperator,
            object baseObject, string objectFieldPath)
            : base(fieldPath, conditionOperator, baseObject, objectFieldPath)
        {
            ValueObject = valueObject;
        }

        public new bool IsMatchCondition(object inputObject)
        {
            BaseValue = Util.GetFieldValue(ObjectFieldPath, BaseObject);
            object fieldValue = Util.GetFieldValue(FieldPath, ValueObject);
            return base.IsMatchCondition(fieldValue);
        }
    }
}
