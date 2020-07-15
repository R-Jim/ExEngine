namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class CoordinateModifier : Modifier
    {
        public CoordinateModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            Coordinate baseCoordinate = (Coordinate) baseValue;
            if (!(inputValue is Coordinate))
            {
                return baseValue;
            }

            Coordinate inputCoordinate = (Coordinate)inputValue;
            switch (Operator)
            {
                case "=":
                    return new Coordinate(inputCoordinate.X, inputCoordinate.Y);
                case "+":
                    return new Coordinate(baseCoordinate.X + inputCoordinate.X, baseCoordinate.Y + inputCoordinate.Y);
                case "*":
                    return new Coordinate(baseCoordinate.X * inputCoordinate.X, baseCoordinate.Y * inputCoordinate.Y);
                default:
                    return baseValue;
            }
        }
    }
}
