using UnityEngine;


namespace CircleSquare
{
    public class PlayerInputController
    {
        public Vector2 GetMousePositionInWorld(Camera camera)
        {
            var mousePositionInScreen = Input.mousePosition;
            var cameraVerticalSizeInUnits = camera.orthographicSize * 2;
            var unitSize = camera.pixelHeight / cameraVerticalSizeInUnits;
            var cameraCenter = new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2);
            var result = new Vector2(
                (mousePositionInScreen.x - cameraCenter.x) / unitSize + camera.transform.position.x, 
                (mousePositionInScreen.y - cameraCenter.y) / unitSize + camera.transform.position.y);
            return result;
        }
    }
}