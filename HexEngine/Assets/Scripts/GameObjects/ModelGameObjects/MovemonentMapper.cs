using UnityEngine;

public class MovemonentMapper : MonoBehaviour
{
    public Model Model;
    public Coordinate ModelCoordinate;
    public float OffSetX = 0.75f;
    public float OffSetY = 0.5f;
    public float OffSetZ = -0.5f;

    private float LastX;
    private float LastY;
    private float LastZ;

    // Update is called once per frame
    void Update()
    {
        if(Model == null)
        {
            return;
        }

        Coordinate coordinate = Model.CommonPropertySet.Coordinate;
        if (coordinate != null)
        {
            ModelCoordinate = coordinate.Clone();
            if (Model.CommonPropertySet.MountedTo != null)
            {
                ModelCoordinate.Add(Model.CommonPropertySet.MountedTo.RenderCoordinate);
            }
            if (LastX == ModelCoordinate.X && LastY == ModelCoordinate.Y && LastZ == ModelCoordinate.Z)
            {
                return;
            }
            transform.localPosition = MapCoordinateToGridVector();
            LastX = ModelCoordinate.X;
            LastY = ModelCoordinate.Y;
            LastZ = ModelCoordinate.Z;
        }
    }

    private Vector3 MapCoordinateToGridVector()
    {
        float x = ModelCoordinate.X * OffSetX;
        float y = ModelCoordinate.Y * OffSetY;
        float z = ModelCoordinate.Z * OffSetZ;
        return new Vector3(x, y + z);
    }
}
