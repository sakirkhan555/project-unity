using UnityEngine;

public static class Helper
{
    public struct ClipPlanePoints
    {
        public Vector3 UpperLeft;
        public Vector3 UpperRight;
        public Vector3 LowerLeft;
        public Vector3 LowerRight;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        do
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
        } while (angle < -360 || angle > 360);

        return Mathf.Clamp(angle, min, max);
    }

    public static ClipPlanePoints ClipPlaneAtNear(Vector3 pos)
    {
        var clipPlanePoints = new ClipPlanePoints();

        if (Camera.main == null)
            return clipPlanePoints;

        var transfrom = Camera.mainCamera.transform;
        var halfFOV = (Camera.mainCamera.fieldOfView / 2) * Mathf.Deg2Rad;
        var aspect = Camera.mainCamera.aspect;
        var distance = Camera.mainCamera.nearClipPlane;
        var height = distance * Mathf.Tan(halfFOV);
        var width = height * aspect;

        clipPlanePoints.LowerRight = pos + transfrom.right * width;
        clipPlanePoints.LowerRight -= transfrom.up * height;
        clipPlanePoints.LowerRight += transfrom.forward * distance;

        clipPlanePoints.LowerLeft = pos - transfrom.right * width;
        clipPlanePoints.LowerLeft -= transfrom.up * height;
        clipPlanePoints.LowerLeft += transfrom.forward * distance;

        clipPlanePoints.UpperRight = pos + transfrom.right * width;
        clipPlanePoints.UpperRight += transfrom.up * height;
        clipPlanePoints.UpperRight += transfrom.forward * distance;

        clipPlanePoints.UpperLeft = pos - transfrom.right * width;
        clipPlanePoints.UpperLeft += transfrom.up * height;
        clipPlanePoints.UpperLeft += transfrom.forward * distance;


        return clipPlanePoints;
    }
}

