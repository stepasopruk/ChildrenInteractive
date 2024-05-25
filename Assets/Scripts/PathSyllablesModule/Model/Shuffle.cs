namespace Extension
{
    public static class Shuffle
    {
        private static System.Random _random = new System.Random();

        public static void ShuffleArray<T>(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int randomIndex = _random.Next(i + 1);
                Swap(ref array[i], ref array[randomIndex]);
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
