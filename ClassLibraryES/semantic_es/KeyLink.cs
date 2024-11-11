namespace ClassLibraryES.semantic_es
{
    public class KeyLink
    {
        public KeyLink() { }
        public KeyLink(Guid id, Guid slave, Guid relative)
        {
            Id = id;
            Slave = slave;
            Relative = relative;
        }

        public Guid Id { get; set; }
        public Guid Slave { get; set; }
        public Guid Relative { get; set; }
    }
}
