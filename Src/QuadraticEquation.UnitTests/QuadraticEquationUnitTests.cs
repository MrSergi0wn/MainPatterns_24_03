namespace MainPatterns.QuadraticEquation.UnitTests
{
    public class QuadraticEquationUnitTests
    {
        private readonly IQuadraticEquation quadraticEquation;

        public QuadraticEquationUnitTests()
        {
            this.quadraticEquation = new QuadraticEquation();
        }

        /// <summary>
        /// 3) �������� ����, ������� ���������, ��� ��� ��������� x^2+1 = 0 ������ ��� (������������ ������ ������)
        /// </summary>
        [Theory]
        [InlineData(1.0, 0, 1.0)]
        [InlineData(0.01, 0, 1.0)]
        [InlineData(0.000000001, 0, 1.0)]
        public void QuadraticEquationWithoutSolutionTest(double a, double b, double c)
        {
            Assert.Equal(this.quadraticEquation.Solve(a, b, c), new double[] { }); 
        }

        /// <summary>
        /// 5) �������� ����, ������� ���������, ��� ��� ��������� x^2-1 = 0 ���� ��� ����� ��������� 1 (x1=1, x2=-1)
        /// </summary>
        [Theory]
        [InlineData(1.0, 0, -1.0)]
        public void QuadraticEquationWithTwoRootsTest(double a, double b, double c)
        {
            Assert.Equal(this.quadraticEquation.Solve(a, b, c), new double[]{1.0, -1.0});
        }

        /// <summary>
        /// 7) �������� ����, ������� ���������, ��� ��� ��������� x^2+2x+1 = 0 ���� ���� ������ ��������� 2 (x1= x2 = -1)
        /// </summary>
        [Theory]
        [InlineData(1.0, 2.0, 1.0)]
        public void QuadraticEquationWithOneRootTest(double a, double b, double c)
        {
            Assert.Equal(this.quadraticEquation.Solve(a, b, c), new[]{-1.0});
        }

        /// <summary>
        /// 9) �������� ����, ������� ���������, ��� ����������� a �� ����� ���� ����� 0. � ���� ������ solve ����������� ����������.
        /// ����������. ������, ��� a ����� ��� double � ���������� � 0 ����� == ������.
        /// </summary>
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1000, -1000)]
        [InlineData(0, 0.0001, -0.9999)]
        public void QuadraticEquationWithExceptionTest(double a, double b, double c)
        {
            Assert.Throws<Exception>(() => this.quadraticEquation.Solve(a, b, c));
        }

        /// <summary>
        /// 11) � ������ ����, ��� ������������ ���� ������ ���������� � 0 ����� ���� ���������,
        /// ��������� ����� ������������ ����������� ��������� ��� ������ ������ ����� ��������� ���,
        /// ����� ������������ ��� �������� �� ����, �� ������ ��������� �������. ��� ������������ ������ �������� ������������ � ����� �� �. 7.
        /// </summary>
        [Fact]
        public void QuadraticEquationWithDiscriminantLessThenEpsilonTest()
        {
            Assert.True(this.quadraticEquation.Solve(1, double.Epsilon / 100, 0).Length == 1);
        }

        /// <summary>
        /// 13) ���������� ����� ��� �������� ����� ��������� ����� ���� double, ����� �������� � �������� ���� � �� �������������� �� ��� ������������.
        /// solve ������ ����������� ����������.
        /// </summary>
        [Theory]
        [InlineData(double.NaN, 1, 1)]
        [InlineData(double.NegativeInfinity, 1, 1)]
        [InlineData(double.PositiveInfinity, 1, 1)]
        [InlineData(1, double.NaN, 1)]
        [InlineData(1, double.NegativeInfinity, 1)]
        [InlineData(1, double.PositiveInfinity, 1)]
        [InlineData(1, 1, double.NaN)]
        [InlineData(1, 1, double.NegativeInfinity)]
        [InlineData(1, 1, double.PositiveInfinity)]
        public void QuadraticEquationWithInvalidValuesParametersTest(double a, double b, double c)
        {
            Assert.Throws<Exception>(() => this.quadraticEquation.Solve(a, b, c));
        }

    }
}