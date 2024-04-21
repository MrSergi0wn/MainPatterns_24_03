namespace MainPatterns.SpaceBattle.Calculations
{
    public class Vector
    {
        private int[] vector;

        public Vector(int[] vector)
        {
            this.vector = vector;
        }

        public static Vector operator +(Vector? firstVector, Vector? secondVector)
        {
            try
            {
                var newVector = new int[firstVector!.vector.Length];

                for (var i = 0; i < newVector.Length; i++)
                {
                    newVector[i] = firstVector.vector[i] + secondVector!.vector[i];
                }

                return new Vector(newVector);
            }
            catch
            {
                throw new NullReferenceException();
            }
        }
    }
}
