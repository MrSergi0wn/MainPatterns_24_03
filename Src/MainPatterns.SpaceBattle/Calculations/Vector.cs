namespace MainPatterns.SpaceBattle.Calculations
{
    public class Vector
    {
        private int[] vector;

        public Vector() { }

        public Vector(int[] vector)
        {
            this.vector = vector;
        }

        public Vector(int x, int y)
        {
            vector = new int[] { x, y };
        }

        public Vector Sum(Vector firstVector, Vector secondVector)
        {
            var newVector = new int[firstVector.vector.Length];

            for (var i = 0; i < newVector.Length; i++)
            {
                newVector[i] = firstVector.vector[i] + secondVector.vector[i];
            }

            return new Vector(newVector);
        }
    }
}
