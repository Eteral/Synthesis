namespace Synthesis.Console
{
    using System.Collections.Generic;
    using System.Linq;

    public class Neuron
    {
        private readonly IFunction function;

        public Neuron(IFunction function)
        {
            this.function = function;
            this.InputSynapses = new List<Synapse>();
            this.OutputSynapses = new List<Synapse>();
        }

        public IList<Synapse> InputSynapses { get; }

        public IList<Synapse> OutputSynapses { get; }

        public double Output { get; set; }

        public void Signal()
        {
            if (this.InputSynapses.Any())
            {
                this.Output = this.function.Calculate(this.InputSynapses.Sum(synapse => synapse.Input * synapse.Weight));
            }

            foreach (var synapse in this.OutputSynapses)
            {
                synapse.Input = this.Output;
            }
        }
    }
}
