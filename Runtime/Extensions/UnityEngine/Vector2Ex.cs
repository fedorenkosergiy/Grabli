namespace UnityEngine
{ 
    public static class Vector2Ex
    {
        public static Vector2 ChangeY(this Vector2 source, float y)
        {
            return new Vector2(source.x, y);
        }

        public static Vector2 ChangeX(this Vector2 source, float x)
        {
            return new Vector2(x, source.y);
        }
    }
}