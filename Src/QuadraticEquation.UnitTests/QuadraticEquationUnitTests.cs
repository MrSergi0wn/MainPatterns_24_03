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
        /// 3) Написать тест, который проверяет, что для уравнения x^2+1 = 0 корней нет (возвращается пустой массив)
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
        /// 5) Написать тест, который проверяет, что для уравнения x^2-1 = 0 есть два корня кратности 1 (x1=1, x2=-1)
        /// </summary>
        [Theory]
        [InlineData(1.0, 0, -1.0)]
        public void QuadraticEquationWithTwoRootsTest(double a, double b, double c)
        {
            Assert.Equal(this.quadraticEquation.Solve(a, b, c), new double[]{1.0, -1.0});
        }

        /// <summary>
        /// 7) Написать тест, который проверяет, что для уравнения x^2+2x+1 = 0 есть один корень кратности 2 (x1= x2 = -1)
        /// </summary>
        [Theory]
        [InlineData(1.0, 2.0, 1.0)]
        public void QuadraticEquationWithOneRootTest(double a, double b, double c)
        {
            Assert.Equal(this.quadraticEquation.Solve(a, b, c), new[]{-1.0});
        }

        /// <summary>
        /// 9) Написать тест, который проверяет, что коэффициент a не может быть равен 0. В этом случае solve выбрасывает исключение.
        /// Примечание. Учесть, что a имеет тип double и сравнивать с 0 через == нельзя.
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
        /// 11) С учетом того, что дискриминант тоже нельзя сравнивать с 0 через знак равенства,
        /// подобрать такие коэффициенты квадратного уравнения для случая одного корня кратности два,
        /// чтобы дискриминант был отличный от нуля, но меньше заданного эпсилон. Эти коэффициенты должны заменить коэффициенты в тесте из п. 7.
        /// </summary>
        [Fact]
        public void QuadraticEquationWithDiscriminantLessThenEpsilonTest()
        {
            Assert.True(this.quadraticEquation.Solve(1, double.Epsilon / 100, 0).Length == 1);
        }

        /// <summary>
        /// 13) Посмотреть какие еще значения могут принимать числа типа double, кроме числовых и написать тест с их использованием на все коэффициенты.
        /// solve должен выбрасывать исключение.
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