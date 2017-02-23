namespace Synthesis.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var layersConfiguration = new LayersConfiguration
            {
                new LayerConfiguration { NeuronsPerLayer = 2 },
                new LayerConfiguration { NeuronsPerLayer = 3 },
                new LayerConfiguration { NeuronsPerLayer = 1 }
            };

            var neuralNetwork = new NeuralNetwork(new SigmoidFunction(), layersConfiguration);

            //var inputData = new[]
            //{
            //    new double[] { 0, 0 },
            //    new double[] { 0, 1 },
            //    new double[] { 1, 1 },
            //    new double[] { 1, 1 }
            //};

            //var outputData = new double[]
            //{
            //    0,
            //    1,
            //    1,
            //    1
            //};

            var result = neuralNetwork.Evaluate(new double[] { 1, 0 });
        }
    }
}
