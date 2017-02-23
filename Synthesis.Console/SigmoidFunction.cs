namespace Synthesis.Console
{
    using System;

    public class SigmoidFunction : IFunction
    {
        public double Calculate(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }
    }
}
