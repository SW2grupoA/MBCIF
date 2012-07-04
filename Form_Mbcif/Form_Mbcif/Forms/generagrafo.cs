using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Graphviz4Net.Graphs;

namespace Form_Mbcif.Forms
{
    public class ElementoGrafo
    {
        private readonly Graph<ElementoGrafo> Graph;

        public ElementoGrafo(Graph<ElementoGrafo> Graph)
        {
            this.Graph = Graph;
        }

        public String nombre { get; set; }
        public int valor { get; set; }

        public ICommand RemoveCommand
        {
            get { return new RemoveCommandImpl(this); }
        }

        private class RemoveCommandImpl : ICommand
        {
            private ElementoGrafo elem;

            public RemoveCommandImpl(ElementoGrafo elem)
            {
                this.elem = elem;
            }

            public void Execute(object parameter)
            {
                this.elem.Graph.RemoveVertexWithEdges(this.elem);
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;
        }
    }

    public class DiamondArrow
    {
    }

    public class Arrow
    {
    }

    class generagrafo : INotifyPropertyChanged
    {
        public generagrafo()
        {
            var graph = new Graph<ElementoGrafo>();
            var subgraph = new SubGraph<ElementoGrafo>() { Label = "Colectivo" };
            var a = new ElementoGrafo(graph) { nombre = "pasaje", valor = 500 };
            var b = new ElementoGrafo(graph) { nombre = "pasajeros", valor = 25 };
            var c = new ElementoGrafo(graph) { nombre = "bencina", valor = 1000 };
            graph.AddSubGraph(subgraph);
            subgraph.AddVertex(a);
            subgraph.AddVertex(b);

            graph.AddVertex(c);

            graph.AddEdge(new Edge<ElementoGrafo>(a, b));
            graph.AddEdge(new Edge<ElementoGrafo>(c, b));
            graph.AddEdge(new Edge<ElementoGrafo>(c, a));

            this.Graph = graph;
            this.Graph.Changed += GraphChanged;
        }
        public Graph<ElementoGrafo> Graph { get; private set; }

        public IEnumerable<string> nombreselementos
        {
            get { return this.Graph.AllVertices.Select(x => x.nombre); }
        }

        public void CreateElemento()
        {
            if (this.nombreselementos.Any(x => x == "cakita"))
            {
                // such a person already exists: there should be some validation message, but 
                // it is not so important in a demo
                return;
            }

            var p = new ElementoGrafo(this.Graph) { nombre = "cakita" };
            this.Graph.AddVertex(p);
        }

        public void cambiarelemento(ElementoGrafo l, int nuevovalor)
        {
            l.valor = nuevovalor;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GraphChanged(object sender, GraphChangedArgs e)
        {
            this.RaisePropertyChanged("nombreselementos");
        }

        private void RaisePropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
