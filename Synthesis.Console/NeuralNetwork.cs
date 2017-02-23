namespace Synthesis.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NeuralNetwork
    {
        private readonly IList<IList<Neuron>> layers;

        public NeuralNetwork(IFunction function, LayersConfiguration configuration)
        {
            var random = new Random();
            this.layers = new List<IList<Neuron>>();

            for (var i = 0; i < configuration.Count; i++)
            {
                var list = new List<Neuron>();
                var neuronsCount = configuration[i].NeuronsPerLayer;

                for (var neuronIndex = 0; neuronIndex < neuronsCount; neuronIndex++)
                {
                    var neuron = new Neuron(function);

                    if (i - 1 >= 0)
                    {
                        var previousLayerNeurons = this.layers[i - 1];
                        foreach (var previousLayerNeuron in previousLayerNeurons)
                        {
                            neuron.InputSynapses.Add(previousLayerNeuron.OutputSynapses[neuronIndex]);
                        }
                    }

                    if (i + 1 < configuration.Count)
                    {
                        var synapseCount = configuration[i + 1].NeuronsPerLayer;
                        for (var synapseIndex = 0; synapseIndex < synapseCount; synapseIndex++)
                        {
                            neuron.OutputSynapses.Add(new Synapse { Weight = random.NextDouble() });
                        }
                    }

                    list.Add(neuron);
                }

                this.layers.Add(list);
            }
        }

        public double[] Evaluate(double[] input)
        {
            var inputNeurons = this.layers.First();
            for (var i = 0; i < input.Length; i++)
            {
                inputNeurons[i].Output = input[i];
            }

            foreach (var layer in this.layers)
            {
                foreach (var neuron in layer)
                {
                    neuron.Signal();
                }
            }

            var outputNeurons = this.layers.Last();

            return outputNeurons.Select(neuron => neuron.Output).ToArray();
        }
    }
}
