using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Graphviz4Net.Graphs;

namespace Form_Mbcif.Forms
{
    public class Elemento
    {
        private readonly Graph<Elemento> Graph;

        public Elemento(Graph<Elemento> Graph)
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
            private Elemento elem;

            public RemoveCommandImpl(Elemento elem)
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
            var graph = new Graph<Elemento>();
            var subgraph = new SubGraph<Elemento>() { Label = "Colectivo" };
            var a = new Elemento(graph) { nombre = "pasaje", valor = 500 };
            var b = new Elemento(graph) { nombre = "pasajeros", valor = 25 };
            var c = new Elemento(graph) { nombre = "bencina", valor = 1000 };
            graph.AddSubGraph(subgraph);
            subgraph.AddVertex(a);
            subgraph.AddVertex(b);

            graph.AddVertex(c);

            graph.AddEdge(new Edge<Elemento>(a, b));
            graph.AddEdge(new Edge<Elemento>(c, b));
            graph.AddEdge(new Edge<Elemento>(c, a));

            this.Graph = graph;
            this.Graph.Changed += GraphChanged;
        }
        public Graph<Elemento> Graph { get; private set; }

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

            var p = new Elemento(this.Graph) { nombre = "cakita" };
            this.Graph.AddVertex(p);
        }

        public void cambiarelemento(Elemento l, int nuevovalor)
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
