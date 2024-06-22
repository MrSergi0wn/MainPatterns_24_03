namespace SpaceBattle.Calculations
{
    public class Vector : IEqualityComparer<Vector>
    {
        private double[] vector;

        public double x => this.vector.Length == 0 ? double.NaN : this.vector[0];
        public double y => this.vector.Length <= 1 ? double.NaN : this.vector[1];

        public Vector(double[] vector)
        {
            this.vector = vector;
        }

        public Vector(double x, double y)
        {
            this.vector = new[] { x, y };
        }

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            try
            {
                var newVector = new double[firstVector.vector.Length];

                for (var i = 0; i < newVector.Length; i++) newVector[i] = firstVector.vector[i] + secondVector!.vector[i];

                return new Vector(newVector);
            }
            catch
            {
                throw new Exception();
            }
        }

        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            try
            {
                var newVector = new double[firstVector.vector.Length];

                for (var i = 0; i < newVector.Length; i++) newVector[i] = firstVector.vector[i] - secondVector!.vector[i];

                return new Vector(newVector);
            }
            catch
            {
                throw new Exception();
            }
        }

        public bool Equals(Vector? firstVector, Vector? secondVector)
        {
            var firstVectorLength = firstVector!.vector.Length;
            var secondVectorLength = secondVector!.vector.Length;

            if (!firstVectorLength.Equals(secondVectorLength)) return false;
            for (var i = 0; i < firstVectorLength; i++)
            {
                if ((int)firstVector.vector[i] != (int)secondVector.vector[i]) return false;
            }

            return true;
        }

        public int GetHashCode(Vector obj)
        {
            return obj.vector.GetHashCode();
        }
    }
}
