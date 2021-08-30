namespace UnityEngine
{
    public static class Vector2IntEx
    {
        public static Vector2 ToVector2(this Vector2Int vector)
        {
            return new Vector2(vector.x, vector.y);
        }
    }
}