namespace ClassLibraryES.Managers
{
    public interface IKnowledgeBaseChanged
    {
        event Action KnowledgeBaseChanged;

        void OnKnowledgeBaseChanged();
    }
}