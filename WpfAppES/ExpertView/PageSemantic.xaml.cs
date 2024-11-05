using ClassLibraryES.Semantic;
using Microsoft.Msagl.Drawing;
using System.Windows.Controls;
using Microsoft.Msagl.WpfGraphControl;

namespace WpfAppES.ExpertView
{
    /// <summary>
    /// Логика взаимодействия для PageSemantic.xaml
    /// </summary>
    public partial class PageSemantic : Page
    {
        public PageSemantic()
        {
            InitializeComponent();
            //relation.ItemsSource = RelationExtensions.GetRelatives();

            GraphViewer graphViewer = new GraphViewer();
            graphViewer.BindToPanel(semanticGraphViewer);
            graphViewer.LayoutEditingEnabled = false;
            Graph graph = new();
            graph.AddEdge("47","это", "58");
            graph.AddEdge("70", "71");

            var subgraph = new Subgraph("subgraph1");
            graph.RootSubgraph.AddSubgraph(subgraph);
            subgraph.AddNode(graph.FindNode("47"));
            subgraph.AddNode(graph.FindNode("58"));

            var subgraph2 = new Subgraph("subgraph2");
            subgraph2.Attr.Color = Color.Black;
            subgraph2.Attr.FillColor = Color.Yellow;
            subgraph2.AddNode(graph.FindNode("70"));
            subgraph2.AddNode(graph.FindNode("71"));
            subgraph.AddSubgraph(subgraph2);
            graph.AddEdge("58", subgraph2.Id);
            graph.Attr.LayerDirection = LayerDirection.LR;
            graphViewer.Graph = graph;
            graphViewer.NodeToCenter(graph.FindNode("47"));
        }
    }
}
